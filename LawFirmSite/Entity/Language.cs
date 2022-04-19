using LawFirmSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LawFirmSite.Entity
{
    public class Language
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Abbreviation { get; set; }

        public string Content { get; set; }

        public Language()
        {
            Title = "";
            Abbreviation = "";
            Content = "";
        }

        public void equlize(TranslationModel copy)
        {
            Title = copy.Title;
            Abbreviation = copy.Abbreviation;
            Content = copy.Content;
        }
    }
}