using LawFirmSite.Consts;
using LawFirmSite.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LawFirmSite.Models
{
    public class AnnouncementPageModel
    {
        public int idme { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public AnnouncementPageModel()
        {
            Title = "";
            Content = "";
        }
        public AnnouncementPageModel(Announcement copy, ref string LanguageAbbreviation)
        {
            idme = copy.Id;
            Title = Const.GetValueFromDictionary(copy.Title, ref LanguageAbbreviation);
            Content = Const.GetValueFromDictionary(copy.Content, ref LanguageAbbreviation);
        }
    }
}