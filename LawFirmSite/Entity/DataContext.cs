using LawFirmSite.Identity;
using LawFirmSite.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LawFirmSite.Entity
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DataContext() : base("dataConnection")
        {

        }
        
        public DbSet<Employee> employees { get; set; }
        public DbSet<Practice> practices { get; set; }
        public DbSet<About> abouts { get; set; }
        public DbSet<Announcement> announcements { get; set; }
        public DbSet<Article> articles { get; set; }
        public DbSet<ContactInfo> contacts { get; set; }
        public DbSet<Language> languages { get; set; }
    }
}