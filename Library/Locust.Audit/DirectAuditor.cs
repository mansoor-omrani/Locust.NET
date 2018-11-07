using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Db;

namespace Locust.Audit
{
    public class DirectAuditor:IAuditor
    {
        private IDbHelper db;

        public IDbHelper Db
        {
            get { return db; }
            set { db = value; }
        }
        public DirectAuditor(IDbHelper db)
        {
            this.db = db;
        }
        public void Audit(BaseAuditData data)
        {
            Audit((AuditData)data);
        }

        public void Audit(string code, string data = "")
        {
            Audit(new AuditData {Code = code, Data = data});
        }

        public virtual void Audit(AuditData data)
        {
            var cmd = db.GetCommand("usp0_Audit_direct");

            db.ExecuteNonQuery(cmd, data);
        }
        public Task AuditAsync(BaseAuditData data)
        {
            return AuditAsync((AuditData)data);
        }

        public Task AuditAsync(string code, string data = "")
        {
            return AuditAsync(new AuditData { Code = code, Data = data });
        }

        public virtual async Task AuditAsync(AuditData data)
        {
            var cmd = db.GetCommand("usp0_Audit_direct");

            await db.ExecuteNonQueryAsync(cmd, data);
        }
    }
}
