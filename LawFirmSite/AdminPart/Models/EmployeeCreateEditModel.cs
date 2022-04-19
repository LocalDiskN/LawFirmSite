using LawFirmSite.Consts;
using LawFirmSite.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static LawFirmSite.Models.EmployeeCreateEditModel;

namespace LawFirmSite.Models
{
    public class EmployeeCreateEditModel
    {
        public string lang { get; set; }
        public string datetimeformat { get; set; }
        public int idme { get; set; }
        public string TitleAbbr { get; set; }
        public string Job { get; set; }

        public string Graduations { get; set; }
        public double Salary { get; set; }
        public double SGKPirim { get; set; }
        public string Currency { get; set; }
        public string StartingDate { get; set; }
        public string LeaveDate { get; set; }

        public string PhoneNum { get; set; }
        public string PhoneNum2 { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string ImgUrl { get; set; }

        public string Explanation { get; set; }
        public string Explanation2 { get; set; }
        public bool isVisible { get; set; }

        public string Articles { get; set; }


        public string Seri { get; set; }
        public string Num { get; set; }
        public string SSNum { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string FathersName { get; set; }
        public string MothersName { get; set; }
        public string BirthPlace { get; set; }
        public string TimeOfBirth { get; set; }
        public string MaritalStatus { get; set; }
        public string Religion { get; set; }
        public string BloodType { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string NeighborhoodOrVillage { get; set; }
        public string CiltNo { get; set; }
        public string AileSiraNo { get; set; }
        public string SiraNo { get; set; }
        public string VerildigiYer { get; set; }
        public string VerilisNedeni { get; set; }
        public string KayitNo { get; set; }
        public string VerilisTarihi { get; set; }

        public EmployeeCreateEditModel()
        {
            datetimeformat = "";
            TitleAbbr = "";
            Job = "";
            Graduations = "";
            Salary = 0.0;
            SGKPirim = 0.0;
            Currency = "";
            StartingDate = "";
            LeaveDate = "";
            PhoneNum = "";
            PhoneNum2 = "";
            Address = "";
            Address2 = "";
            Email = "";
            Email2 = "";
            Explanation = "";
            Explanation2 = "";
            ImgUrl = "/Images/Profile/300x400.png";
            isVisible = true;
            Articles = "";


            Seri = "";
            Num = "";
            SSNum = "";
            Surname = "";
            Name = "";
            FathersName = "";
            MothersName = "";
            BirthPlace = "";
            TimeOfBirth = "";
            MaritalStatus = "";
            Religion = "";
            BloodType = "";
            City = "";
            District = "";
            NeighborhoodOrVillage = "";
            CiltNo = "";
            AileSiraNo = "";
            SiraNo = "";
            VerildigiYer = "";
            VerilisNedeni = "";
            KayitNo = "";
            VerilisTarihi = "";
        }
        public EmployeeCreateEditModel(Employee copy, string datetimeformat, ref string lang)
        {
            idme = copy.Id;
            this.datetimeformat = datetimeformat;
            TitleAbbr = Const.GetValueFromDictionary(copy.Title, ref lang);
            Job = Const.GetValueFromDictionary(copy.Job, ref lang);
            Graduations = Const.GetValueFromDictionary(copy.Graduations, ref lang);
            Salary = copy.Salary;
            SGKPirim = copy.SGKPirim;
            Currency = Const.GetValueFromDictionary(copy.Currency, ref lang);
            StartingDate = copy.StartingDate.ToString(datetimeformat.Replace("mm", "MM"));
            LeaveDate = copy.LeaveDate.ToString(datetimeformat.Replace("mm", "MM"));
            PhoneNum = copy.PhoneNum;
            PhoneNum2 = copy.PhoneNum2;
            Address = copy.Address;
            Address2 = copy.Address2;
            Email = copy.Email;
            Email2 = copy.Email2;
            Explanation = Const.GetValueFromDictionary(copy.Explanation, ref lang);
            Explanation2 = Const.GetValueFromDictionary(copy.Explanation2, ref lang);
            ImgUrl = copy.ImgUrl;
            isVisible = copy.isVisible;
            Articles = copy.Articles;


            Seri = copy.IDInfo.Seri;
            Num = copy.IDInfo.No;
            SSNum = copy.IDInfo.SSNO;
            Surname = copy.IDInfo.Surname;
            Name = copy.IDInfo.Name;
            FathersName = copy.IDInfo.FathersName;
            MothersName = copy.IDInfo.MothersName;
            BirthPlace = copy.IDInfo.BirthPlace;
            TimeOfBirth = copy.IDInfo.TimeOfBirth.ToString(datetimeformat.Replace("mm", "MM"));
            MaritalStatus = Const.GetValueFromDictionary(copy.IDInfo.MaritalStatus, ref lang);
            Religion = Const.GetValueFromDictionary(copy.IDInfo.Religion, ref lang);
            BloodType = copy.IDInfo.BloodType;
            City = copy.IDInfo.City;
            District = copy.IDInfo.District;
            NeighborhoodOrVillage = copy.IDInfo.NeighborhoodOrVillage;
            CiltNo = copy.IDInfo.CiltNo;
            AileSiraNo = copy.IDInfo.AileSiraNo;
            SiraNo = copy.IDInfo.SiraNo;
            VerildigiYer = copy.IDInfo.VerildigiYer;
            VerilisNedeni = Const.GetValueFromDictionary(copy.IDInfo.VerilisNedeni, ref lang);
            KayitNo = copy.IDInfo.KayitNo;
            VerilisTarihi = copy.IDInfo.VerilisTarihi.ToString(datetimeformat.Replace("mm", "MM"));
        }
    }
}