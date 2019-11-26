using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Base
{
    public class DefaultObjectEqualityComparer : IEqualityComparer
    {
        public new bool Equals(object x, object y)
        {
            return Object.Equals(x, y);
        }

        public int GetHashCode(object obj)
        {
            return obj?.GetHashCode() ?? 0;
        }
    }
}
