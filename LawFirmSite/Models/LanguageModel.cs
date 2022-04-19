using LawFirmSite.Consts;
using LawFirmSite.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LawFirmSite.Models
{
    public class LanguageModel
    {
        public int idme { get; set; }
        public string Title { get; set; }
        public string Abbreviation { get; set; }

        public string Content { get; set; }

        public LanguageModel()
        {
            Title = "";
            Abbreviation = "";
            Content = "";
        }
        public LanguageModel(Language copy, ref string LanguageAbbreviation)
        {
            idme = copy.Id;
            Title = copy.Title;
            Abbreviation = copy.Abbreviation;
            if (copy.Abbreviation.Equals(LanguageAbbreviation))
            {
                Content = copy.Content;
            }
            else
            {
                Content = "";
            }

        }
    }
}