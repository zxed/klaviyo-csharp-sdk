using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace klaviyo.net.Converters
{
    public class PropertyConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Property));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteStartObject();

            writer.WritePropertyName("item_id");
            serializer.Serialize(writer, ((Property)value).ItemId);

            writer.WritePropertyName("name");
            serializer.Serialize(writer, ((Property)value).Name);

            writer.WritePropertyName("quantity");
            serializer.Serialize(writer, ((Property)value).Quantity);

            writer.WritePropertyName("unit_price");
            serializer.Serialize(writer, ((Property)value).UnitPrice);

            writer.WritePropertyName("total_price");
            serializer.Serialize(writer, ((Property)value).TotalPrice);

            foreach (var item in ((Property)value).NotRequiredProperties)
            {
                writer.WritePropertyName(item.Key);
                serializer.Serialize(writer, item.Value);
            }
            writer.WriteEndObject();
        }
    }
}
