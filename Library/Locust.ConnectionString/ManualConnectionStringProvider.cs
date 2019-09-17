using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.ConnectionString
{
    public class ManualConnectionStringProvider : BaseConnectionStringProvider
    {
        public ManualConnectionStringProvider()
        {
            ActiveConnection = "Default";
        }
    }
}
