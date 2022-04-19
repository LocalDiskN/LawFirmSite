using LawFirmSite.Consts;
using LawFirmSite.Identity;
using LawFirmSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LawFirmSite.Entity
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImgUrl { get; set; }
        public string AuthorFullName { get; set; }
        public string AuthorTitle { get; set; }

        public int authoridme { get; set; }

        public Article()
        {
            Title = "";
            Content = "";
            ImgUrl = "/Images/300x300.png";
            AuthorFullName = "";
            AuthorTitle = "";
        }
        public Article(ArticleCreateEditModel modelthis, Employee Auth)
        {
            Title = Const.AddChangeLangValue("", modelthis.Title, modelthis.lang);
            Content = Const.AddChangeLangValue("", modelthis.Content, modelthis.lang);
            AuthorTitle = Auth.Title;
            AuthorFullName = Auth.IDInfo.Name + " " + Auth.IDInfo.Surname;
            ImgUrl = modelthis.ImgUrl;
            authoridme = Auth.Id;
        }

        public void equlize(ArticleCreateEditModel copy, Employee Auth)
        {
            Content = Const.AddChangeLangValue(Content, copy.Content, copy.lang);
            Title = Const.AddChangeLangValue(Title, copy.Title, copy.lang);
            ImgUrl = copy.ImgUrl;
            authoridme = Auth.Id;
            AuthorTitle = Auth.Title;
            AuthorFullName = Auth.IDInfo.Name + " " + Auth.IDInfo.Surname;
        }
    }
}