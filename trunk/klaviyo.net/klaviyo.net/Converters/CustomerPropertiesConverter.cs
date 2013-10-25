using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace klaviyo.net.Converters
{
    public class CustomerPropertiesConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(CustomerProperties));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteStartObject();

            writer.WritePropertyName("email");
            serializer.Serialize(writer, ((CustomerProperties)value).Email);

            writer.WritePropertyName("first_name");
            serializer.Serialize(writer, ((CustomerProperties)value).FirstName);

            writer.WritePropertyName("last_name");
            serializer.Serialize(writer, ((CustomerProperties)value).LastName);

            foreach (var item in ((CustomerProperties)value).NotRequiredProperties)
            {
                writer.WritePropertyName(item.Name);
                serializer.Serialize(writer, item.Value);
            }
            writer.WriteEndObject();
        }
    }
}
