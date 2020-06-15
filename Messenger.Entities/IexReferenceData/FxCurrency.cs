using Newtonsoft.Json;

namespace Messenger.Entities.IexReferenceData
{
    public class FxCurrency
    {
        [JsonProperty("code")] public string Code { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
    }
}