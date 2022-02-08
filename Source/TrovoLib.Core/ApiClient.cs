using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TrovoLib.Core
{
    public class ApiClient : IDisposable
    {
        private readonly HttpClient Http;

        public ApiClient()
        {
            Http = new HttpClient();
        }

        public async Task<Tr> ApiRequest<Tr, Tb>(string url, string method, string clientId, Tb? body = null) where Tb : struct
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
            {
                var json = JsonConvert.SerializeObject(body);

                request.Content = new StringContent(json, Encoding.UTF8, "application/json");
            }

            var response = await Http.SendAsync(request);

            response.EnsureSuccessStatusCode();

            var jsResponse = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Tr>(jsResponse);
        }

        public void Dispose()
        {
            Http.Dispose();
        }
    }
}