using LawFirmSite.Consts;
using LawFirmSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LawFirmSite.Entity
{
    public class ContactInfo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Contents { get; set; }
        public string Cicon { get; set; }

        public ContactInfo()
        {
            Title = "";
            Contents = "";
            Cicon = "";
        }

        public void equlize(ContactEditModel copy)
        {
            Title = Const.AddChangeLangValue(Title, copy.Title, copy.lang);
            Contents = copy.Contents;
            Cicon = copy.Cicon;
        }
    }
}