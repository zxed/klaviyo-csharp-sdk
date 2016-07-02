using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace klaviyo.net
{
    [DataContract]
    public class Properties
    {
        public Properties()
        {
            NotRequiredProperties = new List<NotRequiredProperty>();
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "$event_id")]
        public string EventId { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "$value")]
        public decimal? Value { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<NotRequiredProperty> NotRequiredProperties { get; set; }
    }
}