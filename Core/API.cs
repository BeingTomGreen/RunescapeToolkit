using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Core.Enums;

namespace Core
{
    public static class API
    {
        private static string highscoreUrl = "https://secure.runescape.com/m=hiscore_oldschool_{0}/index_lite.ws?player={1}";

        private static HttpClient httpClient = new HttpClient();

        public static async Task<string> QueryHighscores(string username, AccountType accountType = AccountType.Normal)
        {
            string url = BuildHighscoresUrl(username, accountType);

            string results = "";

            try
            {
                //string Results = await HttpClient.GetStringAsync(Url);
                results = await httpClient.GetStringAsync(url);

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            httpClient.Dispose();

            return results;
        }

        public static string BuildHighscoresUrl(string username, AccountType accountType = AccountType.Normal)
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
                    accountTypeString = "Normal";
                    break;
            }

            return string.Format(highscoreUrl, accountTypeString, username);
        }

    }
}
