using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Base
{
    public class AnyComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x == null)
            {
                if (y == null)
                {
                    return 0;
                }

                return -1;
            }
            else
            {
                if (y == null)
                {
                    return 1;
                }
            }

            var xc = x as IComparable;

            if (xc != null)
            {
                return xc.CompareTo(y);
            }

            return x.Equals(y) ? 0 : x.GetHashCode().CompareTo(y.GetHashCode());
        }
        private static AnyComparer instance;
        public static AnyComparer Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AnyComparer();
                }

                return instance;
            }
        }
    }
}
