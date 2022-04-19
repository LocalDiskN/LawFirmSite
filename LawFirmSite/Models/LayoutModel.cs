using LawFirmSite.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LawFirmSite.Models
{
    public class LayoutModel
    {
        public List<PracticesModel> practices { get; set; }
        public List<ContactModel> contacts { get; set; }
        public List<LanguageModel> languages { get; set; }

        public LayoutModel(List<Practice> practicess, List<ContactInfo> contactss, List<Language> languagess, string LanguageAbr)
        {
            practices = practicess.Select(a => new PracticesModel(a, ref LanguageAbr)).ToList();
            contacts = contactss.Select(a => new ContactModel(a, ref LanguageAbr)).ToList();
            languages = languagess.Select(a => new LanguageModel(a, ref LanguageAbr)).ToList();
        }
    }
}