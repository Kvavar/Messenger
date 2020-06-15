using System.Collections.Generic;
using Messenger.Entities.IexReferenceData.Converters;
using Newtonsoft.Json;

namespace Messenger.Entities.IexReferenceData
{
    [JsonConverter(typeof(FxSymbolsContainerConverter))]
    public class FxSymbolsContainer
    {
        [JsonProperty("currencies")] public IReadOnlyList<FxCurrency> Currencies { get; set; }
        [JsonProperty("pairs")] public IReadOnlyList<FxPair> Pairs{ get; set; }
    }
}