using System;
using System.Text.RegularExpressions;

namespace Botana
{
    public static class HtmlString
    {
        public static string getHtmlString(string url, string s1, string s2)
        {
            System.Net.WebClient wc = new System.Net.WebClient();
            string totalHtml = wc.DownloadString(url);

            string returnString = Regex.Split(Regex.Split(totalHtml, s1)[1], s2)[0];

            return returnString;

        }
    }
}