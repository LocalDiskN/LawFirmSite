using LawFirmSite.Consts;
using LawFirmSite.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LawFirmSite.Models
{
    public class ContactEditModel
    {
        public string lang { get; set; }
        public int idme { get; set; }
        public string Title { get; set; }
        public string Cicon { get; set; }
        public string Contents { get; set; }

        public ContactEditModel()
        {
            lang = "eng";
            Title = "";
            Cicon = "";
            Contents = "";
        }
    }
}