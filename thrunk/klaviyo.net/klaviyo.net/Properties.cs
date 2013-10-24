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
        [DataMember(Name = "$value")]
        public decimal Value { get; set; }

        [DataMember(Name = "order_id")]
        public string OrderId { get; set; }

        [DataMember(Name = "items")]
        public virtual List<Property> Items { get; set; }
    }
}
