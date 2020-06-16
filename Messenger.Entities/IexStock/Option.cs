using System;
using Newtonsoft.Json;

namespace Messenger.Entities.IexStock
{
    public class Option
    {
        [JsonProperty("symbol")] public string Symbol { get; set; }
        [JsonProperty("id")] public string Id { get; set; }
        [JsonProperty("expirationDate")] public DateTime ExpirationDate { get; set; }
        [JsonProperty("contractSize")] public int ContractSize { get; set; }
        [JsonProperty("strikePrice")] public decimal StrikePrice { get; set; }
        [JsonProperty("closingPrice")] public decimal ClosingPrice { get; set; }
        [JsonProperty("side")] public OptionSide Side { get; set; }
        [JsonProperty("type")] public OptionType Type { get; set; }
        [JsonProperty("volume")] public decimal Volume { get; set; }
        [JsonProperty("openInterest")] public decimal OpenInterest { get; set; }
        [JsonProperty("bid")] public decimal Bid { get; set; }
        [JsonProperty("ask")] public decimal Ask { get; set; }
        [JsonProperty("lastUpdated")] public DateTime LastUpdated { get; set; }
        [JsonProperty("isAdjusted")] public bool IsAdjusted { get; set; }
    }
}