﻿using klaviyo.net.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace klaviyo.net
{
    public class KlaviyoGateway
    {
        private Uri _baseAddressUri = new Uri("https://a.klaviyo.com/api/");

        private string _token = "";

        public KlaviyoGateway(string token)
        {
            _token = token;
        }

        public string Token
        {
            get
            {
                return _token;
            }
        }

        public SubmitStatus Track(object obj)
        {
            using (WebClient downloader = new WebClient())
            {
                UriTemplate uriTemplate = new UriTemplate("track?data={data}");
                IDictionary<string, string> parameters = new Dictionary<string, string>();

                UTF8Encoding encoding = new UTF8Encoding();
                List<JsonConverter> converters = new List<JsonConverter>();

                converters.Add(new KlaviyoEventConverter());
                converters.Add(new CustomerPropertiesConverter());
                converters.Add(new PropertiesConverter());
                converters.Add(new PropertyConverter());

                byte[] bytes = encoding.GetBytes(JsonConvert.SerializeObject(obj, converters.ToArray()));
                string sBase64 = Convert.ToBase64String(bytes);
                parameters.Add("data", sBase64);
                Uri formattedUri = uriTemplate.BindByName(_baseAddressUri, parameters);
                string str = "";

                using (Stream myStream = downloader.OpenRead(formattedUri))
                {
                    using (StreamReader sr = new StreamReader(myStream))
                    {
                        str = sr.ReadToEnd();
                    }
                }

                if (str == "1") return SubmitStatus.Success;
                else return SubmitStatus.Fail;
            }
        }

        public SubmitStatus Identify(object obj)
        {
            using (WebClient downloader = new WebClient())
            {
                UriTemplate uriTemplate = new UriTemplate("identify?data={data}");
                IDictionary<string, string> parameters = new Dictionary<string, string>();

                System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
                List<JsonConverter> converters = new List<JsonConverter>();

                converters.Add(new KlaviyoPeopleConverter());
                converters.Add(new PropertiesConverter());
                converters.Add(new PropertyConverter());

                byte[] bytes = encoding.GetBytes(Newtonsoft.Json.JsonConvert.SerializeObject(obj, converters.ToArray()));
                string sBase64 = System.Convert.ToBase64String(bytes);
                parameters.Add("data", sBase64);
                Uri formattedUri = uriTemplate.BindByName(_baseAddressUri, parameters);
                string str = "";

                using (Stream myStream = downloader.OpenRead(formattedUri))
                {
                    using (StreamReader sr = new StreamReader(myStream))
                    {
                        str = sr.ReadToEnd();
                    }
                }

                if (str == "1") return SubmitStatus.Success;
                else return SubmitStatus.Fail;
            }
        }
    }
}