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
using static LawFirmSite.Models.EmployeeCreateEditModel;

namespace LawFirmSite.Controllers
{
    public class TeamController : Controller
    {
        DataContext _context = new DataContext();
        // GET: Team
        public ActionResult Index(string lang)
        {
            string language = CookieFunks.GetLanguageCookie(lang);
            ViewBag.LayoutModel = new LayoutModel(_context.practices.ToList(), _context.contacts.ToList(), _context.languages.ToList(), language);
            var model = _context.employees.Where(a => a.isVisible).ToList().Select(a => new TeamModel(a, ref language)).ToList();
            return View(model);
        }

        public ActionResult Profileme(string id, string lang)
        {
            int idme = 0;
            if (!int.TryParse(id, out idme))
            {
                return RedirectToAction("Index", "Team");
            }
            string language = CookieFunks.GetLanguageCookie(lang);
            ViewBag.LayoutModel = new LayoutModel(_context.practices.ToList(), _context.contacts.ToList(), _context.languages.ToList(), language);
            var model = new EmployeeModel(_context.employees.FirstOrDefault(a => a.Id == idme), ref language);
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
                    var folder = Server.MapPath("~/Images/Profile");
                    string[] pdfFiles = Directory.GetFiles(Server.MapPath("~/Images/Profile"), "*");
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
            if ((delmodel.NameOrid != null) && (delmodel.NameOrid.Length > 0) && !delmodel.NameOrid.Equals("300x400.png"))
            {
                var isused = _context.abouts.FirstOrDefault(a => a.ImgUrl.Equals("/Images/Profile/" + delmodel.NameOrid));
                if (isused == null)
                {
                    var isused2 = _context.practices.FirstOrDefault(a => a.ImgUrlBig.Equals("/Images/Profile/" + delmodel.NameOrid));
                    if (isused2 == null)
                    {
                        var folder = Server.MapPath("~/Images/Profile");

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
            string[] pdfFiles = Directory.GetFiles(Server.MapPath("~/Images/Profile"), "*");
            for (int i = 0; i < pdfFiles.Length; i++)
            {
                pdfFiles[i] = Path.GetFileName(pdfFiles[i]);
            }
            return View(pdfFiles);
        }

        [Authorize]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(EmployeeCreateEditModel model)
        {
            try
            {
                var newEmployee = new Employee(model);
                _context.employees.Add(newEmployee);
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
                return RedirectToAction("Index", "Team");
            }
            string language = CookieFunks.GetLanguageCookie(lang);
            ViewBag.LayoutModel = new LayoutModel(_context.practices.ToList(), _context.contacts.ToList(), _context.languages.ToList(), language);
            string[] pdfFiles = Directory.GetFiles(Server.MapPath("~/Images/Profile"), "*");
            for (int i = 0; i < pdfFiles.Length; i++)
            {
                pdfFiles[i] = Path.GetFileName(pdfFiles[i]);
            }
            ViewBag.ImagesAvailable = pdfFiles;
            string datetimeformat = "DateFormat";
            datetimeformat = Const.GetValueFromDictionary(_context.languages.FirstOrDefault(a => a.Abbreviation.Equals(language)).Content, ref datetimeformat);
            var model = new EmployeeCreateEditModel(_context.employees.FirstOrDefault(a => a.Id == idme), datetimeformat, ref language);
            return View(model);
        }

        [Authorize]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(EmployeeCreateEditModel editmodel)
        {
            try
            {
                var aboutme = _context.employees.FirstOrDefault(a => a.Id == editmodel.idme);

                List<string> articleids = Const.getValuesasList(aboutme.Articles);

                for (int i = 0; i < articleids.Count; i++)
                {
                    int artid = 0;
                    if(int.TryParse(articleids[i], out artid))
                    {
                        var articleme = _context.articles.FirstOrDefault(a => a.Id == artid);
                        articleme.AuthorFullName = editmodel.Name + " " + editmodel.Surname;
                        articleme.AuthorTitle = Const.AddChangeLangValue(articleme.AuthorTitle, editmodel.TitleAbbr, editmodel.lang);
                        _context.Entry(articleme).State = EntityState.Modified;
                    }
                    
                }

                aboutme.equlize(editmodel);

                _context.Entry(aboutme).State = EntityState.Modified;
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
                var oldabout = _context.employees.FirstOrDefault(a => a.Id == idme);
                List<string> artlist = Const.getValuesasList(oldabout.Articles);
                for (int i = 0; i < artlist.Count; i++)
                {
                    _context.articles.Remove(_context.articles.FirstOrDefault(a => a.Id.ToString().Equals(artlist[i])));
                }
                _context.employees.Remove(oldabout);
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