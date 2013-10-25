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
                Type = "Order"
            };
            var list = new Dictionary<string, string>();
            list.Add("first field", "first value");
            list.Add("second field", "second value");
            ev.Properties.Items = new List<Property>() { new Property() {  ItemId = "1",
                 Name = "asdsad", Quantity = 1, UnitPrice = 1, TotalPrice = 1, 
                 NotRequiredProperties = list
            } };

            ev.CustomerProperties.Email = "test@test.com";
            ev.CustomerProperties.FirstName = "firstname";
            ev.CustomerProperties.LastName = "lastname";
            ev.Properties.Value = 0M;
            ev.Properties.OrderId = "12";
            ev.Categories = ev.Properties.Items.Select(obj => obj.Name).ToList();
            ev.UniqueCategories = ev.Categories.Distinct().ToList();
            ev.ItemCount = ev.Properties.Items.Count;
            gateway.Track(ev);
        }
    }
}
