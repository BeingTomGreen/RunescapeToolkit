using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;

namespace Core
{
    public static class API
    {
        private static HttpClient httpClient = new HttpClient();

        public static async Task<string> GetRequest(Uri url)
        {
            HttpResponseMessage results = await httpClient.GetAsync(url).ConfigureAwait(false);
            _ = results.EnsureSuccessStatusCode();

            return await results.Content.ReadAsStringAsync().ConfigureAwait(false);
        }
    }
}
