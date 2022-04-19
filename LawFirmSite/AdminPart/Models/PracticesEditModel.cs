using LawFirmSite.Consts;
using LawFirmSite.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LawFirmSite.Models
{
    public class PracticesEditModel
    {
        public string[] AvailableBigImages { get; set; }
        public string[] AvailableSmallImages { get; set; }

        public int idme { get; set; }
        public string Align { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImgUrlBig { get; set; }
        public string ImgUrlSmall { get; set; }

        public PracticesEditModel()
        {
            Align = "";
            Title = "";
            Content = "";
            ImgUrlBig = "";
            ImgUrlSmall = "";
        }
        public PracticesEditModel(Practice copy, ref string lang)
        {
            idme = copy.Id;
            Align = copy.Align;
            Title = Const.GetValueFromDictionary(copy.Title, ref lang);
            Content = Const.GetValueFromDictionary(copy.Content, ref lang);
            ImgUrlBig = copy.ImgUrlBig;
            ImgUrlSmall = copy.ImgUrlSmall;
        }
    }
}