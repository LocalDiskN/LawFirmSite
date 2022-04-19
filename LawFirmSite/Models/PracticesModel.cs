using LawFirmSite.Consts;
using LawFirmSite.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LawFirmSite.Models
{
    public class PracticesModel
    {
        public int idme { get; set; }
        public string Title { get; set; }
        public string ImgUrl { get; set; }

        public PracticesModel()
        {
            Title = "";
            ImgUrl = "";
        }
        public PracticesModel(Practice copy, ref string LanguageAbbreviation)
        {
            idme = copy.Id;
            Title = Const.GetValueFromDictionary(copy.Title, ref LanguageAbbreviation);
            ImgUrl = copy.ImgUrlSmall;
        }
    }
}