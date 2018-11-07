using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Locust.ApiClient
{
    public class ApiRequest
    {
        public HttpMethod Method { get; set; }
        public string Api { get; set; }
        public string ContentType { get; set; }
        public byte[] Body { get; set; }
    }
}
