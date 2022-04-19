using LawFirmSite.Consts;
using LawFirmSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LawFirmSite.Entity
{
    public class About
    {
        public int Id { get; set; }
        public string Align { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImgUrl { get; set; }

        public About()
        {
            Align = "";
            Title = "";
            Content = "";
            ImgUrl = "";
        }
        public About(AboutCreateEditModel model)
        {
            Align = model.alignment;
            Title = Const.AddChangeLangValue("", model.title, model.lang);
            Content = Const.AddChangeLangValue("", model.body, model.lang);
            ImgUrl = model.imgUrl;
        }

        public void equlize(EditAboutModel copy)
        {
            Align = copy.Align;
            Title = Const.AddChangeLangValue(Title, copy.Title, copy.lang);
            Content = Const.AddChangeLangValue(Content, copy.Content, copy.lang);
            ImgUrl = copy.ImgUrl;
        }
    }
}