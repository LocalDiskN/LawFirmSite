using LawFirmSite.Consts;
using LawFirmSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static LawFirmSite.Models.EmployeeCreateEditModel;

namespace LawFirmSite.Entity
{
    public class Employee
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Job { get; set; }
        public string Graduations { get; set; }
        public double Salary { get; set; }
        public double SGKPirim { get; set; }
        public string Currency { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime LeaveDate { get; set; }

        public string PhoneNum { get; set; }
        public string PhoneNum2 { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string ImgUrl { get; set; }

        public string Explanation { get; set; }
        public string Explanation2 { get; set; }
        public IdCard IDInfo { get; set; }
        public bool isVisible { get; set; }

        public string Articles { get; set; }

        public Employee()
        {
            Title = "";
            Job = "";
            Graduations = "";
            Currency = "";
            Salary = 0.0;
            SGKPirim = 0.0;
            StartingDate = DateTime.Now;
            LeaveDate = DateTime.Now;
            PhoneNum = "";
            PhoneNum2 = "";
            Address = "";
            Address2 = "";
            Email = "";
            Email2 = "";
            Explanation = "";
            Explanation2 = "";
            ImgUrl = "/Images/Profile/300x400.png";
            IDInfo = new IdCard();
            isVisible = true;
            Articles = "";
        }
        public Employee(EmployeeCreateEditModel copy)
        {
            Title = Const.AddChangeLangValue("", copy.TitleAbbr, copy.lang);
            Job = Const.AddChangeLangValue("", copy.Job, copy.lang);
            Graduations = Const.AddChangeLangValue("", copy.Graduations, copy.lang);
            Salary = copy.Salary;
            SGKPirim = copy.SGKPirim;
            Currency = Const.AddChangeLangValue("", copy.Currency, copy.lang);
            StartingDate = Const.stringToDatetime(copy.StartingDate, copy.datetimeformat);
            LeaveDate = Const.stringToDatetime(copy.LeaveDate, copy.datetimeformat);
            PhoneNum = copy.PhoneNum;
            PhoneNum2 = copy.PhoneNum2;
            Address = copy.Address;
            Address2 = copy.Address2;
            Email = copy.Email;
            Email2 = copy.Email2;
            Explanation = Const.AddChangeLangValue("", copy.Explanation, copy.lang);
            Explanation2 = Const.AddChangeLangValue("", copy.Explanation2, copy.lang);
            ImgUrl = copy.ImgUrl;
            IDInfo = new IdCard(copy);
            isVisible = copy.isVisible;
            Articles = "";
        }

        public void equlize(EmployeeCreateEditModel copy)
        {
            Title = Const.AddChangeLangValue(Title, copy.TitleAbbr, copy.lang);
            Job = Const.AddChangeLangValue(Job, copy.Job, copy.lang);
            Graduations = Const.AddChangeLangValue(Graduations, copy.Graduations, copy.lang);
            Salary = copy.Salary;
            SGKPirim = copy.SGKPirim;
            Currency = Const.AddChangeLangValue(Currency, copy.Currency, copy.lang);
            StartingDate = Const.stringToDatetime(copy.StartingDate, copy.datetimeformat);
            LeaveDate = Const.stringToDatetime(copy.LeaveDate, copy.datetimeformat);
            PhoneNum = copy.PhoneNum;
            PhoneNum2 = copy.PhoneNum2;
            Address = copy.Address;
            Address2 = copy.Address2;
            Email = copy.Email;
            Email2 = copy.Email2;
            Explanation = Const.AddChangeLangValue(Explanation, copy.Explanation, copy.lang);
            Explanation2 = Const.AddChangeLangValue(Explanation2, copy.Explanation2, copy.lang);
            ImgUrl = copy.ImgUrl;
            IDInfo.equlize(copy);
            isVisible = copy.isVisible;
        }
    }

    public class IdCard
    {
        public string Seri { get; set; }
        public string No { get; set; }
        public string SSNO { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string FathersName { get; set; }
        public string MothersName { get; set; }
        public string BirthPlace { get; set; }
        public DateTime TimeOfBirth { get; set; }
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
        public DateTime VerilisTarihi { get; set; }

        public IdCard()
        {
            Seri = "";
            No = "";
            SSNO = "";
            Surname = "";
            Name = "";
            FathersName = "";
            MothersName = "";
            BirthPlace = "";
            TimeOfBirth = DateTime.Now;
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
            VerilisTarihi = DateTime.Now;
        }
        public IdCard(IdCard copy, string lang)
        {
            Seri = copy.Seri;
            No = copy.No;
            SSNO = copy.SSNO;
            Surname = copy.Surname;
            Name = copy.Name;
            FathersName = copy.FathersName;
            MothersName = copy.MothersName;
            BirthPlace = copy.BirthPlace;
            TimeOfBirth = copy.TimeOfBirth;
            MaritalStatus = Const.AddChangeLangValue("", copy.MaritalStatus, lang);
            Religion = Const.AddChangeLangValue("", copy.Religion, lang);
            BloodType = copy.BloodType;
            City = copy.City;
            District = copy.District;
            NeighborhoodOrVillage = copy.NeighborhoodOrVillage;
            CiltNo = copy.CiltNo;
            AileSiraNo = copy.AileSiraNo;
            SiraNo = copy.SiraNo;
            VerildigiYer = copy.VerildigiYer;
            VerilisNedeni = Const.AddChangeLangValue("", copy.VerilisNedeni, lang);
            KayitNo = copy.KayitNo;
            VerilisTarihi = copy.VerilisTarihi;
        }
        public IdCard(EmployeeCreateEditModel copy)
        {
            Seri = copy.Seri;
            No = copy.Num;
            SSNO = copy.SSNum;
            Surname = copy.Surname;
            Name = copy.Name;
            FathersName = copy.FathersName;
            MothersName = copy.MothersName;
            BirthPlace = copy.BirthPlace;
            TimeOfBirth = Const.stringToDatetime(copy.TimeOfBirth, copy.datetimeformat);
            MaritalStatus = Const.AddChangeLangValue("", copy.MaritalStatus, copy.lang);
            Religion = Const.AddChangeLangValue("", copy.Religion, copy.lang);
            BloodType = copy.BloodType;
            City = copy.City;
            District = copy.District;
            NeighborhoodOrVillage = copy.NeighborhoodOrVillage;
            CiltNo = copy.CiltNo;
            AileSiraNo = copy.AileSiraNo;
            SiraNo = copy.SiraNo;
            VerildigiYer = copy.VerildigiYer;
            VerilisNedeni = Const.AddChangeLangValue("", copy.VerilisNedeni, copy.lang);
            KayitNo = copy.KayitNo;
            VerilisTarihi = Const.stringToDatetime(copy.VerilisTarihi, copy.datetimeformat);
        }
        public void equlize(IdCard copy, string lang)
        {
            Seri = copy.Seri;
            No = copy.No;
            SSNO = copy.SSNO;
            Surname = copy.Surname;
            Name = copy.Name;
            FathersName = copy.FathersName;
            MothersName = copy.MothersName;
            BirthPlace = copy.BirthPlace;
            TimeOfBirth = copy.TimeOfBirth;
            MaritalStatus = Const.AddChangeLangValue(MaritalStatus, copy.MaritalStatus, lang);
            Religion = Const.AddChangeLangValue(Religion, copy.Religion, lang);
            BloodType = copy.BloodType;
            City = copy.City;
            District = copy.District;
            NeighborhoodOrVillage = copy.NeighborhoodOrVillage;
            CiltNo = copy.CiltNo;
            AileSiraNo = copy.AileSiraNo;
            SiraNo = copy.SiraNo;
            VerildigiYer = copy.VerildigiYer;
            VerilisNedeni = Const.AddChangeLangValue(VerilisNedeni, copy.VerilisNedeni, lang);
            KayitNo = copy.KayitNo;
            VerilisTarihi = copy.VerilisTarihi;
        }
        public void equlize(EmployeeCreateEditModel copy)
        {
            Seri = copy.Seri;
            No = copy.Num;
            SSNO = copy.SSNum;
            Surname = copy.Surname;
            Name = copy.Name;
            FathersName = copy.FathersName;
            MothersName = copy.MothersName;
            BirthPlace = copy.BirthPlace;
            TimeOfBirth = Const.stringToDatetime(copy.TimeOfBirth, copy.datetimeformat);
            MaritalStatus = Const.AddChangeLangValue(MaritalStatus, copy.MaritalStatus, copy.lang);
            Religion = Const.AddChangeLangValue(Religion, copy.Religion, copy.lang);
            BloodType = copy.BloodType;
            City = copy.City;
            District = copy.District;
            NeighborhoodOrVillage = copy.NeighborhoodOrVillage;
            CiltNo = copy.CiltNo;
            AileSiraNo = copy.AileSiraNo;
            SiraNo = copy.SiraNo;
            VerildigiYer = copy.VerildigiYer;
            VerilisNedeni = Const.AddChangeLangValue(VerilisNedeni, copy.VerilisNedeni, copy.lang);
            KayitNo = copy.KayitNo;
            VerilisTarihi = Const.stringToDatetime(copy.VerilisTarihi, copy.datetimeformat);
        }
    }
    
}