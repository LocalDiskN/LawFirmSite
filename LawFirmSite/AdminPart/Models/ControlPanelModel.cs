using LawFirmSite.Entity;
using LawFirmSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LawFirmSite.AdminPart.Models
{
    public class ControlPanelModel
    {
        public List<AboutModel> abouts { get; set; }
        public List<PracticesModel> practices { get; set; }
        public List<ArticlesModel> articles { get; set; }
        public List<AnnouncementsModel> announcements { get; set; }
        public List<EmployeeCreateEditModel> employees { get; set; }
        public List<Language> languages { get; set; }

        public ControlPanelModel()
        {
            abouts = new List<AboutModel>();
            practices = new List<PracticesModel>();
            articles = new List<ArticlesModel>();
            announcements = new List<AnnouncementsModel>();
            employees = new List<EmployeeCreateEditModel>();
            languages = new List<Language>();
        }

        public ControlPanelModel(List<About> aboutlist, List<Practice> practicelist, List<Article> articlelist, List<Announcement> announcementlist, List<Employee> employeelist, List<Language> languagess, string dateformat, string langabr)
        {
            abouts = aboutlist.Select(a => new AboutModel(a, ref langabr)).ToList();
            practices = practicelist.Select(a => new PracticesModel(a, ref langabr)).ToList();
            articles = articlelist.Select(a => new ArticlesModel(a, ref langabr)).ToList();
            announcements = announcementlist.Select(a => new AnnouncementsModel(a, ref langabr)).ToList();
            employees = employeelist.Select(a => new EmployeeCreateEditModel(a, dateformat, ref langabr)).ToList();
            languages = languagess;
        }
    }
}