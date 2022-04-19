using LawFirmSite.Consts;
using LawFirmSite.CustomFunks;
using LawFirmSite.Entity;
using LawFirmSite.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LawFirmSite.Controllers
{
    public class ArticlesController : Controller
    {
        DataContext _context = new DataContext();
        // GET: Articles
        public ActionResult Index(string lang)
        {
            string language = CookieFunks.GetLanguageCookie(lang);
            ViewBag.LayoutModel = new LayoutModel(_context.practices.ToList(), _context.contacts.ToList(), _context.languages.ToList(), language);

            var model = _context.articles.ToList().Select(a => new ArticlesModel(a, ref language)).ToList();
            return View(model);
        }

        public ActionResult Article(string id, string lang)
        {
            int idme = 0;
            if (!int.TryParse(id, out idme))
            {
                return RedirectToAction("Index", "Articles");
            }
            string language = CookieFunks.GetLanguageCookie(lang);
            ViewBag.LayoutModel = new LayoutModel(_context.practices.ToList(), _context.contacts.ToList(), _context.languages.ToList(), language);

            var model = new ArticlePageModel(_context.articles.FirstOrDefault(a => a.Id == idme), ref language);
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult UploadImage(HttpPostedFileBase imgfile)
        {
            string filename = "";

            if ((imgfile != null) && (imgfile.ContentLength > 0))
            {
                var extensition = Path.GetExtension(imgfile.FileName);

                if (extensition.Equals(".jpg") || extensition.Equals(".png"))
                {
                    var folder = Server.MapPath("~/Images/Articles");
                    string[] pdfFiles = Directory.GetFiles(Server.MapPath("~/Images/Articles"), "*");
                    for (int i = 0; i < pdfFiles.Length; i++)
                    {
                        pdfFiles[i] = Path.GetFileName(pdfFiles[i]);
                    }

                    filename = Path.ChangeExtension(Path.GetRandomFileName(), extensition);
                    while (pdfFiles.FirstOrDefault(a => a.Equals(filename)) != null)
                    {
                        filename = Path.ChangeExtension(Path.GetRandomFileName(), extensition);
                    }

                    var path = Path.Combine(folder, filename);

                    imgfile.SaveAs(path);

                }
            }

            return Json(new { filename }, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        [HttpPost]
        public ActionResult DeleteImage(DeleteModel delmodel)
        {
            if ((delmodel.NameOrid != null) && (delmodel.NameOrid.Length > 0) && !delmodel.NameOrid.Equals("300x300.png"))
            {
                var isused = _context.abouts.FirstOrDefault(a => a.ImgUrl.Equals("/Images/Articles/" + delmodel.NameOrid));
                if (isused == null)
                {
                    var isused2 = _context.practices.FirstOrDefault(a => a.ImgUrlBig.Equals("/Images/Articles/" + delmodel.NameOrid));
                    if (isused2 == null)
                    {
                        var folder = Server.MapPath("~/Images/Articles");

                        var path = Path.Combine(folder, delmodel.NameOrid);

                        System.IO.File.Delete(path);

                        string success = "FileDeleted";
                        success = Const.GetValueFromDictionary(_context.languages.FirstOrDefault(a => a.Abbreviation.Equals(delmodel.LangAbr)).Content, ref success);
                        return Json(new { success });
                    }
                }
            }

            string error = "FileInUse";
            error = Const.GetValueFromDictionary(_context.languages.FirstOrDefault(a => a.Abbreviation.Equals(delmodel.LangAbr)).Content, ref error);
            return Json(new { error });
        }

        [Authorize]
        public ActionResult Create(string lang)
        {
            string language = CookieFunks.GetLanguageCookie(lang);
            ViewBag.LayoutModel = new LayoutModel(_context.practices.ToList(), _context.contacts.ToList(), _context.languages.ToList(), language);

            ArticlesCreateModel model = new ArticlesCreateModel();
            model.AuthnamesNids = _context.employees.ToList().Select(a => Const.AddChangeLangValue(Const.AddChangeLangValue("", a.Id.ToString(), "AuthID"), Const.GetValueFromDictionary(a.Title, ref language) + " " + a.IDInfo.Name + " " + a.IDInfo.Surname, "FullName")).ToArray();
            model.AvailableImageUrls = Directory.GetFiles(Server.MapPath("~/Images/Articles"), "*");
            for (int i = 0; i < model.AvailableImageUrls.Length; i++)
            {
                model.AvailableImageUrls[i] = Path.GetFileName(model.AvailableImageUrls[i]);
            }
            return View(model);
        }

        [Authorize]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(ArticleCreateEditModel modelthis)
        {
            string language = CookieFunks.GetLanguageCookie(modelthis.lang);
            ViewBag.LayoutModel = new LayoutModel(_context.practices.ToList(), _context.contacts.ToList(), _context.languages.ToList(), language);

            try
            {

                Employee auth = _context.employees.FirstOrDefault(a => a.Id == modelthis.Authid);
                var newArticle = new Article(modelthis, auth);
                _context.articles.Add(newArticle);
                _context.SaveChanges();
                

                auth.Articles = auth.Articles + _context.articles.OrderByDescending(a => a.Id).FirstOrDefault().Id + Const.keySeparator;

                _context.Entry(auth).State = EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Authorize]
        public ActionResult Edit(string id, string lang)
        {
            int idme = 0;
            if (!int.TryParse(id, out idme))
            {
                return RedirectToAction("Index", "Articles");
            }
            string language = CookieFunks.GetLanguageCookie(lang);
            ViewBag.LayoutModel = new LayoutModel(_context.practices.ToList(), _context.contacts.ToList(), _context.languages.ToList(), language);

            var model = new ArticleCreateEditModel(_context.articles.FirstOrDefault(a => a.Id == idme), ref language);
            model.AuthnamesNids = _context.employees.ToList().Select(a => Const.AddChangeLangValue(Const.AddChangeLangValue("", a.Id.ToString(), "AuthID"), Const.GetValueFromDictionary(a.Title, ref language) + " " + a.IDInfo.Name + " " + a.IDInfo.Surname, "FullName")).ToArray();
            model.AvailableImageUrls = Directory.GetFiles(Server.MapPath("~/Images/Articles"), "*");
            for (int i = 0; i < model.AvailableImageUrls.Length; i++)
            {
                model.AvailableImageUrls[i] = Path.GetFileName(model.AvailableImageUrls[i]);
            }
            return View(model);
        }

        [Authorize]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(ArticleCreateEditModel editmodel)
        {
           
            try
            {
                var articeme = _context.articles.FirstOrDefault(a => a.Id == editmodel.idme);

                Employee oldauth = _context.employees.FirstOrDefault(a => a.Id == articeme.authoridme);

                if (articeme.authoridme != editmodel.Authid)
                {
                    oldauth.Articles = Const.deleteArticle(oldauth.Articles, editmodel.idme.ToString());

                    _context.Entry(oldauth).State = EntityState.Modified;

                    Employee auth = _context.employees.FirstOrDefault(a => a.Id == editmodel.Authid);
                    articeme.equlize(editmodel, auth);

                    auth.Articles = auth.Articles + editmodel.idme + Const.keySeparator;
                    _context.Entry(auth).State = EntityState.Modified;
                }
                else
                {
                    articeme.equlize(editmodel, oldauth);
                }

                _context.Entry(articeme).State = EntityState.Modified;
                _context.SaveChanges();

                string success = "EditSuccess";
                success = Const.GetValueFromDictionary(_context.languages.FirstOrDefault(a => a.Abbreviation.Equals(editmodel.lang)).Content, ref success);
                return Json(new { success });
            }
            catch
            {
                string error = "EditFail";
                error = Const.GetValueFromDictionary(_context.languages.FirstOrDefault(a => a.Abbreviation.Equals(editmodel.lang)).Content, ref error);
                return Json(new { error });
            }
        }

        [Authorize]
        [HttpPost]
        public ActionResult Delete(DeleteModel delmodel)
        {
            try
            {
                int idme = 0;
                if (!int.TryParse(delmodel.NameOrid, out idme))
                {
                    throw new System.InvalidOperationException("Bad id");
                }
                var oldarticle = _context.articles.FirstOrDefault(a => a.Id == idme);
                var oldEmp = _context.employees.FirstOrDefault(a => a.Id == oldarticle.authoridme);

                oldEmp.Articles = Const.deleteArticle(oldEmp.Articles, idme.ToString());

                _context.Entry(oldEmp).State = EntityState.Modified;
                _context.articles.Remove(oldarticle);
                _context.SaveChanges();

                string success = "ContentDeleted";
                success = Const.GetValueFromDictionary(_context.languages.FirstOrDefault(a => a.Abbreviation.Equals(delmodel.LangAbr)).Content, ref success);
                return Json(new { success });
            }
            catch
            {
                string error = "DeleteContentError";
                error = Const.GetValueFromDictionary(_context.languages.FirstOrDefault(a => a.Abbreviation.Equals(delmodel.LangAbr)).Content, ref error);
                return Json(new { error });
            }
        }
    }
}