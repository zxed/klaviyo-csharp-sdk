using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace klaviyo.net
{
    public class KlaviyoGateway
    {
        private Uri _baseAddressUri = new Uri("http://a.klaviyo.com/api/");

        private string _token = "";

        public KlaviyoGateway(string token)
        {
            _token = token;
        }

        public string Token
        {
            get {
                return _token;
            }
        }

        public SubmitStatus Track(object obj)
        {
            using (WebClient downloader = new WebClient())
            {
                UriTemplate uriTemplate = new UriTemplate("track?data={data}");
                IDictionary<string, string> parameters = new Dictionary<string, string>();

                System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                byte[] bytes = encoding.GetBytes(Newtonsoft.Json.JsonConvert.SerializeObject(obj));
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
