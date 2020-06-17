using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Messenger.Entities.IexStock;
using Newtonsoft.Json;

namespace Pricer.IexCloudProvider.IexStock
{
    public class IexOptionProvider : IIexOptionProvider
    {
        private const string Endpoint = "stock";
        public const string Suffix = "options";

        private readonly IIexHttpClient _httpClient;

        public IexOptionProvider(IIexHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IReadOnlyList<DateTime>> GetAvailableExpirationsAsync(string symbol)
        {
            if (string.IsNullOrWhiteSpace(symbol))
            {
                throw new ArgumentException($"Argument {nameof(symbol)} cannot be empty.");
            }

            var url = $"{Endpoint}/{symbol}/{Suffix}";
            var response = await _httpClient.GetAsync(url);

            var result = JsonConvert.DeserializeObject<List<string>>(response)
                .Select(e => DateTime.ParseExact(e, "yyyyMM", CultureInfo.InvariantCulture))
                .ToList();

            return result;
        }

        public async Task<Option> GetOptionAsync(string symbol, DateTime expiration, OptionSide side)
        {
            if (string.IsNullOrWhiteSpace(symbol))
            {
                throw new ArgumentException($"Argument {nameof(symbol)} cannot be empty.");
            }

            if (side == OptionSide.None)
            {
                throw new NotSupportedException($"Side {nameof(side)}is not supported.");
            }

            var exp = expiration.ToString("yyyyMM", CultureInfo.InvariantCulture);
            var optionSide = side.ToString().ToLower();

            var url = $"{Endpoint}/{symbol}/{Suffix}/{exp}/{optionSide}";
            var response = await _httpClient.GetAsync(url);

            var result = JsonConvert.DeserializeObject<Option>(response);

            return result;
        }
    }
}