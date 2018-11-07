using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace Locust.ConnectionString
{
    public class AppConfigConnectionStringProvider : BaseConnectionStringProvider
    {
        public AppConfigConnectionStringProvider()
        {
            ActiveConnection = ConfigurationManager.AppSettings["ActiveConnection"] ?? "ConStr";
        }
        
        public override void Load()
        {
            base.Clear();

            foreach (ConnectionStringSettings cnnStr in ConfigurationManager.ConnectionStrings)
            {
                connectionStrings.Add(cnnStr.Name, cnnStr.ConnectionString);
            }
        }
    }
}