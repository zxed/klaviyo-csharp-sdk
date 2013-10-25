using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace klaviyo.net.Converters
{
    public class KlaviyoEventConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(KlaviyoEvent));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteStartObject();

            writer.WritePropertyName("token");
            serializer.Serialize(writer, ((KlaviyoEvent)value).Token);

            writer.WritePropertyName("event");
            serializer.Serialize(writer, ((KlaviyoEvent)value).Event);

            writer.WritePropertyName("customer_properties");
            serializer.Serialize(writer, ((KlaviyoEvent)value).CustomerProperties);

            writer.WritePropertyName("properties");
            serializer.Serialize(writer, ((KlaviyoEvent)value).Properties);

            writer.WritePropertyName("time");
            serializer.Serialize(writer, ((KlaviyoEvent)value).Time);

            writer.WriteEndObject();
        }
    }
}
