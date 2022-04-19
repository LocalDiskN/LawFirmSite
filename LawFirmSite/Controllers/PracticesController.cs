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
    public class PracticesController : Controller
    {
        DataContext _context = new DataContext();
        // GET: Practices
        public ActionResult Index(string lang)
        {
            string language = CookieFunks.GetLanguageCookie(lang);
            ViewBag.LayoutModel = new LayoutModel(_context.practices.ToList(), _context.contacts.ToList(), _context.languages.ToList(), language);
            List<PracticesModel> model = _context.practices.ToList().Select(a => new PracticesModel(a, ref language)).ToList();
            return View(model);
        }
        public ActionResult Practice(string id, string lang)
        {
            int idme = 0;
            if (!int.TryParse(id, out idme))
            {
                return RedirectToAction("Index", "Practices");
            }
            string language = CookieFunks.GetLanguageCookie(lang);
            ViewBag.LayoutModel = new LayoutModel(_context.practices.ToList(), _context.contacts.ToList(), _context.languages.ToList(), language);
            var model = new PracticePageModel(_context.practices.FirstOrDefault(a => a.Id == idme), ref language);
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult UploadImageBig(HttpPostedFileBase imgfile)
        {
            string filename = "";

            if ((imgfile != null) && (imgfile.ContentLength > 0))
            {
                var extensition = Path.GetExtension(imgfile.FileName);

                if (extensition.Equals(".jpg") || extensition.Equals(".png"))
                {
                    var folder = Server.MapPath("~/Images/PracticeNAbout");
                    string[] pdfFiles = Directory.GetFiles(Server.MapPath("~/Images/PracticeNAbout"), "*");
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
        public ActionResult DeleteImageBig(DeleteModel delmodel)
        {
            if ((delmodel.NameOrid != null) && (delmodel.NameOrid.Length > 0) && !delmodel.NameOrid.Equals("400x700.png"))
            {
                var isused = _context.abouts.FirstOrDefault(a => a.ImgUrl.Equals("/Images/PracticeNAbout/" + delmodel.NameOrid));
                if (isused == null)
                {
                    var isused2 = _context.practices.FirstOrDefault(a => a.ImgUrlBig.Equals("/Images/PracticeNAbout/" + delmodel.NameOrid));
                    if (isused2 == null)
                    {
                        var folder = Server.MapPath("~/Images/PracticeNAbout");

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
        [HttpPost]
        public ActionResult UploadImageSmall(HttpPostedFileBase imgfile)
        {
            string filename = "";

            if ((imgfile != null) && (imgfile.ContentLength > 0))
            {
                var extensition = Path.GetExtension(imgfile.FileName);

                if (extensition.Equals(".jpg") || extensition.Equals(".png"))
                {
                    var folder = Server.MapPath("~/Images/Practices");
                    string[] pdfFiles = Directory.GetFiles(Server.MapPath("~/Images/Practices"), "*");
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
        public ActionResult DeleteImageSmall(DeleteModel delmodel)
        {
            if ((delmodel.NameOrid != null) && (delmodel.NameOrid.Length > 0) && !delmodel.NameOrid.Equals("600x260.png"))
            {
                var isused = _context.abouts.FirstOrDefault(a => a.ImgUrl.Equals("/Images/Practices/" + delmodel.NameOrid));
                if (isused == null)
                {
                    var isused2 = _context.practices.FirstOrDefault(a => a.ImgUrlBig.Equals("/Images/Practices/" + delmodel.NameOrid));
                    if (isused2 == null)
                    {
                        var folder = Server.MapPath("~/Images/Practices");

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
            PracticesCreateModel model = new PracticesCreateModel();
            model.AvailableBigImages = Directory.GetFiles(Server.MapPath("~/Images/PracticeNAbout"), "*");
            for (int i = 0; i < model.AvailableBigImages.Length; i++)
            {
                model.AvailableBigImages[i] = Path.GetFileName(model.AvailableBigImages[i]);
            }
            model.AvailableSmallImages = Directory.GetFiles(Server.MapPath("~/Images/Practices"), "*");
            for (int i = 0; i < model.AvailableSmallImages.Length; i++)
            {
                model.AvailableSmallImages[i] = Path.GetFileName(model.AvailableSmallImages[i]);
            }
            return View(model);
        }

        [Authorize]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(PracticesCreateEditModel model)
        {
            string language = CookieFunks.GetLanguageCookie(model.lang);
            ViewBag.LayoutModel = new LayoutModel(_context.practices.ToList(), _context.contacts.ToList(), _context.languages.ToList(), language);
            try
            {
                var newPractice = new Practice(model);
                _context.practices.Add(newPractice);
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
                return RedirectToAction("Index", "Practices");
            }
            string language = CookieFunks.GetLanguageCookie(lang);
            ViewBag.LayoutModel = new LayoutModel(_context.practices.ToList(), _context.contacts.ToList(), _context.languages.ToList(), language);

            PracticesEditModel model = new PracticesEditModel(_context.practices.FirstOrDefault(a => a.Id == idme), ref language);
            model.AvailableBigImages = Directory.GetFiles(Server.MapPath("~/Images/PracticeNAbout"), "*");
            for (int i = 0; i < model.AvailableBigImages.Length; i++)
            {
                model.AvailableBigImages[i] = Path.GetFileName(model.AvailableBigImages[i]);
            }
            model.AvailableSmallImages = Directory.GetFiles(Server.MapPath("~/Images/Practices"), "*");
            for (int i = 0; i < model.AvailableSmallImages.Length; i++)
            {
                model.AvailableSmallImages[i] = Path.GetFileName(model.AvailableSmallImages[i]);
            }
            return View(model);
        }

        [Authorize]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(PracticesCreateEditModel editmodel)
        {
            try
            {
                var aboutme = _context.practices.FirstOrDefault(a => a.Id == editmodel.idme);

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
                var oldpractice = _context.practices.FirstOrDefault(a => a.Id == idme);
                _context.practices.Remove(oldpractice);
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