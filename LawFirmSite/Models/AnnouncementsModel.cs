using LawFirmSite.Consts;
using LawFirmSite.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LawFirmSite.Models
{
    public class AnnouncementsModel
    {
        public int idme { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }

        public AnnouncementsModel()
        {
            Title = "";
            Summary = "";
        }
        public AnnouncementsModel(Announcement copy, ref string LanguageAbbreviation)
        {
            idme = copy.Id;
            Title = Const.GetValueFromDictionary(copy.Title, ref LanguageAbbreviation);
            if(Title.Length > 180)
            {
                Title = Title.Remove(177) + "...";
                Summary = "";
            }
            else
            {
                Summary = Const.GetValueFromDictionary(copy.Content, ref LanguageAbbreviation);
                if((int)(Title.Length * 2.1) + Summary.Length > 320)
                {
                    Summary = Summary.Remove(Math.Max(0, 317 - (int)(Title.Length * 2.1))) + "...";
                }
            }
            
        }
    }
}