using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LawFirmSite.Models
{
    public class EditAboutModel
    {
        public string lang { get; set; }
        public int idme { get; set; }
        public string Align { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImgUrl { get; set; }

        public EditAboutModel()
        {
            lang = "";
            Align = "";
            Title = "";
            Content = "";
            ImgUrl = "";
        }
    }
}