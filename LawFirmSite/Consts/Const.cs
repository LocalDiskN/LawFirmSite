using LawFirmSite.Entity;
using LawFirmSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace LawFirmSite.Consts
{
    public class Const
    {
        static public string[] months = new string[]
           {
            "January","February","March","April","May","June",
            "July","August","September","October","November","December"
           };

        static public string[] messageSenders = new string[]
        {
            "C", "T", "D", "Skip"
        };

        public static string site = "http://localhost:60026";
        public static string keySeparator = "/77334sa524/453f8675/";
        public static string sectionSeparator = "-7257a42-21g3sdf21-";

        public static string GetValueFromDictionary(string dic, ref string LanguageAbbreviation, bool givekeyifnotexist = false)
        {
            string result = "";
            if (dic != null && !dic.Equals("") && LanguageAbbreviation != null)
            {
                int pos = dic.IndexOf(sectionSeparator + LanguageAbbreviation + sectionSeparator);
                if (pos != -1)
                {
                    pos += sectionSeparator.Length * 2 + LanguageAbbreviation.Length;
                    result = dic.Substring(pos, dic.IndexOf(sectionSeparator + LanguageAbbreviation + sectionSeparator, pos) - pos);
                }
                else if (LanguageAbbreviation.Equals("eng"))
                {
                    pos = dic.IndexOf(sectionSeparator + "tur" + sectionSeparator);
                    if (pos != -1)
                    {
                        pos += sectionSeparator.Length * 2 + 3;
                        result = dic.Substring(pos, dic.IndexOf(sectionSeparator + "tur" + sectionSeparator, pos) - pos);
                    }
                }
                else
                {
                    pos = dic.IndexOf(sectionSeparator + "eng" + sectionSeparator);
                    if (pos != -1)
                    {
                        pos += sectionSeparator.Length * 2 + 3;
                        result = dic.Substring(pos, dic.IndexOf(sectionSeparator + "eng" + sectionSeparator, pos) - pos);
                    }
                }

                if (result.Equals(""))
                {
                    if (LanguageAbbreviation.Equals("eng"))
                    {
                        pos = dic.IndexOf(sectionSeparator + "tur" + sectionSeparator);
                        if (pos != -1)
                        {
                            pos += sectionSeparator.Length * 2 + 3;
                            result = dic.Substring(pos, dic.IndexOf(sectionSeparator + "tur" + sectionSeparator, pos) - pos);
                        }
                    }
                    else
                    {
                        pos = dic.IndexOf(sectionSeparator + "eng" + sectionSeparator);
                        if (pos != -1)
                        {
                            pos += sectionSeparator.Length * 2 + 3;
                            result = dic.Substring(pos, dic.IndexOf(sectionSeparator + "eng" + sectionSeparator, pos) - pos);
                        }
                    }
                }
            }
            if (givekeyifnotexist && (result == null || result.Equals("")))
            {
                return LanguageAbbreviation;
            }
            return result;
        }

        public static string GetValueFromDictionary(List<LanguageModel> dics, ref string LanguageAbbreviation)
        {
            string dic = "";
            for (int i = 0; i < dics.Count; i++)
            {
                if (!dics[i].Content.Equals(""))
                {
                    dic = dics[i].Content;
                }
            }
            string result = "";
            if (dic != null && !dic.Equals("") && LanguageAbbreviation != null)
            {
                int pos = dic.IndexOf(sectionSeparator + LanguageAbbreviation + sectionSeparator);
                if (pos != -1)
                {
                    pos += sectionSeparator.Length * 2 + LanguageAbbreviation.Length;
                    result = dic.Substring(pos, dic.IndexOf(sectionSeparator + LanguageAbbreviation + sectionSeparator, pos) - pos);
                }
                else if (LanguageAbbreviation.Equals("eng"))
                {
                    pos = dic.IndexOf(sectionSeparator + "tur" + sectionSeparator);
                    if (pos != -1)
                    {
                        pos += sectionSeparator.Length * 2 + 3;
                        result = dic.Substring(pos, dic.IndexOf(sectionSeparator + "tur" + sectionSeparator, pos) - pos);
                    }
                }
                else
                {
                    pos = dic.IndexOf(sectionSeparator + "eng" + sectionSeparator);
                    if (pos != -1)
                    {
                        pos += sectionSeparator.Length * 2 + 3;
                        result = dic.Substring(pos, dic.IndexOf(sectionSeparator + "eng" + sectionSeparator, pos) - pos);
                    }
                }
            }

            return result;
        }

        public static string GetValueFromDictionary(string dic, string LanguageAbbreviation, bool givekeyifnotexist = false)
        {
            string result = "";
            if (dic != null && !dic.Equals("") && LanguageAbbreviation != null)
            {
                int pos = dic.IndexOf(sectionSeparator + LanguageAbbreviation + sectionSeparator);
                if (pos != -1)
                {
                    pos += sectionSeparator.Length * 2 + LanguageAbbreviation.Length;
                    result = dic.Substring(pos, dic.IndexOf(sectionSeparator + LanguageAbbreviation + sectionSeparator, pos) - pos);
                }
                else if (LanguageAbbreviation.Equals("eng"))
                {
                    pos = dic.IndexOf(sectionSeparator + "tur" + sectionSeparator);
                    if (pos != -1)
                    {
                        pos += sectionSeparator.Length * 2 + 3;
                        result = dic.Substring(pos, dic.IndexOf(sectionSeparator + "tur" + sectionSeparator, pos) - pos);
                    }
                }
                else
                {
                    pos = dic.IndexOf(sectionSeparator + "eng" + sectionSeparator);
                    if (pos != -1)
                    {
                        pos += sectionSeparator.Length * 2 + 3;
                        result = dic.Substring(pos, dic.IndexOf(sectionSeparator + "eng" + sectionSeparator, pos) - pos);
                    }
                }

                if (result.Equals(""))
                {
                    if (LanguageAbbreviation.Equals("eng"))
                    {
                        pos = dic.IndexOf(sectionSeparator + "tur" + sectionSeparator);
                        if (pos != -1)
                        {
                            pos += sectionSeparator.Length * 2 + 3;
                            result = dic.Substring(pos, dic.IndexOf(sectionSeparator + "tur" + sectionSeparator, pos) - pos);
                        }
                    }
                    else
                    {
                        pos = dic.IndexOf(sectionSeparator + "eng" + sectionSeparator);
                        if (pos != -1)
                        {
                            pos += sectionSeparator.Length * 2 + 3;
                            result = dic.Substring(pos, dic.IndexOf(sectionSeparator + "eng" + sectionSeparator, pos) - pos);
                        }
                    }
                }
            }
            if (givekeyifnotexist && (result == null || result.Equals("")))
            {
                return LanguageAbbreviation;
            }
            return result;
        }

        public static string AddChangeLangValue(string dic, string value, string LanguageAbbreviation)
        {
            if (dic != null)
            {
                if (LanguageAbbreviation != null && !LanguageAbbreviation.Equals(""))
                {
                    int pos = dic.IndexOf(sectionSeparator + LanguageAbbreviation + sectionSeparator);
                    if (pos != -1)
                    {
                        if (value == null || value.Equals(""))
                        {
                            return dic.Remove(pos, dic.IndexOf(sectionSeparator + LanguageAbbreviation + sectionSeparator, pos + 1) + (sectionSeparator.Length * 2) + LanguageAbbreviation.Length - pos);
                        }
                        return dic.Substring(0, pos + sectionSeparator.Length * 2 + LanguageAbbreviation.Length) + value + dic.Substring(dic.LastIndexOf(sectionSeparator + LanguageAbbreviation + sectionSeparator));
                    }
                    else
                    {
                        return dic + sectionSeparator + LanguageAbbreviation + sectionSeparator + value + sectionSeparator + LanguageAbbreviation + sectionSeparator;
                    }
                }
                return dic;
            }
            else if (LanguageAbbreviation != null && !LanguageAbbreviation.Equals("") && value != null && !value.Equals(""))
            {
                return sectionSeparator + LanguageAbbreviation + sectionSeparator + value + sectionSeparator + LanguageAbbreviation + sectionSeparator;
            }

            return "";
        }

        public static List<string> getValuesasList(string values)
        {
            List<string> result = new List<string>();
            if (values != null && !values.Equals(""))
            {
                int backit = 0;
                int pos = values.IndexOf(keySeparator);
                while (pos != -1)
                {
                    result.Add(values.Substring(backit, pos - backit));
                    backit = pos + keySeparator.Length;
                    pos = values.IndexOf(keySeparator, backit);
                }
            }

            return result;
        }

        public static string deleteContact(string contactContents, int conConpos)
        {
            int delpos = 0;
            for (int i = 0; i < conConpos; i++)
            {
                delpos = contactContents.IndexOf(keySeparator, delpos);
                if (delpos == -1)
                {
                    return contactContents;
                }
                delpos = delpos + keySeparator.Length;
            }
            int count = contactContents.IndexOf(keySeparator, delpos);
            count = count != -1 ? count - delpos + keySeparator.Length : contactContents.Length - delpos;

            return contactContents.Remove(delpos, count);
        }


        public static string deleteArticle(string articles, string articleId)
        {
            if (articles != null && articles != "" && articleId != null && articleId != "")
            {
                int posme = articles.IndexOf(keySeparator);
                int backme = 0;
                while (posme != -1)
                {
                    if (articles.Substring(backme, posme - backme).Equals(articleId))
                    {
                        return articles.Remove(backme, articleId.Length + keySeparator.Length);
                    }
                    backme = posme;
                    posme = articles.IndexOf(keySeparator);
                }
            }
            return articles;
        }


        public static DateTime stringToDatetime(string dateme, string format)
        {
            if (dateme != null && !dateme.Equals(""))
            {
                if (format == null || format.Equals(""))
                {
                    format = "dd/mm/yyyy";
                }
                int daypos = format.ToLower().IndexOf("d");
                int monthpos = format.ToLower().IndexOf("m");
                int yearpos = format.ToLower().IndexOf("y");

                int day = 0;
                int month = 0;
                int year = 0;

                if (daypos != -1 && monthpos != -1 && yearpos != -1)
                {
                    if (daypos < monthpos)
                    {
                        if (monthpos < yearpos)
                        {
                            if (int.TryParse(dateme.Substring(6, 4), out year))
                            {
                                if (int.TryParse(dateme.Substring(3, 2), out month))
                                {
                                    if (int.TryParse(dateme.Substring(0, 2), out day))
                                    {
                                        return new DateTime(year, month, day);
                                    }
                                }
                            }
                        }
                        else if (daypos < yearpos)
                        {
                            if (int.TryParse(dateme.Substring(3, 4), out year))
                            {
                                if (int.TryParse(dateme.Substring(8, 2), out month))
                                {
                                    if (int.TryParse(dateme.Substring(0, 2), out day))
                                    {
                                        return new DateTime(year, month, day);
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (int.TryParse(dateme.Substring(0, 4), out year))
                            {
                                if (int.TryParse(dateme.Substring(8, 2), out month))
                                {
                                    if (int.TryParse(dateme.Substring(5, 2), out day))
                                    {
                                        return new DateTime(year, month, day);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {// monthpos < daypos
                        if (daypos < yearpos)
                        {
                            if (int.TryParse(dateme.Substring(6, 4), out year))
                            {
                                if (int.TryParse(dateme.Substring(0, 2), out month))
                                {
                                    if (int.TryParse(dateme.Substring(3, 2), out day))
                                    {
                                        return new DateTime(year, month, day);
                                    }
                                }
                            }
                        }
                        else if (monthpos < yearpos)
                        {
                            if (int.TryParse(dateme.Substring(3, 4), out year))
                            {
                                if (int.TryParse(dateme.Substring(0, 2), out month))
                                {
                                    if (int.TryParse(dateme.Substring(8, 2), out day))
                                    {
                                        return new DateTime(year, month, day);
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (int.TryParse(dateme.Substring(0, 4), out year))
                            {
                                if (int.TryParse(dateme.Substring(5, 2), out month))
                                {
                                    if (int.TryParse(dateme.Substring(8, 2), out day))
                                    {
                                        return new DateTime(year, month, day);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return DateTime.Now;
        }
    }
}