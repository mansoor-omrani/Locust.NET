using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Caching
{
    public interface ICacheFactory
    {
        ICacheManager Get(object arg);
        List<object> GetNames();
    }
}
