using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Application.Base
{
    public enum DbType
    {
        NotSpecified, SqlServer, MicrosoftAccess, MySql, SqLite, Oracle, PostgreSql, DB2, MongoDb, Cassandra
    }
    public class AppModuleDbConfig
    {
        public string DbName { get; set; }
        public string DbPath { get; set; }
        public string DbVersion { get; set; }
        public DbType DbType { get; set; }
    }
    public class AppModuleConfig
    {
        public string ConnectionString { get; set; }
        public string AppModuleNameOrPath { get; set; }
        public string Version { get; set; }
        public AppModuleDbConfig DbConfig { get; protected set; }
        public AppModuleConfig()
        {
            DbConfig = new AppModuleDbConfig();
        }
    }
}
