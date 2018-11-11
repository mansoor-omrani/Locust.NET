using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Modules.Api.Service
{
    public static class CacheName
    {
        public static String Api { get { return "Cache.Api"; } }
        public static String ApiClient { get { return "Cache.ApiClient"; } }
        public static String ApiClientCustomerHub { get { return "Cache.ApiClientCustomerHub"; } }
        public static String ApiClientCustomer { get { return "Cache.ApiClientCustomer"; } }
        public static String ApiClientIP { get { return "Cache.ApiClientIP"; } }
        public static String Messages { get { return "Cache.Messages"; } }
        public static String ServiceSettings { get { return "Cache.ServiceSettings"; } }
        public static String ApiSettings { get { return "Cache.ApiSettings"; } }
    }
}
