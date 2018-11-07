using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Logging;

namespace Locust.ApiClient
{
    public class ApiClientConfig
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string BaseAddress { get; set; }
        public ILogger Logger { get; set; }
    }
}
