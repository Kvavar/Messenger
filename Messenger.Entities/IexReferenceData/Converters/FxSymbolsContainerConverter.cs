using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Messenger.Entities.IexReferenceData.Converters
{
    public class FxSymbolsContainerConverter : JsonConverter<FxSymbolsContainer>
    {
        private const string CurrenciesName = "currencies";
        private const string PairsName = "pairs";

        public override void WriteJson(JsonWriter writer, FxSymbolsContainer value, JsonSerializer serializer)
        {
            throw new NotSupportedException("Convert to json is not supported.");
        }

        public override FxSymbolsContainer ReadJson(
            JsonReader reader, 
            Type objectType, 
            FxSymbolsContainer existingValue, 
            bool hasExistingValue,
            JsonSerializer serializer)
        {
            var container = JObject.Load(reader);
            if (!container.ContainsKey(CurrenciesName) || container[CurrenciesName] == null)
            {
                throw new InvalidOperationException("FX symbols json does not contain currencies.");
            }

            if (!container.ContainsKey(PairsName) || container[PairsName] == null)
            {
                throw new InvalidOperationException("FX symbols json does not contain currency pairs.");
            }

            var currencies = new Dictionary<string, FxCurrency>();
            foreach (var token in container[CurrenciesName])
            {
                var currency = token.ToObject<FxCurrency>();
                if (currency != null)
                {
                    currencies.Add(currency.Code, currency);
                }
            }

            var pairs = new List<FxPair>();

            foreach (var token in container[PairsName])
            {
                if (!token.HasValues)
                {
                    continue;
                }

                var fromCurrencyCode = token.Value<string>("fromCurrency");
                var toCurrencyCode = token.Value<string>("toCurrency");
                var symbol = token.Value<string>("symbol");
                if (string.IsNullOrWhiteSpace(fromCurrencyCode) 
                    || string.IsNullOrWhiteSpace(toCurrencyCode)
                    || string.IsNullOrWhiteSpace(symbol))
                {
                    continue;
                }

                if (!currencies.TryGetValue(fromCurrencyCode, out var fromCurrency)
                    || !currencies.TryGetValue(toCurrencyCode, out var toCurrency))
                {
                    continue;
                }

                var pair = new FxPair
                {
                    FromCurrency = fromCurrency,
                    ToCurrency = toCurrency,
                    Symbol = symbol
                };

                pairs.Add(pair);
            }

            return new FxSymbolsContainer
            {
                Currencies = currencies.Values.ToList(),
                Pairs = pairs
            };
        }
    }
}