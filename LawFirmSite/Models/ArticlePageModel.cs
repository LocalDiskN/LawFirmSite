using LawFirmSite.Consts;
using LawFirmSite.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LawFirmSite.Models
{
    public class ArticlePageModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string AuthFullname { get; set; }
        public int Authid { get; set; }

        public ArticlePageModel()
        {
            Title = "";
            Content = "";
            AuthFullname = "";
        }
        public ArticlePageModel(Article copy, ref string LanguageAbbreviation)
        {
            Authid = copy.authoridme;
            Title = Const.GetValueFromDictionary(copy.Title, ref LanguageAbbreviation);
            Content = Const.GetValueFromDictionary(copy.Content, ref LanguageAbbreviation);
            AuthFullname = Const.GetValueFromDictionary(copy.AuthorTitle, ref LanguageAbbreviation) + " " + copy.AuthorFullName;
        }
    }
}