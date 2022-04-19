using LawFirmSite.Consts;
using LawFirmSite.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LawFirmSite.Models
{
    public class AboutModel
    {
        public int idme { get; set; }
        public string Align { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImgUrl { get; set; }

        public AboutModel()
        {
            idme = 0;
            Align = "";
            Title = "";
            Content = "";
            ImgUrl = "";
        }
        public AboutModel(About copy, ref string LanguageAbbreviation)
        {
            idme = copy.Id;
            Align = copy.Align;
            Title = Const.GetValueFromDictionary(copy.Title, ref LanguageAbbreviation);
            Content = Const.GetValueFromDictionary(copy.Content, ref LanguageAbbreviation);
            ImgUrl = copy.ImgUrl;
        }
    }
}