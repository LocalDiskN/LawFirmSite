using LawFirmSite.Consts;
using LawFirmSite.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LawFirmSite.Models
{
    public class EmployeeModel
    {
        public int idme { get; set; }
        public string Title { get; set; }

        public string Explanation { get; set; }
        public string Explanation2 { get; set; }
        public string FullName { get; set; }

        public string ImgUrl { get; set; }

        public EmployeeModel()
        {
            Title = "";
            Explanation = "";
            Explanation2 = "";
            FullName = "";
            ImgUrl = "";
        }

        public EmployeeModel(Employee copy, ref string LanguageAbbreviation)
        {
            idme = copy.Id;
            ImgUrl = copy.ImgUrl;
            Title = Const.GetValueFromDictionary(copy.Title, ref LanguageAbbreviation);
            FullName = copy.IDInfo.Name + " " + copy.IDInfo.Surname;
            Explanation = Const.GetValueFromDictionary(copy.Explanation, ref LanguageAbbreviation);
            Explanation2 = Const.GetValueFromDictionary(copy.Explanation2, ref LanguageAbbreviation);
        }
    }
}