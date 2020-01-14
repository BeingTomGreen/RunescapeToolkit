using Core.Enums;
using System;
using System.Text.RegularExpressions;

namespace Core.Helpers
{
    public static class PlayerHelper
    {
        private static Regex _usernameRegex = new Regex("^[a-zA-Z0-9 _]{4,12}$");

        public static string GetAccountTypeDisplayString(AccountType accountType)
        {
            string accountTypeString;

            switch (accountType)
            {
                case AccountType.Normal:
                    accountTypeString = "Normal";
                    break;
                case AccountType.Ironman:
                    accountTypeString = "Ironman";
                    break;
                case AccountType.UltimateIronman:
                    accountTypeString = "Ultimate Ironman";
                    break;
                case AccountType.HardcoreIronman:
                    accountTypeString = "Hardcore Ironman";
                    break;
                case AccountType.DeadmanMode:
                    accountTypeString = "Deadman";
                    break;
                case AccountType.SeasonalDeadmanMode:
                    accountTypeString = "Seasonal Deadman";
                    break;
                default:
                    accountTypeString = "Normal";
                    break;
            }

            return accountTypeString;
        }

        public static bool ValidateUsername(string username)
        {
            return _usernameRegex.IsMatch(username.Trim());
        }

        public static Uri BuildHighscoreUrl(string username, AccountType accountType = AccountType.Normal)
        {
            string highscoreUrl = "https://secure.runescape.com/m=hiscore_oldschool_{0}/index_lite.ws?player={1}";

            string accountTypeString;

            switch (accountType)
            {
                case AccountType.Normal:
                    accountTypeString = "normal";
                    break;
                case AccountType.Ironman:
                    accountTypeString = "ironman";
                    break;
                case AccountType.UltimateIronman:
                    accountTypeString = "ultimate";
                    break;
                case AccountType.HardcoreIronman:
                    accountTypeString = "hardcore";
                    break;
                case AccountType.DeadmanMode:
                    accountTypeString = "deadman";
                    break;
                case AccountType.SeasonalDeadmanMode:
                    accountTypeString = "seasonal";
                    break;
                default:
                    accountTypeString = "Normal";
                    break;
            }

            return new Uri(string.Format(highscoreUrl, accountTypeString, username));
        }
    }
}
