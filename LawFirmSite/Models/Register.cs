using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LawFirmSite.Models
{
    public class Register
    {
        [Required]
        [DisplayName("Kullanıcı Adı")]
        public string Username { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Lütfen gerçek bir adres giriniz. Parola yenilemek için kullanılacaktır")]
        public string Email { get; set; }
        [Required]
        [DisplayName("Parola")]
        public string Password { get; set; }
        [Required]
        [DisplayName("Parola Yeniden")]
        [Compare("Password", ErrorMessage = "Şifreyi dopru giriniz")]
        public string rePassword { get; set; }
    }
}