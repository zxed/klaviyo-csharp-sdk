using klaviyo.net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace klaviyo.test_client
{
    class Program
    {
        static void Main(string[] args)
        {
            KlaviyoGateway gateway = new KlaviyoGateway("test12");
            KlaviyoEvent ev = new KlaviyoEvent()
            {
                Token = gateway.Token,
                Event = "Order"
            };
            var list = new List<NotRequiredProperty>();
            list.Add(new NotRequiredProperty() { Name = "first field", Value = "first value" });
            list.Add(new NotRequiredProperty() { Name = "second field", Value = "second value" });
            ev.Properties.Items = new List<Property>() { new Property() { 
                 NotRequiredProperties = list
            } };
            ev.Properties.EventId = "1";
            ev.Properties.Value = 0M;

            ev.CustomerProperties.Email = "test@test.com";
            ev.CustomerProperties.FirstName = "firstname";
            ev.CustomerProperties.LastName = "lastname";
            ev.Properties.Value = 0M;
            gateway.Track(ev);
        }
    }
}
