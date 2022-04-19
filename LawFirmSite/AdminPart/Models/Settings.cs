using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LawFirmSite.AdminPart.Models
{
    public class Settings
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string NewPassword { get; set; }
        public string reNewPassword { get; set; }
        public string Password { get; set; }
    }
}