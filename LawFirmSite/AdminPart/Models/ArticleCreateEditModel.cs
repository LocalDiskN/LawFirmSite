using LawFirmSite.Consts;
using LawFirmSite.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LawFirmSite.Models
{
    public class ArticleCreateEditModel
    {
        public string lang { get; set; }
        public int idme { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImgUrl { get; set; }

        public string[] AuthnamesNids { get; set; }
        public string[] AvailableImageUrls { get; set; }

        public int Authid { get; set; }

        public ArticleCreateEditModel()
        {
            lang = "";
            Title = "";
            Content = "";
            ImgUrl = "";
        }
        public ArticleCreateEditModel(Article copy, ref string LanguageAbbreviation)
        {
            idme = copy.Id;
            Title = Const.GetValueFromDictionary(copy.Title, ref LanguageAbbreviation);
            Content = Const.GetValueFromDictionary(copy.Content, ref LanguageAbbreviation);

            ImgUrl = copy.ImgUrl;
            Authid = copy.authoridme;
        }
    }
}