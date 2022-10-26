using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace klaviyo.net
{
    [DataContract]
    public class CustomerProperties
    {
        public CustomerProperties()
        {
            NotRequiredProperties = new List<NotRequiredProperty>();
        }

        [DataMember(Name = "$id")]
        public string Id { get; set; }

        [DataMember(Name = "$email")]
        public string Email { get; set; }

        [DataMember(Name = "$phone_number")]
        public string PhoneNumber { get; set; }

        [DataMember(Name = "$first_name")]
        public string FirstName { get; set; }

        [DataMember(Name = "$last_name")]
        public string LastName { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<NotRequiredProperty> NotRequiredProperties { get; set; }
    }
}
