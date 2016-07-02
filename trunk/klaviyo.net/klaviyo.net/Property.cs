using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace klaviyo.net
{
    [DataContract]
    public class Property
    {
        public Property()
        {
            NotRequiredProperties = new List<NotRequiredProperty>();
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<NotRequiredProperty> NotRequiredProperties { get; set; }
    }
}