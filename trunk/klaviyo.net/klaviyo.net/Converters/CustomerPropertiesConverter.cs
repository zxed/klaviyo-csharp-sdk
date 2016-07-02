using Newtonsoft.Json;
using System;

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

            writer.WritePropertyName("$email");
            serializer.Serialize(writer, ((CustomerProperties)value).Email);

            if (string.IsNullOrEmpty(((CustomerProperties)value).Id)
                && string.IsNullOrEmpty(((CustomerProperties)value).Email))
                throw new Exception("Need enter email or id!");

            writer.WritePropertyName("$first_name");
            serializer.Serialize(writer, ((CustomerProperties)value).FirstName);

            writer.WritePropertyName("$last_name");
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