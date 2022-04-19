using LawFirmSite.CustomFunks;
using LawFirmSite.Entity;
using LawFirmSite.Models;
using LawFirmSite.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Configuration;
using System.Net.Mail;

namespace LawFirmSite.Controllers
{
    public class ContactController : Controller
    {
        DataContext _context = new DataContext();
        // GET: Contact
        public ActionResult Index(string lang)
        {
            string language = CookieFunks.GetLanguageCookie(lang);
            ViewBag.LayoutModel = new LayoutModel(_context.practices.ToList(), _context.contacts.ToList(), _context.languages.ToList(), language);
            return View();
        }

        [HttpPost]
        public ActionResult Index(EmailModel mail)
        {
            string language = CookieFunks.GetLanguageCookie(mail.lang);
            ViewBag.LayoutModel = new LayoutModel(_context.practices.ToList(), _context.contacts.ToList(), _context.languages.ToList(), language);

            string server = ConfigurationManager.AppSettings["server"];
            int port = int.Parse(ConfigurationManager.AppSettings["port"]);
            bool ssl = ConfigurationManager.AppSettings["ssl"].Equals("1");

            string from = ConfigurationManager.AppSettings["from"];
            string fromname = ConfigurationManager.AppSettings["fromname"];
            string password = ConfigurationManager.AppSettings["password"];
            string to = _context.Users.FirstOrDefault(a => a.UserName.Equals("admin")).Email;

            var client = new SmtpClient();
            client.Host = server;
            client.Port = port;
            client.EnableSsl = ssl;
            client.UseDefaultCredentials = true;
            client.Credentials = new System.Net.NetworkCredential(from, password);

            var email = new MailMessage();
            email.From = new MailAddress(from, fromname);
            email.To.Add(to);

            email.Subject = mail.Subject;
            email.IsBodyHtml = true;
            email.Body = $"ad soyad : {mail.FullName} \n konu: {mail.Subject} \n mesaj: {mail.Message} \n eposta: {mail.Email}";

            try
            {
                client.Send(email);
                ViewData["result"] = true;
            }
            catch (Exception)
            {

                ViewData["result"] = false;
            }


            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(DeleteModel createmodel)
        {
            try
            {
                var newcon = new ContactInfo();

                _context.contacts.Add(newcon);
                _context.SaveChanges();

                createmodel.NameOrid = _context.contacts.OrderByDescending(a => a.Id).FirstOrDefault().Id.ToString();

                string success = "ContentCreated";
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
        [ValidateInput(false)]
        public ActionResult Edit(ContactEditModel editmodel)
        {
            try
            {
                var contactme = _context.contacts.FirstOrDefault(a => a.Id == editmodel.idme);

                contactme.equlize(editmodel);

                _context.Entry(contactme).State = EntityState.Modified;
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
                int childid = delmodel.NameOrid.IndexOf("-");
                if(childid != -1)
                {
                    int mainid = 0;
                    if (!int.TryParse(delmodel.NameOrid.Substring(0, childid), out mainid))
                    {
                        throw new System.InvalidOperationException("Bad id");
                    }

                    if (!int.TryParse(delmodel.NameOrid.Substring(childid + 1), out childid))
                    {
                        throw new System.InvalidOperationException("Bad id");
                    }
                    var contactme = _context.contacts.FirstOrDefault(a => a.Id == mainid);
                    contactme.Contents = Const.deleteContact(contactme.Contents, childid);
                    _context.Entry(contactme).State = EntityState.Modified;
                }
                else
                {
                    int idme = 0;
                    if (!int.TryParse(delmodel.NameOrid, out idme))
                    {
                        throw new System.InvalidOperationException("Bad id");
                    }
                    var contactme = _context.contacts.FirstOrDefault(a => a.Id == idme);
                    _context.contacts.Remove(contactme);
                }

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