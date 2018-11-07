using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Tracing
{
    public class SqlError
    {
        public int Line { get; set; }
        public int Number { get; set; }
        public string Procedure { get; set; }
        public int Severity { get; set; }
        public int State { get; set; }
        public string Args { get; set; }
        public string Message { get; set; }
    }
}
