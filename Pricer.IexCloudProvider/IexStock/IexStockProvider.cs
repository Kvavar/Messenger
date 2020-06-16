using System;
using System.Threading.Tasks;
using Messenger.Entities.IexStock;
using Newtonsoft.Json;

namespace Pricer.IexCloudProvider.IexStock
{
    public class IexStockProvider : IIexStockProvider
    {
        private const string Endpoint = "stock";
        public const string Suffix = "options";

        private readonly IexHttpClient _httpClient;

        public IexStockProvider(IexHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Option> GetOptionAsync(string symbol)
        {
            if (string.IsNullOrWhiteSpace(symbol))
            {
                throw new ArgumentException($"Argument {nameof(symbol)} cannot ba empty.");
            }

            var url = $"{Endpoint}/{symbol}/{Suffix}";
            var response = await _httpClient.GetAsync(url);

            return JsonConvert.DeserializeObject<Option>(response);
        }
    }
}