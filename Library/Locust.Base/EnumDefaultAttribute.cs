using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Base
{
    [AttributeUsage(AttributeTargets.Enum, AllowMultiple = false)]
    public class EnumDefaultAttribute: Attribute
    {
        private string value;
        public string Value { get {  return value; } }
        public EnumDefaultAttribute(string value)
        {
            this.value = value;
        }
    }
}
