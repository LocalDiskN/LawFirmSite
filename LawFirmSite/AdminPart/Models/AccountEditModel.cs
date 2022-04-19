using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LawFirmSite.Models
{
    public class AccountEditModel
    {
        public string lang { get; set; }
        public string Email { get; set; }
        public string NewPassword { get; set; }
        public string PasswordAgain { get; set; }
        public string Password { get; set; }
    }
}