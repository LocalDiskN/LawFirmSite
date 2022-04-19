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

namespace LawFirmSite.Controllers
{
    public class AnnouncementsController : Controller
    {
        DataContext _context = new DataContext();
        // GET: Announcements
        public ActionResult Index(string lang)
        {
            string language = CookieFunks.GetLanguageCookie(lang);
            ViewBag.LayoutModel = new LayoutModel(_context.practices.ToList(), _context.contacts.ToList(), _context.languages.ToList(), language);
            var model = _context.announcements.ToList().Select(a => new AnnouncementsModel(a, ref language)).ToList();
            return View(model);
        }
        public ActionResult Announcement(string id, string lang)
        {
            int idme = 0;
            if (!int.TryParse(id, out idme))
            {
                return RedirectToAction("Index", "Announcements");
            }
            string language = CookieFunks.GetLanguageCookie(lang);
            ViewBag.LayoutModel = new LayoutModel(_context.practices.ToList(), _context.contacts.ToList(), _context.languages.ToList(), language);
            var model = new AnnouncementPageModel(_context.announcements.FirstOrDefault(a => a.Id == idme), ref language);
            return View(model);
        }

        [Authorize]
        public ActionResult Create(string lang)
        {
            string language = CookieFunks.GetLanguageCookie(lang);
            ViewBag.LayoutModel = new LayoutModel(_context.practices.ToList(), _context.contacts.ToList(), _context.languages.ToList(), language);
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(AnnouncementCreateEditModel modelthis)
        {
            try
            {
                var newAnnounce = new Announcement(modelthis);
                _context.announcements.Add(newAnnounce);
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
                return RedirectToAction("Index", "Announcements");
            }
            string language = CookieFunks.GetLanguageCookie(lang);
            ViewBag.LayoutModel = new LayoutModel(_context.practices.ToList(), _context.contacts.ToList(), _context.languages.ToList(), language);
            var model = new AnnouncementCreateEditModel(_context.announcements.FirstOrDefault(a => a.Id == idme), ref language);
            return View(model);
        }

        [Authorize]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(AnnouncementCreateEditModel editmodel)
        {
            string language = CookieFunks.GetLanguageCookie(editmodel.lang);
            ViewBag.LayoutModel = new LayoutModel(_context.practices.ToList(), _context.contacts.ToList(), _context.languages.ToList(), language);
            try
            {
                var announceme = _context.announcements.FirstOrDefault(a => a.Id == editmodel.idme);

                announceme.equlize(editmodel);

                _context.Entry(announceme).State = EntityState.Modified;
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
                var oldannounce = _context.announcements.FirstOrDefault(a => a.Id == idme);
                _context.announcements.Remove(oldannounce);
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
