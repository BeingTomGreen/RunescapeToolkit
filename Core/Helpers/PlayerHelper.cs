using Core.Enums;
using Core.Extensions;
using System;
using System.Text.RegularExpressions;

namespace Core.Helpers
{
    public static class PlayerHelper
    {
        private static Regex _usernameRegex = new Regex("^[a-zA-Z0-9 _]{4,12}$");

        public static string CleanUsername(string username)
        {
            return username.Trim().Replace(" ", "_");
        }

        public static bool ValidateUsername(string username)
        {
            return _usernameRegex.IsMatch(username.Trim());
        }

        public static Uri BuildHighscoreUrl(string username, AccountType accountType = AccountType.Normal)
        {
            string highscoreUrl = "https://secure.runescape.com/m=hiscore_oldschool_{0}/index_lite.ws?player={1}";

            string accountTypeString = accountType.UrlValue();

            return new Uri(string.Format(highscoreUrl, accountTypeString, username));
        }
    }
}
