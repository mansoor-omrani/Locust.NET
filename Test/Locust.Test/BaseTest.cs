using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Test
{
    public abstract class BaseTest
    {
        public virtual string Title { get; set; }

        public abstract void Test();
    }
}
