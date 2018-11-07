using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Db;

namespace Locust.Audit.Web
{
    public class WebDirectAuditor:DirectAuditor
    {
        public WebDirectAuditor(IDbHelper db) : base(db)
        {
        }
    }
}
