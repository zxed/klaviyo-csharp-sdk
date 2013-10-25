using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace klaviyo.net.Converters
{
    public class PropertiesConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Properties));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("$event_id");
            serializer.Serialize(writer, ((Properties)value).EventId);

            writer.WritePropertyName("$value");
            serializer.Serialize(writer, ((Properties)value).Value);
          
            foreach (var item in ((Properties)value).NotRequiredProperties)
            {
                writer.WritePropertyName(item.Name);
                serializer.Serialize(writer, item.Value);
            }
            writer.WriteEndObject();
        }
    }
}
