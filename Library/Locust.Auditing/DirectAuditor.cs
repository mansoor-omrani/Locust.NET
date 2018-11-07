using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Db;
using Locust.Service;

namespace Locust.Auditing
{
    public class DirectAuditor:IAuditor
    {
        public IDbHelper Db { get; set; }
        public DirectAuditor(IDbHelper db)
        {
            this.Db = db;
        }
        public ServiceResponse<string> Audit(BaseAuditData data)
        {
            return Audit((AuditData)data);
        }

        public ServiceResponse<string> Audit(string code, string data = "")
        {
            return Audit(new AuditData {Code = code, Data = data});
        }

        public virtual ServiceResponse<string> Audit(AuditData data)
        {
            var result = new ServiceResponse<string>();
            var cmd = Db.GetCommand("usp0_Audit_direct");

            Db.ExecuteNonQuery(cmd, data);

            return result;
        }
        public Task<ServiceResponse<string>> AuditAsync(BaseAuditData data)
        {
            return AuditAsync((AuditData)data);
        }

        public Task<ServiceResponse<string>> AuditAsync(string code, string data = "")
        {
            return AuditAsync(new AuditData { Code = code, Data = data });
        }

        public virtual async Task<ServiceResponse<string>> AuditAsync(AuditData data)
        {
            var result = new ServiceResponse<string>();
            var cmd = Db.GetCommand("usp0_Audit_direct");

            await Db.ExecuteNonQueryAsync(cmd, data);
            return result;
        }
    }
}
