using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using Locust.ConnectionString;
using Locust.CircuitBreaker;
using Locust.Logging;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using Locust.Db.SqlServer;

namespace Locust.Db.SqlServerFull
{
    public class SqlServerFullDbHelper : SqlServerDbHelper
    {
        public SqlServerFullDbHelper(IConnectionStringProvider cnnProvider, IDbContextInfoProvider contextInfoProvider, ICircuitBreakerStore circuitBreakerStore, ICircuitBreakerFactory circuitBreakerFactory, IExceptionLogger logger) : base(cnnProvider, contextInfoProvider, circuitBreakerStore, circuitBreakerFactory, logger)
        {
        }
        #region Statics
        public new static SqlServerFullDbHelper GetDefault()
        {
            var _cnn = new AppConfigConnectionStringProvider();
            var cbf = new AppConfigCircuitBreakerFactory();
            var cbs = new AppDomainCircuitBreakerStore();
            var cip = new NoContextInfoProvider();
            var memLogger = new DefaultMemoryLogger();
            var logger = new DebugExceptionLogger();

            return new SqlServerFullDbHelper(_cnn, cip, cbs, cbf, logger);
        }
        public new static void ConfigureDA()
        {
            try
            {
                DA.DefaultDb = GetDefault();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        #endregion
        public override DbResult<int> ExecuteBatch(string batch)
        {
            IDbConnection conn;

            var result = GetConnection<int>(out conn);

            if (result.Success)
            {
                using (conn)
                {
                    try
                    {
                        var server = new Server(new ServerConnection(conn as SqlConnection));

                        result.Data = server.ConnectionContext.ExecuteNonQuery(batch);
                        result.Success = true;
                    }
                    catch (Exception ex)
                    {
                        result.Success = false;
                        result.Exception = ex;
                        result.MessageType = DbMessageType.Error;

                        Log(ex, "ExecuteBatch");
                    }
                }
            }

            return result;
        }
    }
}
