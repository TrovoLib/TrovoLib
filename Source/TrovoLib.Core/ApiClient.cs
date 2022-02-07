using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TrovoLib.Core
{
    public class ApiClient
    {
        private readonly HttpClient Http;

        public ApiClient()
        {
            Http = new HttpClient();
        }

        public async Task<string> ApiRequest(string url, string method, string clientId, string body)
        {
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(url),
                Method = new HttpMethod(method)
            };

            if (!string.IsNullOrEmpty(clientId))
            {
                request.Headers.Add("Client-ID", clientId);
            }

            if (body != null)
                request.Content = new StringContent(body, Encoding.UTF8, "application/json");

            var response = await Http.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            return null;
        }
    }
}