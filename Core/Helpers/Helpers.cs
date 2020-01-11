using Core.Enums;

namespace Core.Helpers
{
    public static class Helpers
    {
        public static string GetAccountTypeString(AccountType accountType)
        {
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
                    accountTypeString = "normal";
                    break;
            }

            return accountTypeString;
        }
    }
}
