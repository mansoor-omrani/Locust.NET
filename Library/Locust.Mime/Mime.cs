using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Mime
{
    public class Mime
    {
        public int Id { get; set; }
        public string Source { get; set; }
        public string Value { get; set; }
        public string CharSet { get; set; }
        public string Extensions { get; set; }
        public bool Compressible { get; set; }
    }
}
