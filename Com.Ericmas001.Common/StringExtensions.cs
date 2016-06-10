using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Com.Ericmas001.Common
{
    public static class StringExtensions
    {
        public static string InfoBetween(this string text, string before, string after, int startindex = 0)
        {
            var ideb = text.IndexOf(before, startindex, StringComparison.Ordinal) + before.Length;
            if (ideb < before.Length)
                return null;

            var ifin = text.IndexOf(after, ideb, StringComparison.Ordinal);
            return ifin < 0 ? null : text.Substring(ideb, ifin - ideb);
        }

        public static string AllInfoBefore(this string text, string keyword, int startindex = 0)
        {
            var ifin = text.IndexOf(keyword, startindex, StringComparison.Ordinal);
            return ifin < startindex ? null : text.Remove(ifin);
        }

        public static string AllInfoAfter(this string text, string keyword, int startindex = 0)
        {
            var ideb = text.IndexOf(keyword, startindex, StringComparison.Ordinal) + keyword.Length;
            return ideb < keyword.Length ? null : text.Substring(ideb);
        }

        public static string InfoBefore(this string text, string keyword, int length, int startindex = 0)
        {
            var info = text.AllInfoBefore(keyword, startindex);
            if (info == null)
                return null;

            return info.Length <= length ? info : info.Substring(info.Length - length); 
        }

        public static string InfoAfter(this string text, string keyword, int length, int startindex = 0)
        {
            var info = text.AllInfoAfter(keyword, startindex);
            if (info == null)
                return null;

            return info.Length <= length ? info : info.Remove(length);
        }

        public static string RemoveTags(this string s, char tagCharOpen, char tagCharClose)
        {
            // Faster than regex: http://dotnetperls.com/remove-html-tags

            var array = new char[s.Length];
            var arrayIndex = 0;
            var inside = false;

            foreach (var c in s)
            {
                if (c == tagCharOpen)
                {
                    inside = true;
                    continue;
                }
                if (c == tagCharClose)
                {
                    inside = false;
                    continue;
                }

                if (inside)
                    continue;

                array[arrayIndex] = c;
                arrayIndex++;
            }
            return new string(array, 0, arrayIndex);
        }

        public static string RemoveTagsHtml(this string s)
        {
            return s.RemoveTags('<', '>');
        }

        public static string RemoveTagsBbCode(this string s)
        {
            return s.RemoveTags('[', ']');
        }

        public static string CapitalizeFirstLetter(this string s)
        {
            return char.ToUpper(s[0]) + s.Substring(1);
        }

        public static string RemoveExtraSpaces(this string s)
        {
            return Regex.Replace(s, @"\s+", " ").Trim();
        }
    }
}
