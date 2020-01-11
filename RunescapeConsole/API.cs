using System;
using System.Net.Http;
using System.Threading.Tasks;
using Core.Enums;
using Core.Helpers;
using Core.Models;

namespace Highscores
{
    static class API
    {
        private static string highscoreUrl = "https://secure.runescape.com/m=hiscore_oldschool_{0}/index_lite.ws?player={1}";

        private static HttpClient httpClient = new HttpClient();

        public static async Task<string> QueryHighscores(Player player)
        {
            string url = BuildHighscoresUrl(player.Username, player.AccountType);

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

            return results.ToString();
        }

        private static string BuildHighscoresUrl(string username, AccountType accountType)
        {
            string accountTypeString = Helpers.GetAccountTypeString(accountType);

            return string.Format(highscoreUrl, accountTypeString, username);
        }
    }
}
