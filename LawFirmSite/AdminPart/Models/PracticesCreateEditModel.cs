using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LawFirmSite.Models
{
    public class PracticesCreateEditModel
    {
        public string lang { get; set; }
        public int idme { get; set; }
        public string Align { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImgUrlBig { get; set; }
        public string ImgUrlSmall { get; set; }

        public PracticesCreateEditModel()
        {
            lang = "";
            Align = "";
            Title = "";
            Content = "";
            ImgUrlBig = "";
            ImgUrlSmall = "";
        }
    }
}