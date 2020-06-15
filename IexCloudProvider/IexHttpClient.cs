using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Messenger.Infrastructure.Configuration.Options.Pricers;
using Microsoft.Extensions.Options;

namespace Pricer.IexCloudProvider
{
    public class IexHttpClient : IIexHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _publicToken;

        public IexHttpClient(HttpClient httpClient, IOptions<IexPricerOptions> options)
        {
            string baseUrl = options.Value.Api.BaseUrl ?? throw new ArgumentException($"{nameof(baseUrl)}");
            string version = options.Value.Api.ApiVersion ?? throw new ArgumentException($"{nameof(version)}");
            string  publicToken = options.Value.Api.PublicToken ?? throw new ArgumentException($"{nameof(publicToken)}");

            _httpClient = httpClient;
            _publicToken = publicToken;

            _httpClient.BaseAddress = new Uri($"{baseUrl}{version}/");
            _httpClient.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<string> GetAsync(string url)
        {
            AddPublicToken(ref url);
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        private void AddPublicToken(ref string url)
        {
            AddArgument(ref url, "token", _publicToken);
        }

        private void AddFormat(ref string url, ResponseFormatType format)
        {
            switch (format)
            {
                case ResponseFormatType.Json:
                    AddArgument(ref url, "format", "json");
                    break;
                case ResponseFormatType.Csv:
                    AddArgument(ref url, "format", "csv");
                    break;
                case ResponseFormatType.Plain:
                    AddArgument(ref url, "format", "psv");
                    break;
                default:
                    throw new NotSupportedException($"{nameof(format)} is not supported.");
            }
        }

        private void AddArgument(ref string url, string name, string value)
        {
            url = url.Contains("?") ? $"{url}&{name}={value}" : $"{url}?{name}={value}";
        }
    }
}
