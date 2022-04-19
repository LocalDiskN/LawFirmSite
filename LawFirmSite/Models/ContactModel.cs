using LawFirmSite.Consts;
using LawFirmSite.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LawFirmSite.Models
{
    public class ContactModel
    {
        public int idme { get; set; }
        public string Title { get; set; }
        public string Cicon { get; set; }
        public List<string> Contents { get; set; }

        public ContactModel()
        {
            Title = "";
            Cicon = "";
            Contents = new List<string>();
        }
        public ContactModel(ContactInfo copy, ref string LanguageAbbreviation)
        {
            idme = copy.Id;
            Title = Const.GetValueFromDictionary(copy.Title, ref LanguageAbbreviation);
            Contents = Const.getValuesasList(copy.Contents);
            Cicon = copy.Cicon;
        }
    }
}