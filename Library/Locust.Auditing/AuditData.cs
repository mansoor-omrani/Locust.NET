using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Auditing
{
    public class AuditData: BaseAuditData
    {
        public int ApplicationId { get; set; }
        public string UserName { get; set; }
        public string RoleName { get; set; }
        public string Lang { get; set; }
        public int? RelatedRecordId { get; set; }
    }
    public class ContextBasedAuditData : BaseAuditData
    {
    }
}
