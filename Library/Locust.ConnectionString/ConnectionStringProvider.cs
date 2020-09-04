using Locust.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Locust.ConnectionString
{
    public class ConnectionStringProvider: InstanceProvider<IConnectionStringProvider, ManualConnectionStringProvider>
    {
    }
}