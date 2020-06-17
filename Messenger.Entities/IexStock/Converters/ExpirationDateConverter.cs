using System;
using System.Globalization;
using Newtonsoft.Json;

namespace Messenger.Entities.IexStock.Converters
{
    public class ExpirationDateConverter : JsonConverter<DateTime>
    {
        public override void WriteJson(JsonWriter writer, DateTime value, JsonSerializer serializer)
        {
            throw new NotSupportedException("Write operation is not supported.");
        }

        public override DateTime ReadJson(
            JsonReader reader, 
            Type objectType,
            DateTime existingValue, 
            bool hasExistingValue,
            JsonSerializer serializer)
        {
            var value = reader.Value;
            if (value != null && value is string exp)
            {
                return DateTime.ParseExact(exp, "yyyyMMdd", CultureInfo.InvariantCulture);
            }

            throw new InvalidOperationException("Unable to parse expiration date.");
        }
    }
}