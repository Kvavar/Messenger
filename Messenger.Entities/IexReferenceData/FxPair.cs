using Newtonsoft.Json;

namespace Messenger.Entities.IexReferenceData
{
    public class FxPair
    {
        [JsonProperty("fromCurrency")] public FxCurrency FromCurrency { get; set; }
        [JsonProperty ("toCurrency")] public FxCurrency ToCurrency { get; set; }
        [JsonProperty("symbol")] public string Symbol { get; set; }
    }
}