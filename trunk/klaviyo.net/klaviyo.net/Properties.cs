using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace klaviyo.net
{
    [DataContract]
    public class Properties
    {
        public Properties()
        {
            Items = new List<Property>();
            NotRequiredProperties = new List<NotRequiredProperty>();
        }

        [DataMember(Name = "$event_id")]
        public string EventId { get; set; }

        [DataMember(Name = "$value")]
        public decimal Value { get; set; }

        [DataMember(Name = "items")]
        public List<Property> Items { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<NotRequiredProperty> NotRequiredProperties { get; set; }
    }
}