using System.Collections.Generic;
using System.Threading.Tasks;
using Messenger.Entities.IexPricer;
using Newtonsoft.Json;

namespace Pricer.IexCloudProvider
{
    public class IexProvider : IIexProvider
    {
        private readonly IIexHttpClient _iexHttpClient;

        public IexProvider(IIexHttpClient iexHttpClient)
        {
            _iexHttpClient = iexHttpClient;
        }

        public async Task<IReadOnlyList<TimeseriesId>> GetAvailableIdsAsync()
        {
            var url = "time-series";
            var response = await _iexHttpClient.GetAsync(url);

            return JsonConvert.DeserializeObject<List<TimeseriesId>>(response);
        }
    }
}