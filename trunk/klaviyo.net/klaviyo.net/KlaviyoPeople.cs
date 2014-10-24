using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace klaviyo.net
{
    [DataContract]
    public class KlaviyoPeople
    {
        public KlaviyoPeople()
        {
            Properties = new Properties();
        }

        [DataMember(Name = "token")]
        public string Token { get; set; }

        [DataMember(Name = "properties")]
        public Properties Properties { get; set; }


    }
}