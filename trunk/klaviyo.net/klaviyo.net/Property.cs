using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

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
