using LawFirmSite.Consts;
using LawFirmSite.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LawFirmSite.Models
{
    public class AnnouncementCreateEditModel
    {
        public string lang { get; set; }
        public int idme { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public AnnouncementCreateEditModel()
        {
            lang = "";
            Title = "";
            Content = "";
        }
        public AnnouncementCreateEditModel(Announcement copy, ref string LanguageAbbreviation)
        {
            lang = LanguageAbbreviation;
            idme = copy.Id;
            Title = Const.GetValueFromDictionary(copy.Title, ref LanguageAbbreviation);
            Content = Const.GetValueFromDictionary(copy.Content, ref LanguageAbbreviation);
        }
    }
}