using Locust.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Auditing
{
    public interface IAuditor
    {
        ServiceResponse<string> Audit(BaseAuditData context);
        ServiceResponse<string> Audit(string code, string data = "");
        Task<ServiceResponse<string>> AuditAsync(BaseAuditData context);
        Task<ServiceResponse<string>> AuditAsync(string code, string data = "");
    }
}
