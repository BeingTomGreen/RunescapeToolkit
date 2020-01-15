using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Core
{
    public static class API
    {
        private static HttpClient httpClient = new HttpClient();

        public static async Task<string> GetString(Uri url)
        {
            string results = "";

            try
            {
                results = await httpClient.GetStringAsync(url).ConfigureAwait(true);

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
