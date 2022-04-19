using LawFirmSite.Consts;
using LawFirmSite.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LawFirmSite.Entity
{
    public class DataInitializer : CreateDatabaseIfNotExists<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            //Roles
            if (!context.Roles.Any(i => i.Name == "admin"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);

                var role = new ApplicationRole() { Name = "admin" };
                manager.Create(role);
            }

            //Users
            if (!context.Users.Any(i => i.UserName == "admin"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);

                var user = new ApplicationUser() { UserName = "admin", Email = "mdenizcelebi@gmail.com" };
                manager.Create(user, "whiterabbit");
                manager.AddToRole(user.Id, "admin");
            }
            
            List<Practice> practices = new List<Practice>()
            {
                new Practice(){ Align = "center", Title = Const.AddChangeLangValue(Const.AddChangeLangValue("", "Criminal Law", "eng"), "Ceza Hukuku", "tur"), Content = Const.AddChangeLangValue(Const.AddChangeLangValue("", "Türkçe içerik", "tur"), "English content", "eng"), ImgUrlSmall = "/Images/Practices/600x260.png", ImgUrlBig = "/Images/PracticeNAbout/400x700.png"},
                new Practice(){ Align = "center", Title = Const.AddChangeLangValue(Const.AddChangeLangValue("", "Real Estate", "eng"), "Emlak Hukuku", "tur"), Content = Const.AddChangeLangValue(Const.AddChangeLangValue("", "Türkçe içerik", "tur"), "English content", "eng"), ImgUrlSmall = "/Images/Practices/600x260.png", ImgUrlBig = "/Images/PracticeNAbout/400x700.png"},
                new Practice(){ Align = "center", Title = Const.AddChangeLangValue(Const.AddChangeLangValue("", "Civil Law", "eng"), "Medeni Hukuk", "tur"), Content = Const.AddChangeLangValue(Const.AddChangeLangValue("", "Türkçe içerik", "tur"), "English content", "eng"), ImgUrlSmall = "/Images/Practices/600x260.png", ImgUrlBig = "/Images/PracticeNAbout/400x700.png"}
            };

            foreach (var item in practices)
            {
                context.practices.Add(item);
            }

            List<About> abouts = new List<About>()
            {
                new About(){ Align = "left", Content = Const.AddChangeLangValue(Const.AddChangeLangValue("", "Türkçe içerik", "tur"), "English content", "eng"), Title = Const.AddChangeLangValue(Const.AddChangeLangValue("", "HUKUKİ SORUNLARINIZA ÇÖZÜM ÜRETİYORUZ", "tur"), "WE FIND SOLUTIONS TO YOUR LEGAL PROBLEMS", "eng"), ImgUrl = "/Images/PracticeNAbout/400x700.png"},
                new About(){ Align = "right", Content = Const.AddChangeLangValue(Const.AddChangeLangValue("", "Türkçe içerik", "tur"), "English content", "eng"), Title = Const.AddChangeLangValue(Const.AddChangeLangValue("", "SİZİN İÇİN ÇALIŞIYORUZ", "tur"), "WE WORK FOR YOU", "eng"), ImgUrl = "/Images/PracticeNAbout/400x700.png"}
            };

            foreach (var item in abouts)
            {
                context.abouts.Add(item);
            }

            List<Employee> employees = new List<Employee>()
            {
                new Employee(){ isVisible = true, Title = Const.AddChangeLangValue(Const.AddChangeLangValue("", "Av", "tur"), "Atty.", "eng"), IDInfo = new IdCard(){ Name = "Mehmet Deniz", Surname = "Çelebi" }, Explanation = Const.AddChangeLangValue(Const.AddChangeLangValue("", "Türkçe açıklama", "tur"), "English explanation", "eng"), ImgUrl = "/Images/Profile/300x400.png" },
                new Employee(){ isVisible = true, Title = Const.AddChangeLangValue(Const.AddChangeLangValue("", "Av.", "tur"), "Atty.", "eng"), IDInfo = new IdCard(){ Name = "Haydar", Surname = "Çelebi" } , Explanation = Const.AddChangeLangValue(Const.AddChangeLangValue("", "Türkçe açıklama", "tur"), "English explanation", "eng"), ImgUrl = "/Images/Profile/300x400.png" },
            };

            foreach (var item in employees)
            {
                context.employees.Add(item);
            }

            List<Announcement> announcements = new List<Announcement>()
            {
                new Announcement(){ Title = Const.AddChangeLangValue(Const.AddChangeLangValue("", "Türkçe başlık", "tur"), "English title", "eng"), Content = Const.AddChangeLangValue(Const.AddChangeLangValue("", "Türkçe içerik", "tur"), "English content", "eng")},
                new Announcement(){ Title = Const.AddChangeLangValue(Const.AddChangeLangValue("", "Türkçe başlık baby", "tur"), "English title", "eng"), Content = Const.AddChangeLangValue(Const.AddChangeLangValue("", "Başlıkbu işte naparsın uzatmaya çalışıyorum", "tur"), "English content", "eng")}
            };

            foreach (var item in announcements)
            {
                context.announcements.Add(item);
            }

            List<ContactInfo> contacts = new List<ContactInfo>()
            {
                new ContactInfo(){ Title = Const.AddChangeLangValue(Const.AddChangeLangValue("", "Harita", "tur"), "Map", "eng"), Contents = "41.013236" + Const.keySeparator + "28.938062" + Const.keySeparator},
                new ContactInfo(){ Title = Const.AddChangeLangValue(Const.AddChangeLangValue("", "Adres", "tur"), "Address", "eng"), Contents = "Fındıkzade-Millet Cad. No:96 K.3 D.20 Fatih/İSTANBUL" + Const.keySeparator, Cicon = "<i class='fas fa-map-marker-alt' style='color:rgb(234, 67, 53); '></i>"},
                new ContactInfo(){ Title = Const.AddChangeLangValue(Const.AddChangeLangValue("", "Cep Telefonu", "tur"), "Cell", "eng"), Contents = "0535 2415126" + Const.keySeparator, Cicon = "<i class='fas fa-mobile-alt' style='color:rgb(40, 40, 40); '></i>"},
                new ContactInfo(){ Title = Const.AddChangeLangValue(Const.AddChangeLangValue("", "Telefon & Faks", "tur"), "Phone & Fax", "eng"), Contents ="0212 5322759" + Const.keySeparator, Cicon = "<i class='fas fa-phone' style='color:rgb(40, 40, 40); '></i><i class='fas fa-fax' style='color:rgb(40, 40, 40); '></i>"},
                new ContactInfo(){ Title = Const.AddChangeLangValue(Const.AddChangeLangValue("", "E-Mail", "tur"), "E-Mail", "eng"), Contents = "mdenizcelebi@gmail.com" + Const.keySeparator + "celebi_haydar@hotmail.com" + Const.keySeparator, Cicon = "<i class='far fa-envelope' style='color:rgb(40, 40, 40); '></i>"},
            };

            foreach (var item in contacts)
            {
                context.contacts.Add(item);
            }

            List<Language> languages = new List<Language>()
            {
                new Language(){ Title = "LangKeys", Abbreviation = "LangKeys", Content = "DateFormat"+ Const.keySeparator +"WebsiteTitle" + Const.keySeparator +"DateTimeFormat" + Const.keySeparator + "FileUploaded" + Const.keySeparator + "Cancel" + Const.keySeparator + "PasswordAgain" + Const.keySeparator + "Password" + Const.keySeparator + "NewPassword"+ Const.keySeparator + "PassesNoMatch" + Const.keySeparator + "Username" + Const.keySeparator + "RememberMe" + Const.keySeparator + "CarThree" + Const.keySeparator + "CarTwo" + Const.keySeparator + "CarOne" + Const.keySeparator + "HomeBody" + Const.keySeparator + "HomeTitle" + Const.keySeparator + "Profile" + Const.keySeparator+ "AddNew" + Const.keySeparator+ "ContactUs" + Const.keySeparator+ "Name" + Const.keySeparator+ "Surname" + Const.keySeparator+ "FullName" + Const.keySeparator+ "Subject" + Const.keySeparator+ "Message" + Const.keySeparator+ "YourEmail"+ Const.keySeparator+ "Email" + Const.keySeparator+ "Send" + Const.keySeparator + "SiteMap" + Const.keySeparator + "Language" + Const.keySeparator + "Translations" + Const.keySeparator + "Admin" + Const.keySeparator + "Contact" + Const.keySeparator + "Announcements" + Const.keySeparator + "Articles" + Const.keySeparator + "Team" + Const.keySeparator + "Practices" + Const.keySeparator + "About" + Const.keySeparator + "Home" + Const.keySeparator + "Admin" + Const.keySeparator  + "Logout" + Const.keySeparator + "Login" + Const.keySeparator + "Edit" + Const.keySeparator + "Create" + Const.keySeparator + "Delete" + Const.keySeparator + "Title" + Const.keySeparator + "TitleAbbr" + Const.keySeparator + "Abbreviation" + Const.keySeparator + "Visibility" + Const.keySeparator + "Settings" + Const.keySeparator + "Add" + Const.keySeparator +
                "Save" + Const.keySeparator + "Top" + Const.keySeparator + "Bottom" + Const.keySeparator + "Left" + Const.keySeparator + "Center" + Const.keySeparator + "Right" + Const.keySeparator + "Alignment" + Const.keySeparator + "AvailableImages"  + Const.keySeparator +"Explanation" + Const.keySeparator + "Content" + Const.keySeparator + "FileDeleted" + Const.keySeparator + "ContentDeleted" + Const.keySeparator + "EditSuccess" + Const.keySeparator + "EditFail" + Const.keySeparator + "ContentCreated" + Const.keySeparator + "CreateContentError" + Const.keySeparator + "FileInUse" + Const.keySeparator + "DeleteContentError" + Const.keySeparator +
                "UploadCancelled" + Const.keySeparator + "DragNDrop" + Const.keySeparator + "ViewDetails" + Const.keySeparator + "DetailedPreview" + Const.keySeparator + "FileUploadError" + Const.keySeparator + "UploadAborted" + Const.keySeparator + "AllowedUploadSize" + Const.keySeparator + "FileSizeTooLarge" + Const.keySeparator + "FilesSelected" + Const.keySeparator + "Completed" + Const.keySeparator + "No" + Const.keySeparator + "LoadingFile" + Const.keySeparator + "WidthTooShort" + Const.keySeparator + "WidthTooLong" + Const.keySeparator + "HieghtTooShort" + Const.keySeparator + "HieghtTooLong" + Const.keySeparator + "TooManyFiles" + Const.keySeparator + "TooLessFiles" + Const.keySeparator + "InvalidFileType" + Const.keySeparator + "UploadCancelled" + Const.keySeparator + "InvalidFileExtension" + Const.keySeparator + "Only" + Const.keySeparator + "Supported" + Const.keySeparator + "Skipped" + Const.keySeparator + "Folder" + Const.keySeparator + "DragNDropOnly" + Const.keySeparator + "ErrorReadingSecureFile" + Const.keySeparator + "ErrorReadingFile" + Const.keySeparator + "PreviewAbortedFor" + Const.keySeparator + "FileNotReadable" + Const.keySeparator + "FileNotFound" + Const.keySeparator+ "SelectFile" + Const.keySeparator + "Upload" + Const.keySeparator + "Clear" + Const.keySeparator + "Browse" + Const.keySeparator + "Remove" + Const.keySeparator +
                "Job" + Const.keySeparator + "Graduations" + Const.keySeparator + "Salary" + Const.keySeparator + "SGKPirim" + Const.keySeparator + "Currency" + Const.keySeparator + "PhoneNum" + Const.keySeparator + "Address" + Const.keySeparator + "StartingDate" + Const.keySeparator + "LeaveDate" + Const.keySeparator + "Seri" + Const.keySeparator + "Num" + Const.keySeparator + "SSNum" + Const.keySeparator + "FathersName" + Const.keySeparator + "MothersName" + Const.keySeparator + "BirthPlace" + Const.keySeparator + "TimeOfBirth" + Const.keySeparator + "MaritalStatus" + Const.keySeparator + "Religion" + Const.keySeparator + "BloodType" + Const.keySeparator + "City" + Const.keySeparator + "District" + Const.keySeparator + "NeighborhoodOrVillage" + Const.keySeparator + "CiltNo" + Const.keySeparator + "AileSiraNo" + Const.keySeparator + "SiraNo" + Const.keySeparator + "VerildigiYer" + Const.keySeparator + "VerilisNedeni" + Const.keySeparator + "KayitNo" + Const.keySeparator + "VerilisTarihi" + Const.keySeparator

                },

                new Language(){ Title = "English", Abbreviation = "eng", Content = Const.AddChangeLangValue(Const.AddChangeLangValue(Const.AddChangeLangValue(Const.AddChangeLangValue(Const.AddChangeLangValue(Const.AddChangeLangValue(Const.AddChangeLangValue(Const.AddChangeLangValue(Const.AddChangeLangValue(Const.AddChangeLangValue(Const.AddChangeLangValue(Const.AddChangeLangValue(Const.AddChangeLangValue(Const.AddChangeLangValue(Const.AddChangeLangValue(Const.AddChangeLangValue(Const.AddChangeLangValue(Const.AddChangeLangValue(Const.AddChangeLangValue(Const.AddChangeLangValue(Const.AddChangeLangValue(Const.AddChangeLangValue(Const.AddChangeLangValue(Const.AddChangeLangValue(Const.AddChangeLangValue(Const.AddChangeLangValue(Const.AddChangeLangValue(Const.AddChangeLangValue(Const.AddChangeLangValue(Const.AddChangeLangValue(Const.AddChangeLangValue(Const.AddChangeLangValue(Const.AddChangeLangValue(Const.AddChangeLangValue(Const.AddChangeLangValue("", "mm/dd/yyyy", "DateFormat"), "File Uploaded Successfully", "FileUploaded"), "Cancel", "Cancel"), "Password Again", "PasswordAgain"), "Password", "Password"), "Username", "Username"), "Remember Me", "RememberMe"), "Login", "Login"), "You Are In Trusted Hands", "CarThree"), "We Work For You", "CarTwo"), "", "CarOne"), "\"After examining our practices, you can contact us about the legal problems you need help with\"", "HomeBody"), "\"We Are Here For You\"", "HomeTitle"), "Profile", "Profile"), "Site Map", "SiteMap"), "Send", "Send"), "Your E-mail Address", "YourEmail"), "Message", "Message"), "Subject", "Subject"), "Full Name", "FullName"), "Contact Us", "ContactUs"), "Add New", "AddNew"), "Create", "Create"), "Delete", "Delete"), "Edit", "Edit"), "Logout", "Logout"), "Home", "Home"), "About", "About"), "Practices", "Practices"), "Team", "Team"), "Articles", "Articles"), "Announcements", "Announcements"), "Contact", "Contact"), "Control Panel", "Admin"), "languge", "Language")},
                new Language(){ Title = "Türkçe", Abbreviation = "tur", Content = Const.AddChangeLangValue(Const.AddChangeLangValue(Const.AddChangeLangValue(Const.AddChangeLangValue(Const.AddChangeLangValue(Const.AddChangeLangValue(Const.AddChangeLangValue(Const.AddChangeLangValue(Const.AddChangeLangValue(Const.AddChangeLangValue(Const.AddChangeLangValue(Const.AddChangeLangValue(Const.AddChangeLangValue(Const.AddChangeLangValue(Const.AddChangeLangValue(Const.AddChangeLangValue(Const.AddChangeLangValue(Const.AddChangeLangValue(Const.AddChangeLangValue(Const.AddChangeLangValue(Const.AddChangeLangValue(Const.AddChangeLangValue(Const.AddChangeLangValue(Const.AddChangeLangValue(Const.AddChangeLangValue(Const.AddChangeLangValue(Const.AddChangeLangValue(Const.AddChangeLangValue(Const.AddChangeLangValue(Const.AddChangeLangValue(Const.AddChangeLangValue(Const.AddChangeLangValue(Const.AddChangeLangValue(Const.AddChangeLangValue(Const.AddChangeLangValue("", "dd/mm/yyyy", "DateFormat"), "Dosya Başarılı Bir Şekilde Gönderildi", "FileUploaded"), "İptal", "Cancel"), "Parola Tekrar", "PasswordAgain"), "Parola", "Password"), "Kullanıcı Adı", "Username"), "Beni Hatırla", "RememberMe"), "Giriş", "Login"), "Güvenilir Ellerdesiniz", "CarThree"), "Sizin İçin Çalışıyoruz", "CarTwo"), "", "CarOne"), "\"Çalışma alanlarımız bölümünü inceleyerek, siz de ihtiyaç duyduğunuz hukuki yardım için bize başvurabilirsiniz.\"", "HomeBody"), "\"Sizin İçin Buradayız\"", "HomeTitle"), "Profil", "Profile"), "Site Haritası", "SiteMap"), "Gönder", "Send"), "E-mail Adresiniz", "YourEmail"), "Mesaj", "Message"), "Konu", "Subject"), "Ad Soyad", "FullName"), "Bize Ulaşın", "ContactUs"), "Yeni Ekle", "AddNew"), "Oluştur", "Create"), "Sil", "Delete"), "Değiştir", "Edit"), "Çıkış", "Logout"), "Anasayfa", "Home"), "Hakkımızda", "About"), "Çalışma Alanlarımız", "Practices"), "Ekibimiz", "Team"), "Makaleler", "Articles"), "Duyurular", "Announcements"), "İletişim", "Contact"), "Kontrol Paneli", "Admin"), "dil", "Language")}
            };

            foreach (var item in languages)
            {
                context.languages.Add(item);
            }

            context.SaveChanges();

            base.Seed(context);
        }
    }
}