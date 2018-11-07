using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Locust.WebExtensions;

namespace Locust.Audit.Web
{
    public class WebAuditData:AuditData
    {
        public WebAuditData()
        {
            var context = HttpContext.Current;
            if (context != null)
            {
                this.IP = context.Request.GetClientIpAddress();
                this.Host = context.Request.UserHostName;
            }
        }
    }
}
