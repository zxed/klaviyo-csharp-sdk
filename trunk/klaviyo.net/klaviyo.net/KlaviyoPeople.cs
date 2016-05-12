using System.Runtime.Serialization;

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