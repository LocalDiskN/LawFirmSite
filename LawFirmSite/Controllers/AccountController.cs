using LawFirmSite.Consts;
using LawFirmSite.CustomFunks;
using LawFirmSite.Entity;
using LawFirmSite.Identity;
using LawFirmSite.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LawFirmSite.Controllers
{
    public class AccountController : Controller
    {
        DataContext _context = new DataContext();
        private UserManager<ApplicationUser> UserManager;
        private RoleManager<ApplicationRole> RoleManager;

        public AccountController()
        {
            UserStore<ApplicationUser> userStore = new UserStore<ApplicationUser>(new DataContext());
            UserManager = new UserManager<ApplicationUser>(userStore);

            RoleStore<ApplicationRole> roleStore = new RoleStore<ApplicationRole>(new DataContext());
            RoleManager = new RoleManager<ApplicationRole>(roleStore);
        }

        // GET: Account
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = model.Username;
                user.Email = model.Email;

                IdentityResult result = UserManager.Create(user, model.Password);

                if (result.Succeeded)
                {
                    // Kullanıcı oluştu role ata
                    if (RoleManager.RoleExists("user"))
                    {
                        UserManager.AddToRole(user.Id, "user");
                    }

                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("RegisterUserError", "There was an error when registring");
                }
            }

            return View(model);
        }

        public ActionResult Login(string ReturnUrl, string lang)
        {
            string language = CookieFunks.GetLanguageCookie(lang);
            ViewBag.LayoutModel = new LayoutModel(_context.practices.ToList(), _context.contacts.ToList(), _context.languages.ToList(), language);
            Login model = new Login();
            if ((ReturnUrl != null))
            {
                model.ReturnUrl = ReturnUrl;
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model)
        {
            if (ModelState.IsValid)
            {
                var user = UserManager.Find(model.Username, model.Password);

                if (user != null)
                {
                    // varolan kullanıcıyı sisteme dahil et.
                    // ApplicationCookie oluşturup sisteme bırakarak

                    var authManager = HttpContext.GetOwinContext().Authentication;

                    var identityclaims = UserManager.CreateIdentity(user, "ApplicationCookie");
                    var authProperties = new AuthenticationProperties();
                    authProperties.IsPersistent = model.RememberMe;
                    authManager.SignIn(authProperties, identityclaims);

                    return Redirect(CookieFunks.redirectoItsPart(ref _context, user.UserName, model.ReturnUrl));
                }
                else
                {
                    ModelState.AddModelError("LoginUserError", "kullanıcı adı yada parola yanlış");
                }
            }
            string language = CookieFunks.GetLanguageCookie(model.lang);
            ViewBag.LayoutModel = new LayoutModel(_context.practices.ToList(), _context.contacts.ToList(), _context.languages.ToList(), language);

            return View(model);
        }

        [Authorize]
        public ActionResult Settings(string lang)
        {
            string language = CookieFunks.GetLanguageCookie(lang);
            ViewBag.LayoutModel = new LayoutModel(_context.practices.ToList(), _context.contacts.ToList(), _context.languages.ToList(), language);

            AccountEditModel model = new AccountEditModel();
            var user = _context.Users.FirstOrDefault(x => x.UserName.Equals(User.Identity.Name));
            model.Email = user.Email;

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Settings(AccountEditModel editmodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = UserManager.Find(User.Identity.Name, editmodel.Password);
                    if (user != null)
                    {
                        if(editmodel.Email != null && !editmodel.Email.Equals(""))
                        {
                            user.Email = editmodel.Email;
                        }
                        
                        
                        if (editmodel.NewPassword != null && !editmodel.NewPassword.Equals("") && editmodel.NewPassword.Equals(editmodel.PasswordAgain))
                        {
                            user.PasswordHash = UserManager.PasswordHasher.HashPassword(editmodel.NewPassword);
                        }

                        var result = UserManager.UpdateAsync(user);
                        if (!result.Result.Succeeded)
                        {
                            throw new System.InvalidOperationException("Bad id");
                        }
                    }
                    else
                    {
                        throw new System.InvalidOperationException("Bad id");
                    }
                    string success = "EditSuccess";
                    success = Const.GetValueFromDictionary(_context.languages.FirstOrDefault(a => a.Abbreviation.Equals(editmodel.lang)).Content, ref success);
                    return Json(new { success });
                }
                else
                {
                    throw new System.InvalidOperationException("Bad id");
                }
            }
            catch (Exception)
            {
                string error = "EditFail";
                error = Const.GetValueFromDictionary(_context.languages.FirstOrDefault(a => a.Abbreviation.Equals(editmodel.lang)).Content, ref error);
                return Json(new { error });
            }

        }

        public ActionResult Logout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();
            Session.Abandon();

            return RedirectToAction("Index", "Home");
        }
    }
}