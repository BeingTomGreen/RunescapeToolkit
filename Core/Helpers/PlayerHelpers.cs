using Core.Enums;
using System.Linq;
using System.Text.RegularExpressions;

namespace Core.Helpers
{
    public static class PlayerHelpers
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

        public static string CleanUsername(string username)
        {
            string cleanUsername = new string(username.Where(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c) || c == '-' || c == '_').ToArray());

            cleanUsername = cleanUsername.Replace(" ", "_");

            return cleanUsername;
        }

        public static bool ValidateUsername(string username)
        {
            return _usernameRegex.IsMatch(username.Trim());
        }
    }
}
