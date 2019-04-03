﻿//bibaoke.com

using Less.Text;
using System.Text.RegularExpressions;

namespace Less.Html
{
    /// <summary>
    /// 背景
    /// </summary>
    public class Background
    {
        private static Regex UrlPattern
        {
            get;
            set;
        }

        /// <summary>
        /// url
        /// </summary>
        public string Url
        {
            get;
            internal set;
        }

        static Background()
        {
            Background.UrlPattern = @"url\((?<url>.*?)\)".ToRegex(
                RegexOptions.IgnoreCase |
                RegexOptions.Compiled |
                RegexOptions.ExplicitCapture);
        }

        internal Background(string value)
        {
            string[] values = value.SplitByWhiteSpace();

            foreach (string i in values)
            {
                Match matchUrl = Background.UrlPattern.Match(i);

                if (matchUrl.Success)
                {
                    this.Url = matchUrl.GetValue("url");
                }
            }
        }
    }
}
