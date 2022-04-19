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
    public class AboutController : Controller
    {
        DataContext _context = new DataContext();
        // GET: About
        public ActionResult Index(string lang)
        {
            string language = CookieFunks.GetLanguageCookie(lang);
            ViewBag.LayoutModel = new LayoutModel(_context.practices.ToList(), _context.contacts.ToList(), _context.languages.ToList(), language);
            var model = _context.abouts.ToList().Select(a => new AboutModel(a, ref language)).ToList();
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
        public ActionResult DeleteImage(DeleteModel delmodel)
        {
            if ((delmodel.NameOrid != null) && (delmodel.NameOrid.Length > 0) && !delmodel.NameOrid.Equals("400x700.png"))
            {
                var isused = _context.abouts.FirstOrDefault(a => a.ImgUrl.Equals("/Images/PracticeNAbout/" + delmodel.NameOrid));
                if(isused == null)
                {
                    var isused2 = _context.practices.FirstOrDefault(a => a.ImgUrlBig.Equals("/Images/PracticeNAbout/" + delmodel.NameOrid));
                    if(isused2 == null)
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
        public ActionResult Create(string lang)
        {
            string language = CookieFunks.GetLanguageCookie(lang);
            ViewBag.LayoutModel = new LayoutModel(_context.practices.ToList(), _context.contacts.ToList(), _context.languages.ToList(), language);
            string[] pdfFiles = Directory.GetFiles(Server.MapPath("~/Images/PracticeNAbout"), "*");
            for (int i = 0; i < pdfFiles.Length; i++)
            {
                pdfFiles[i] = Path.GetFileName(pdfFiles[i]);
            }
            return View(pdfFiles);
        }

        [Authorize]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(AboutCreateEditModel model)
        {
            try
            {
                var newAbout = new About(model);
                _context.abouts.Add(newAbout);
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
                return RedirectToAction("Index", "About");
            }
            string language = CookieFunks.GetLanguageCookie(lang);
            ViewBag.LayoutModel = new LayoutModel(_context.practices.ToList(), _context.contacts.ToList(), _context.languages.ToList(), language);
            string[] pdfFiles = Directory.GetFiles(Server.MapPath("~/Images/PracticeNAbout"), "*");
            for (int i = 0; i < pdfFiles.Length; i++)
            {
                pdfFiles[i] = Path.GetFileName(pdfFiles[i]);
            }
            ViewBag.ImagesAvailable = pdfFiles;
            var model = new AboutModel(_context.abouts.FirstOrDefault(a => a.Id == idme), ref language);
            return View(model);
        }

        [Authorize]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(EditAboutModel editmodel)
        {
            string language = CookieFunks.GetLanguageCookie(editmodel.lang);
            ViewBag.LayoutModel = new LayoutModel(_context.practices.ToList(), _context.contacts.ToList(), _context.languages.ToList(), language);
            try
            {
                var aboutme = _context.abouts.FirstOrDefault(a => a.Id == editmodel.idme);

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
                var oldabout = _context.abouts.FirstOrDefault(a => a.Id == idme);
                _context.abouts.Remove(oldabout);
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
