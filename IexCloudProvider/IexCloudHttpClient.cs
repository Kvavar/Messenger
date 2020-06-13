using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Pricer.IexCloudProvider
{
    public class IexCloudHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _priceUrl = string.Empty;

        public IexCloudHttpClient()
        {
            _httpClient = new HttpClient {BaseAddress = new Uri("")};
            _httpClient.DefaultRequestHeaders.Add("Content-Type", "application/json");
        }

        public async Task<decimal> GetLatestPriceAsync(string code, string tenor)
        {
            var response = await _httpClient.GetAsync(_priceUrl);

            response.EnsureSuccessStatusCode();

            await using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<decimal>(responseStream);
        }
    }
}
