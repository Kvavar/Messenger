using System;
using Newtonsoft.Json;

namespace Messenger.Entities.IexReferenceData
{
    public class IexSymbol
    {
        [JsonProperty("symbol")] public string Symbol { get; set; }
        [JsonProperty("date")] public DateTime GeneratedAt { get; set; }
        [JsonProperty("isEnabled")] public bool IsEnabled { get; set; }
    }
}