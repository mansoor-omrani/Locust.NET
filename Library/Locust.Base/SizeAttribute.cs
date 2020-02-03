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
        public SizeAttribute(int size)
        {
            Value = size;
        }
    }
}
