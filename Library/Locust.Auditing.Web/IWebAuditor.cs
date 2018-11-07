using Locust.Service;
using Locust.WebTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Auditing.Web
{
    public interface IWebAuditor: IAuditor
    {
        IHttpContextProvider HttpContextProvider { get; }
        ServiceResponse<string> Audit(WebAuditData data);
        Task<ServiceResponse<string>> AuditAsync(WebAuditData data);
    }
}
