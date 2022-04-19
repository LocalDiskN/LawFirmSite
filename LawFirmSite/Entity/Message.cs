using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LawFirmSite.Entity
{
    public class Message
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Content { get; set; }
    }
}