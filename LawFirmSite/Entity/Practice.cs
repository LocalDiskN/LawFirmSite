using LawFirmSite.Consts;
using LawFirmSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LawFirmSite.Entity
{
    public class Practice
    {
        public int Id { get; set; }
        public string Align { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImgUrlBig { get; set; }
        public string ImgUrlSmall { get; set; }

        public Practice()
        {
            Align = "";
            Title = "";
            Content = "";
            ImgUrlBig = "";
            ImgUrlSmall = "/Images/600x260.png";
        }
        public Practice(PracticesCreateEditModel copy)
        {
            Align = copy.Align;
            Title = Const.AddChangeLangValue("", copy.Title, copy.lang);
            Content = Const.AddChangeLangValue("", copy.Content, copy.lang);
            ImgUrlBig = copy.ImgUrlBig;
            ImgUrlSmall = copy.ImgUrlSmall;
        }
        public void equlize(PracticesCreateEditModel copy)
        {
            Align = copy.Align;
            Title = Const.AddChangeLangValue(Title, copy.Title, copy.lang);
            Content = Const.AddChangeLangValue(Content, copy.Content, copy.lang);
            ImgUrlBig = copy.ImgUrlBig;
            ImgUrlSmall = copy.ImgUrlSmall;
        }
    }
}