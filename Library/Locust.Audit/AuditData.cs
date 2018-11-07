using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Audit
{
    public class AuditData: BaseAuditData
    {
        public int ApplicationId { get; set; }
        public string Username { get; set; }
        public string RoleName { get; set; }
    }
    public class WebAuditData: AuditData
    {
        public string IP { get; set; }
        public string BrowserName { get; set; }
        public string BrowserVersion { get; set; }
        public string SessionId { get; set; }
        public string AssignedCode { get; set; }
    }
    public class ContextBasedAuditData : BaseAuditData
    {
    }
}
