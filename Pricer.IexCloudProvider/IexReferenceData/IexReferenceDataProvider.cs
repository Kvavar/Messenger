using System.Threading.Tasks;
using Messenger.Entities.IexReferenceData;
using Newtonsoft.Json;

namespace Pricer.IexCloudProvider.IexReferenceData
{
    public class IexReferenceDataProvider : IIexReferenceDataProvider
    {
        private const string Endpoint = "ref-data";
        public const string Suffix = "symbols";
        private readonly IIexHttpClient _httpClient;

        public IexReferenceDataProvider(IIexHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<FxSymbolsContainer> GetAvailableFxSymbolsAsync()
        {
            var url = $"{Endpoint}/fx/{Suffix}";
            var response = await _httpClient.GetAsync(url);

            return JsonConvert.DeserializeObject<FxSymbolsContainer>(response);
        }
    }
}