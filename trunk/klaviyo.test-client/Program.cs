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
            peopleAPI();

        }
        static void peopleAPI()
        {
            KlaviyoGateway gateway = new KlaviyoGateway("9sc6fd");
            KlaviyoPeople pe = new KlaviyoPeople()
            {
                Token = gateway.Token,
            };
            var list = new List<NotRequiredProperty>();
            list.Add(new NotRequiredProperty("$email", "zeeomar@deffuse.com"));
            list.Add(new NotRequiredProperty("HBD_name", "TESTVAL"));
            pe.Properties.NotRequiredProperties.Add(new NotRequiredProperty("items", new List<Property>()));

            gateway.Identify(pe);
        }
        static void eventAPI()
        {
            KlaviyoGateway gateway = new KlaviyoGateway("test12");
            KlaviyoEvent ev = new KlaviyoEvent()
            {
                Token = gateway.Token,
                Event = "Order"
            };
            var list = new List<NotRequiredProperty>();
            list.Add(new NotRequiredProperty("first field", "first value"));
            list.Add(new NotRequiredProperty("second field", "second value"));
            ev.Properties.NotRequiredProperties.Add(new NotRequiredProperty("items", new List<Property>()));
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
