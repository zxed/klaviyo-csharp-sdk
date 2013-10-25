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

            writer.WritePropertyName("$id");
            serializer.Serialize(writer, ((CustomerProperties)value).Id);
            if (string.IsNullOrEmpty(((CustomerProperties)value).Id))
                throw new Exception("Id required!");

            writer.WritePropertyName("$email");
            serializer.Serialize(writer, ((CustomerProperties)value).Email);
            if (string.IsNullOrEmpty(((CustomerProperties)value).Email))
                throw new Exception("Email required!");

            writer.WritePropertyName("$first_name");
            serializer.Serialize(writer, ((CustomerProperties)value).FirstName);
            if (string.IsNullOrEmpty(((CustomerProperties)value).FirstName))
                throw new Exception("FirstName required!");

            writer.WritePropertyName("$last_name");
            serializer.Serialize(writer, ((CustomerProperties)value).LastName);
            if (string.IsNullOrEmpty(((CustomerProperties)value).LastName))
                throw new Exception("LastName required!");

            foreach (var item in ((CustomerProperties)value).NotRequiredProperties)
            {
                writer.WritePropertyName(item.Name);
                serializer.Serialize(writer, item.Value);
            }
            writer.WriteEndObject();
        }
    }
}
