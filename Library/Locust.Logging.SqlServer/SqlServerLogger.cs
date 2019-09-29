using Locust.ConnectionString;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Logging.SqlServer
{
    public class SqlServerLogger : BaseLogger
    {
        public IConnectionStringProvider ConnectionStringProvider { get; set; }
        public string LogTableName { get; set; }
        #region ctor
        public SqlServerLogger()
        {
            Init(new AppConfigConnectionStringProvider());
        }
        public SqlServerLogger(BaseLogger next) : base(next)
        {
            Init(new AppConfigConnectionStringProvider());
        }
        public SqlServerLogger(IConnectionStringProvider constrProvider)
        {
            Init(constrProvider);
        }
        public SqlServerLogger(IConnectionStringProvider constrProvider, BaseLogger next) : base(next)
        {
            Init(constrProvider);
        }
        private void Init(IConnectionStringProvider constrProvider)
        {
            ConnectionStringProvider = constrProvider ?? throw new ArgumentNullException("constrProvider");

            LogTableName = "[dbo].[ApplicationLogs]";
        }
        #endregion
        protected override void LogCategoryInternal(string data)
        {
        }

        protected override void LogInternal(string data)
        {
        }
        protected void Log(string category, string message, string member, int line, string filePath)
        {
            if (ConnectionStringProvider != null)
            {
                try
                {
                    var query =
    $@"INSERT INTO {LogTableName}
    ([LogDate]
    ,[Member]
    ,[Line]
    ,[FilePath]
    ,[Category]
    ,[Message])
VALUES
    (@LogDate
    ,case when len(rtrim(ltrim(isnull(@Member, '')))) = 0 then null else @Member end
    ,case when len(rtrim(ltrim(isnull(cast(@Line as varchar(20)), '')))) = 0 then null else @Line end
    ,case when len(rtrim(ltrim(isnull(@FilePath, '')))) = 0 then null else @FilePath end
    ,case when len(rtrim(ltrim(isnull(@Category, '')))) = 0 then null else @Category end
    ,case when len(rtrim(ltrim(isnull(@Message, '')))) = 0 then null else @Message end)";

                    var constr = ConnectionStringProvider.GetConnectionString();

                    if (!string.IsNullOrEmpty(constr))
                    {
                        using (var con = new SqlConnection(constr))
                        {
                            using (var cmd = new SqlCommand(query, con))
                            {
                                cmd.CommandType = CommandType.Text;

                                cmd.Parameters.AddWithValue("@LogDate", Now.Value);
                                cmd.Parameters.AddWithValue("@Member", member ?? "");
                                cmd.Parameters.AddWithValue("@Message", message ?? "");
                                cmd.Parameters.AddWithValue("@Category", category ?? "");
                                cmd.Parameters.AddWithValue("@FilePath", filePath ?? "");
                                cmd.Parameters.AddWithValue("@Line", line);

                                con.Open();
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    else
                    {
                        Throw($"No ConnectionString: Provider = {ConnectionStringProvider.GetType().Name}");
                    }
                }
                catch (Exception e)
                {
                    Throw("Logging failed!", e);
                }
            }
            else
            {
                Throw($"No ConnectionString Provider");
            }
        }
        public override void Log(object log)
        {
            if (log != null)
            {
                var x = SerializeLog(log);

                Log(null, x, null, 0, null);

                if (Next != null)
                {
                    Next.Log(log);
                }
            }
        }
        public override void LogCategory(object category = null, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            if (category != null)
            {
                var _category = SerializeLogCategory(category);

                Log(_category, null, memberName, sourceLineNumber, sourceFilePath);

                if (Next != null)
                {
                    Next.LogCategory(category, memberName, sourceFilePath, sourceLineNumber);
                }
            }
        }
    }
}
