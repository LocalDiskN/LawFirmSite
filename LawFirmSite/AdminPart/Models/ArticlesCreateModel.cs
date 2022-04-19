using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LawFirmSite.Models
{
    public class ArticlesCreateModel
    {
        public string[] AvailableImageUrls { get; set; }
        public string[] AuthnamesNids { get; set; }
    }
}