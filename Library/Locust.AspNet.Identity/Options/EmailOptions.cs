using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.AspNet.Identity.Options
{
    public class EmailOptions
    {
        public string Name { get; set; }
        public string Subject { get; set; }
        public string BodyFormat { get; set; }
    }
}
