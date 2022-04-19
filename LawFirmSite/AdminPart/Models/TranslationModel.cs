using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LawFirmSite.Models
{
    public class TranslationModel
    {
        public int idme { get; set; }
        public string lang { get; set; }
        public string Title { get; set; }
        public string Abbreviation { get; set; }

        public string Content { get; set; }

        public TranslationModel()
        {
            lang = "";
            Title = "";
            Abbreviation = "";
            Content = "";
        }
    }
}