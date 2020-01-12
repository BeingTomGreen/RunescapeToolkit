using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Core.Enums;
using Core.Models;

namespace Core
{
    public static class API
    {
        private static HttpClient httpClient = new HttpClient();

        public static async Task<string> GetString(string url)
        {
            string results = "";

            try
            {
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



    }
}
