using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.AspNet.Identity.Models
{
    [Table("CompanyTbl")]
    public class Company
    {
        public int CompanyId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
    }
}
