using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Mime
{
    public class MimeType
    {
        public int Id { get; set; }
        public int MimeId { get; set; }
        public string Extension { get; set; }
        public bool IsDefault { get; set; }
    }
}
