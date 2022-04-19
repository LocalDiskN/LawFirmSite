using LawFirmSite.Consts;
using LawFirmSite.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LawFirmSite.Models
{
    public class PracticePageModel
    {
        public string Align { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImgUrl { get; set; }

        public PracticePageModel()
        {
            Align = "";
            Title = "";
            Content = "";
            ImgUrl = "";
        }
        public PracticePageModel(Practice copy, ref string LanguageAbbreviation)
        {
            Align = copy.Align;
            Title = Const.GetValueFromDictionary(copy.Title, ref LanguageAbbreviation);
            Content = Const.GetValueFromDictionary(copy.Content, ref LanguageAbbreviation);
            ImgUrl = copy.ImgUrlBig;
        }
    }
}