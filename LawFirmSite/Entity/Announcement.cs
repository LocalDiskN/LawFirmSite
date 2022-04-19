using LawFirmSite.Consts;
using LawFirmSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LawFirmSite.Entity
{
    public class Announcement
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public Announcement()
        {
            Title = "";
            Content = "";
        }
        public Announcement(AnnouncementCreateEditModel modelthis)
        {
            Title = Const.AddChangeLangValue("", modelthis.Title, modelthis.lang);
            Content = Const.AddChangeLangValue("", modelthis.Content, modelthis.lang);
        }

        public void equlize(AnnouncementCreateEditModel copy)
        {
            Content = Const.AddChangeLangValue(Content, copy.Content, copy.lang);
            Title = Const.AddChangeLangValue(Title, copy.Title, copy.lang);
        }
    }
}