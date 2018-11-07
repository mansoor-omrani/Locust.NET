using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Db;

namespace Locust.Audit
{
    public class ContextBasedAuditor:IAuditor
    {
        private IDbHelper db;

        public IDbHelper Db
        {
            get { return db; }
            set { db = value; }
        }
        public ContextBasedAuditor(IDbHelper db)
        {
            this.db = db;
        }
        public virtual void Audit(BaseAuditData data)
        {
            var cmd = db.GetCommand("usp0_Audit_by_context");

            db.ExecuteNonQuery(cmd, data);
        }

        public virtual void Audit(string code, string data = "")
        {
            Audit(new BaseAuditData { Code = code, Data = data });
        }
    }
}
