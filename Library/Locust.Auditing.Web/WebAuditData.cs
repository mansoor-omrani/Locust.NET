using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Auditing.Web
{
    public class WebAuditData : AuditData
    {
        public string IP { get; set; }
        public string BrowserName { get; set; }
        public string BrowserVersion { get; set; }
        public string SessionId { get; set; }
        // AssignedCode is a code that a web application optinally assigns to each member to distinguish them.
        // this code can be used mostly for tracking purposes.
        public string AssignedCode { get; set; }
    }
}
