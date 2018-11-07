using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Audit
{
    public interface IAuditor
    {
        void Audit(BaseAuditData context);
        void Audit(string code, string data = "");
        Task AuditAsync(BaseAuditData context);
        Task AuditAsync(string code, string data = "");
    }
}
