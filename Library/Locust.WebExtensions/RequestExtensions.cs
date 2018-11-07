using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Locust.WebExtensions
{
    public static class RequestExtensions
    {
        public static bool IsJson(this HttpRequestBase request)
        {
            return string.Compare(request.ContentType, "application/json", StringComparison.OrdinalIgnoreCase) == 0 ||
                   string.Compare(request.ContentType, "application/json5", StringComparison.OrdinalIgnoreCase) == 0 ||
                   string.Compare(request.ContentType, "text/json", StringComparison.OrdinalIgnoreCase) == 0;
            
        }
        public static bool IsMultipartFormData(this HttpRequestBase request)
        {
            return string.Compare(request.ContentType, "multipart/form-data", StringComparison.OrdinalIgnoreCase) == 0 ||
                request.ContentType.IndexOf("multipart/form-data", StringComparison.OrdinalIgnoreCase) >= 0;

        }
    }
}
