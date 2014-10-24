using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace klaviyo.net.Converters
{
    public class PropertiesConverter : JsonConverter
    {
        private PropertyType propertyType;

        public PropertiesConverter(PropertyType propertyTypeValue)
        {
            propertyType = propertyTypeValue;
        }

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
            bool requiredNotMet = true;


            writer.WriteStartObject();
            switch (propertyType)
            {
                case PropertyType.Event:
                    

                    if (!string.IsNullOrEmpty(((Properties)value).EventId))
                    {
                        writer.WritePropertyName("$event_id");
                        serializer.Serialize(writer, ((Properties)value).EventId);
                        requiredNotMet = false;
                    }

                    if (((Properties)value).Value.HasValue)
                    {
                        writer.WritePropertyName("$value");
                        serializer.Serialize(writer, ((Properties)value).Value);
                    }

                    foreach (var item in ((Properties)value).NotRequiredProperties)
                    {
                        writer.WritePropertyName(item.Name);
                        serializer.Serialize(writer, item.Value);
                    }
                    if (requiredNotMet)
                    {
                        throw new System.ArgumentException("event id is required", "required");
                    }
                    break;
                case PropertyType.People:

                    if (!string.IsNullOrEmpty(((Properties)value).Email))
                    {
                        writer.WritePropertyName("$email");
                        serializer.Serialize(writer, ((Properties)value).Email);
                        requiredNotMet = false;
                    }

                    if (!string.IsNullOrEmpty(((Properties)value).Id))
                    {
                        writer.WritePropertyName("$id");
                        serializer.Serialize(writer, ((Properties)value).Id);
                        requiredNotMet = false;
                    }


                    if (requiredNotMet)
                    {
                        throw new System.ArgumentException("unique email or id is required", "required");
                    }
                    break;
                default:
                    break;
            }



            writer.WriteEndObject();
        }
    }
}
