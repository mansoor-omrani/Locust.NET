using Locust.ConnectionString;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Test.Mvc
{
    public static class Utils
    {
        public static IConnectionStringProvider CreateInMemoryConnectionStringProvider()
        {
            var result = new InMemoryConnectionStringProvider();
            var connectionStrings = ConfigurationManager.AppSettings["ManualConnectionStrings"] ?? "";

            if (!string.IsNullOrEmpty(connectionStrings))
            {
                result.Load(JsonConvert.DeserializeObject<Dictionary<string, string>>(connectionStrings));
            }

            return result;
        }
    }
}
