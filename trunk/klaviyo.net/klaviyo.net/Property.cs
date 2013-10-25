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
            NotRequiredProperties = new Dictionary<string, string>();
        }

        [DataMember(Name = "item_id")]
        public string ItemId { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "quantity")]
        public int Quantity { get; set; }

        [DataMember(Name = "unit_price")]
        public decimal UnitPrice { get; set; }

        [DataMember(Name = "total_price")]
        public decimal TotalPrice { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, string> NotRequiredProperties { get; set; }
    }
}
