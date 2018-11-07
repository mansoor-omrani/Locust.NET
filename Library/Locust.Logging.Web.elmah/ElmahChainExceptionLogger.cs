using Locust.ConnectionString;
using Locust.Logging.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Logging.Web.elmah
{
    public static class ElmahChainExceptionLogger
    {
        public static IExceptionLogger GetChain(IConnectionStringProvider constrProvider, IMemoryLogger memoryLogger)
        {
            var _null = new NullExceptionLogger();
            var _memory = new MemoryExceptionLogger(memoryLogger, _null);
            var _sql = new SqlServerExceptionLogger(constrProvider, _memory);
            var result = new ElmahExceptionLogger(_sql);

            return result;
        }
    }
}
