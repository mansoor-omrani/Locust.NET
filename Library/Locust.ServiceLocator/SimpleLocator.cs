using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Locust.ServiceLocator
{
    public class SimpleLocator
    {
        protected static ISimpleServiceLocator _default;

        static SimpleLocator()
        {
            _default = new DefaultSimpleServiceLocator();
        }

        public static ISimpleServiceLocator Default
        {
            get { return _default; }
            set { _default = value; }
        }
    }
}
