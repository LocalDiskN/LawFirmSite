using LawFirmSite.AdminPart.Models;
using LawFirmSite.Consts;
using LawFirmSite.CustomFunks;
using LawFirmSite.Entity;
using LawFirmSite.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LawFirmSite.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        DataContext _context = new DataContext();
        public ActionResult Index(string lang)
        {
            string language = CookieFunks.GetLanguageCookie(lang);
            var languagelist = _context.languages.ToList();
            var layoutmodel = new LayoutModel(_context.practices.ToList(), _context.contacts.ToList(), languagelist, language);
            ViewBag.LayoutModel = layoutmodel;
            string datetime = "DateFormat";
            datetime = Const.GetValueFromDictionary(layoutmodel.languages, ref datetime);
            ControlPanelModel model = new ControlPanelModel(_context.abouts.ToList(), _context.practices.ToList(), _context.articles.ToList(), _context.announcements.ToList(), _context.employees.ToList(), languagelist, datetime, language);
            return View(model);
        }
        
        [Authorize]
        public ActionResult Translations(string lang)
        {
            string language = CookieFunks.GetLanguageCookie(lang);
            var model = _context.languages.ToList();
            var layoutmodel = new LayoutModel(_context.practices.ToList(), _context.contacts.ToList(), model, language);
            ViewBag.LayoutModel = layoutmodel;

            return View(model);
        }

        [Authorize]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Traslation(TranslationModel editmodel)
        {
            try
            {
                var langme = _context.languages.FirstOrDefault(a => a.Id == editmodel.idme);
                langme.equlize(editmodel);

                _context.Entry(langme).State = EntityState.Modified;
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
        public ActionResult TraslationCreate(DeleteModel createmodel)
        {
            try
            {
                var newcon = new Language();
                newcon.Title = createmodel.NameOrid;
                newcon.Abbreviation = "new";

                _context.languages.Add(newcon);
                _context.SaveChanges();

                createmodel.NameOrid = _context.languages.OrderByDescending(a => a.Id).FirstOrDefault().Id.ToString();

                string success = "EditSuccess";
                createmodel.LangAbr = Const.GetValueFromDictionary(_context.languages.FirstOrDefault(a => a.Abbreviation.Equals(createmodel.LangAbr)).Content, ref success);
                return Json(new { createmodel });
            }
            catch
            {
                string error = "CreateContentError";
                error = Const.GetValueFromDictionary(_context.languages.FirstOrDefault(a => a.Abbreviation.Equals(createmodel.LangAbr)).Content, ref error);
                return Json(new { error });
            }
        }

        [Authorize]
        [HttpPost]
        public ActionResult TraslationDelete(DeleteModel delmodel)
        {
            try
            {
                int idme = 0;
                if (!int.TryParse(delmodel.NameOrid, out idme))
                {
                    throw new System.InvalidOperationException("Bad id");
                }
                var contactme = _context.languages.FirstOrDefault(a => a.Id == idme);
                _context.languages.Remove(contactme);

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