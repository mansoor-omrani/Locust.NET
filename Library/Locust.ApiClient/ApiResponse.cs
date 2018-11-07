using Locust.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Locust.ApiClient
{
    public class ApiResponse:ServiceResponse
    {
        public string Result { get; set; }
        public HttpWebResponse WebResponse { get; set; }
    }
}
