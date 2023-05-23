using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace eventmanager.Models
{
    public class ApiClient
    {
        private readonly HttpClient client;

        public ApiClient(string baseAddress)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(baseAddress);
        }

        public async Task<T> GetAsync<T>(string endpoint)
        {
            var response = await client.GetAsync(endpoint);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(content);
            }
            else
            {
                throw new Exception($"Failed to get data from {endpoint}, status code: {response.StatusCode}");
            }
        }
    }

}
