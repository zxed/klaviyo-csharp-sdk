using Newtonsoft.Json;
using System;

namespace klaviyo.net.Converters
{
    public class KlaviyoPeopleConverter : JsonConverter
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
            if (string.IsNullOrEmpty(((KlaviyoEvent)value).Token))
                throw new Exception("Token required!");

            writer.WritePropertyName("properties");
            serializer.Serialize(writer, ((KlaviyoEvent)value).Properties);

            writer.WriteEndObject();
        }
    }
}