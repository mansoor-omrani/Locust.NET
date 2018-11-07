using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.ConnectionString
{
    public class InMemoryConnectionStringProvider : BaseConnectionStringProvider
    {
        public InMemoryConnectionStringProvider()
        {
            ActiveConnection = "ConStr";
        }
    }
}
