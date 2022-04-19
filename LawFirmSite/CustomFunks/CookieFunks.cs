using LawFirmSite.Consts;
using LawFirmSite.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace LawFirmSite.CustomFunks
{
    public static class CookieFunks
    {
        public static bool visitedBefore(string ids, int id)
        {
            if (ids != null)
            {
                int backit = 0;
                int it = -Const.keySeparator.Length;
                int idsLength = ids.Count();
                for (; (it + Const.keySeparator.Length) < idsLength;)
                {
                    backit = it + Const.keySeparator.Length;
                    it = ids.IndexOf(Const.keySeparator, backit);
                    if (it == -1)
                    {
                        break;
                    }

                    if (int.TryParse(ids.Substring(backit, it - backit), out int tempid))
                    {
                        if (tempid == id)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public static string GetLanguageCookie(string langAbr)
        {
            if (HttpContext.Current != null)
            {
                HttpRequest Request = HttpContext.Current.Request;
                HttpResponse Response = HttpContext.Current.Response;
                if (Request.Cookies["CAVLanguage"] != null)
                {
                    string oldlang = HttpContext.Current.Server.HtmlEncode(Request.Cookies["CAVLanguage"].Value);
                    if(oldlang.Equals(langAbr) || langAbr == null || langAbr.Equals(""))
                    {
                        if(oldlang == null || oldlang.Equals(""))
                        {
                            Response.Cookies["CAVLanguage"].Value = "tur";
                            Response.Cookies["CAVLanguage"].Expires = DateTime.Now.AddDays(7);
                            return "tur";
                        }
                        return oldlang;
                    }
                }
                if (langAbr == null || langAbr.Equals(""))
                {
                    langAbr = "tur";
                }
                Response.Cookies["CAVLanguage"].Value = langAbr;
                Response.Cookies["CAVLanguage"].Expires = DateTime.Now.AddDays(7);
            }
            return langAbr;
        }

        public static int ratedBefore(ref string ids, int BlogId, int newRating)
        {
            if (ids != null)
            {
                int backit = 0;
                int it = -Const.keySeparator.Length;
                int idsLength = ids.Count();
                for (; (it + Const.keySeparator.Length) < idsLength;)
                {
                    backit = it + Const.keySeparator.Length;
                    it = ids.IndexOf(Const.sectionSeparator, backit);

                    if (it == -1)
                    {
                        break;
                    }

                    if (int.TryParse(ids.Substring(backit, it - backit), out int tempid))
                    {
                        if (tempid == BlogId)
                        {
                            backit = it + Const.sectionSeparator.Length;
                            it = ids.IndexOf(Const.keySeparator, backit);
                            if (int.TryParse(ids.Substring(backit, it - backit), out int rating))
                            {
                                ids = ids.Substring(0, backit) + newRating.ToString() + ids.Substring(it);
                                return rating;
                            }
                            return -1;
                        }
                        it = ids.IndexOf(Const.keySeparator, backit);
                    }
                }
            }
            ids += BlogId.ToString() + Const.sectionSeparator + newRating.ToString() + Const.keySeparator;
            return -1;
        }
        public static string redirectoItsPart(ref DataContext _context, string username, string backingurl = "")
        {
            var user = _context.Users.FirstOrDefault(a => a.UserName.Equals(username));
            //var userrole = _context.Roles.FirstOrDefault(a => a.Name.Equals("user")).Id;
            //var authorrole = _context.Roles.FirstOrDefault(a => a.Name.Equals("author")).Id;
            var adminrrole = _context.Roles.FirstOrDefault(a => a.Name.Equals("admin")).Id;


            if (user.Roles.Select(a => a.RoleId).Contains(adminrrole))
            {
                if ((backingurl != null) && (!backingurl.Equals("")))
                {
                    return ConfigurationManager.AppSettings["MyWebSite"] + backingurl;
                }
                return ConfigurationManager.AppSettings["MyWebSite"] + "/Home/Index/";
            }
            else
            {
                if ((backingurl != null) && (!backingurl.Equals("")))
                {
                    return ConfigurationManager.AppSettings["MyWebSite"] + backingurl;
                }
                return ConfigurationManager.AppSettings["MyWebSite"] + "/Home/Index/";
            }
        }
    }
}