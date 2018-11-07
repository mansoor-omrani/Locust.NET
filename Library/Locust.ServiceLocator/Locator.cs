using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.ServiceLocator
{
    public static class Locator
    {
        private static IServiceLocator _default;
        public static IServiceLocator Default
        {
            get
            {
                if (_default == null)
                {
                    _default = new DefaultServiceLocator();
                }

                return _default;
            }
            set { _default = value; }
        }
    }
}
