using LawFirmSite.Consts;
using LawFirmSite.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LawFirmSite.Models
{
    public class ArticlesModel
    {
        public int idme { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string ImgUrl { get; set; }
        public string AuthFullname { get; set; }
        public int Authid { get; set; }

        public ArticlesModel()
        {
            Title = "";
            Summary = "";
            ImgUrl = "/Images/300x300.png";
            AuthFullname = "";
        }

        public ArticlesModel(Article copy, ref string LanguageAbbreviation)
        {
            idme = copy.Id;
            Title = Const.GetValueFromDictionary(copy.Title, ref LanguageAbbreviation);
            if (Title.Length > 375)
            {
                Title = Title.Remove(372) + "...";
                Summary = "...";
            }
            else
            {
                Summary = Const.GetValueFromDictionary(copy.Content, ref LanguageAbbreviation);
                if ((int)(Title.Length * 2.1) + Summary.Length > 500)
                {
                    Summary = Summary.Remove(Math.Max(0, 497 - (int)(Title.Length * 2.1))) + "...";
                }
            }
            ImgUrl = copy.ImgUrl;
            AuthFullname = Const.GetValueFromDictionary(copy.AuthorTitle, ref LanguageAbbreviation) + " " + copy.AuthorFullName;
            Authid = copy.authoridme;
        }
    }
}