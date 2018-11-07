using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;

namespace Locust.AspNet.CustomHeaders
{
    public class CustomHeadersModule : IHttpModule
    {
        private static Lazy<List<CustomHeader>> headers;
        static List<CustomHeader> GetMyCustomHeaders()
        {
            var customHeaders = (CustomHeadersSection)ConfigurationManager.GetSection("CustomHeaders");

            return customHeaders.Headers.GetAll();
        }
        static List<CustomHeader> GetSystemWebServerCustomHeaders()
        {
            var result = new List<CustomHeader>();
            try
            {
                var systemWebServer = ConfigurationManager.GetSection("system.webServer");
                var systemWebServerXml = (string)systemWebServer?.GetType().GetField("_rawXml", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(systemWebServer);

                if (!string.IsNullOrEmpty(systemWebServerXml))
                {
                    var xml = new XmlDocument();

                    xml.LoadXml(systemWebServerXml);

                    if (xml.HasChildNodes)
                    {
                        var headers = xml.ChildNodes[0]?["httpProtocol"]?["customHeaders"];

                        if (headers != null)
                        {
                            foreach (XmlElement node in headers.ChildNodes)
                            {
                                result.Add(new CustomHeader
                                {
                                    Name = node.Attributes["name"]?.Value,
                                    Value = node.Attributes["value"]?.Value,
                                    Add = node.Name.ToLower() == "add"
                                });
                            }
                        }
                    }
                }
            }
            finally { }

            return result;
        }
        static CustomHeadersModule()
        {
            headers = new Lazy<List<CustomHeader>>(GetSystemWebServerCustomHeaders);
        }
        public static void FinalizeHeaders()
        {
            foreach (var header in headers.Value)
            {
                if (!header.Add)
                {
                    if (!string.IsNullOrEmpty(header.Name))
                    {
                        HttpContext.Current?.Response?.Headers.Remove(header.Name);
                    }
                }
                //else
                //{
                //    if (!string.IsNullOrEmpty(header.Name))
                //    {
                //        HttpContext.Current?.Response?.Headers.Set(header.Name, header.Value);
                //    }
                //}
            }
        }
        public void Init(HttpApplication context)
        {
            context.PreSendRequestHeaders += OnPreSendRequestHeaders;
        }
        void OnPreSendRequestHeaders(object sender, EventArgs e)
        {
            FinalizeHeaders();
        }
        public void Dispose() { }
    }
}
