using LawFirmSite.Consts;
using LawFirmSite.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LawFirmSite.Models
{
    public class TeamModel
    {
        public int idme { get; set; }
        public string Fullname { get; set; }
        public string Title { get; set; }
        public string Job { get; set; }
        public string ImgUrl { get; set; }

        public TeamModel()
        {
            Fullname = "";
            Title = "";
            Job = "";
            ImgUrl = "/Images/300x400.png";
        }

        public TeamModel(Employee copy, ref string LanguageAbbreviation)
        {
            idme = copy.Id;
            Fullname = copy.IDInfo.Name + " " + copy.IDInfo.Surname;
            Title = Const.GetValueFromDictionary(copy.Title, ref LanguageAbbreviation);
            Job = Const.GetValueFromDictionary(copy.Job, ref LanguageAbbreviation);
            ImgUrl = copy.ImgUrl;
        }
    }
}