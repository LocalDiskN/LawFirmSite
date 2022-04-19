using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LawFirmSite.Models
{
    public class Login
    {
        public string lang { get; set; }

        [Required]
        [DisplayName("Kullanıcı adı")]
        public string Username { get; set; }

        [Required]
        [DisplayName("Parola")]
        public string Password { get; set; }

        [DisplayName("Beni Hatırla")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}