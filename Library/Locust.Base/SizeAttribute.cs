using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Base
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class SizeAttribute : Attribute
    {
        public int? Value { get; set; }
        public SizeAttribute(int value)
        {
            Value = value;
        }
        public SizeAttribute(string value)
        {
            this.Value = string.Compare(value, "max", StringComparison.OrdinalIgnoreCase) == 0 ? -1: System.Convert.ToInt32(value);
        }
    }
}
