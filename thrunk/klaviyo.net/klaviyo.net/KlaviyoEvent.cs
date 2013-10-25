using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace klaviyo.net
{
    [DataContract]
    public class KlaviyoEvent
    {
        public KlaviyoEvent()
        {
            CustomerProperties = new CustomerProperties();
            Properties = new Properties();
            UniqueCategories = new List<string>();
            Categories = new List<string>();

            DateTime d1 = new DateTime(1970, 1, 1);
            DateTime d2 = DateTime.Now.ToUniversalTime();
            TimeSpan ts = new TimeSpan(d2.Ticks - d1.Ticks);
            Time = Math.Round(ts.TotalMilliseconds / 1000, 0).ToString();
        }

        [DataMember(Name = "token")]
        public string Token { get; set; }

        [DataMember(Name = "event")]
        public string Type { get; set; }

        [DataMember(Name = "customer_properties")]
        public virtual CustomerProperties CustomerProperties { get; set; }

        [DataMember(Name = "properties")]
        public Properties Properties { get; set; }

        [DataMember(Name = "Item Categories")]
        public List<string> Categories { get; set; }

        [DataMember(Name = "Unique Item Categories")]
        public List<string> UniqueCategories { get; set; }

        [DataMember(Name = "Item Count")]
        public int ItemCount { get; set; }

        [DataMember(Name = "time")]
        public string Time { get; private set; }
    }
}