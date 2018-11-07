using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Db;
using Locust.Service;

namespace Locust.Auditing
{
#warning ContextBasedAuditor class is not complete yet. Its 'Audit' methods return a fake result.
    public class ContextBasedAuditor:IAuditor
    {
        public IDbHelper Db { get; set; }
        public ContextBasedAuditor(IDbHelper db)
        {
            this.Db = db;
        }
        public virtual ServiceResponse<string> Audit(BaseAuditData data)
        {
            return Audit((ContextBasedAuditData)data);
        }
        public virtual ServiceResponse<string> Audit(string code, string data = "")
        {
            return Audit(new ContextBasedAuditData { Code = code, Data = data });
        }
        public virtual ServiceResponse<string> Audit(ContextBasedAuditData data)
        {
            var result = new ServiceResponse<string>();
            var cmd = Db.GetCommand("usp0_Audit_by_context");

            Db.ExecuteNonQuery(cmd, data);

            return result;
        }
        public Task<ServiceResponse<string>> AuditAsync(BaseAuditData data)
        {
            return AuditAsync((ContextBasedAuditData)data);
        }

        public Task<ServiceResponse<string>> AuditAsync(string code, string data = "")
        {
            return AuditAsync(new ContextBasedAuditData { Code = code, Data = data });
        }

        public virtual async Task<ServiceResponse<string>> AuditAsync(ContextBasedAuditData data)
        {
            var result = new ServiceResponse<string>();
            var cmd = Db.GetCommand("usp0_Audit_by_context");

            await Db.ExecuteNonQueryAsync(cmd, data);

            return result;
        }
    }
}
