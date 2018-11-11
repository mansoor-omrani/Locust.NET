using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Locust.Conversion;

namespace Locust.Modules.Api.Service
{
    public static class ApiExtensions
    {
        public static string GetAccessToken(this HttpRequestBase request)
        {
            return SafeClrConvert.ToString(request.Headers["auth_token"]).Trim();
        }
        public static string GetClientKey(this HttpRequestBase request)
        {
            return SafeClrConvert.ToString(request.Headers["client_key"]).Trim();
        }
        public static string GetClientKeyHash(this HttpRequestBase request)
        {
            return SafeClrConvert.ToString(request.Headers["client_key_hash"]).Trim();
        }
    }
}
