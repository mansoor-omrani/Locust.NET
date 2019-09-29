using Locust.ConnectionString;
using Locust.Conversion;
using Locust.Extensions;
using Locust.Service;
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
    
    public class SqlServerLogger : BaseLogger, ILogManager
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
        protected virtual string GetInsertSql()
        {
            return
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
        }
        protected virtual void FinalizeInsertCommand(SqlCommand cmd)
        {
        }
        protected virtual void Log(string category, string message, string member, int line, string filePath)
        {
            if (ConnectionStringProvider != null)
            {
                try
                {
                    var query = GetInsertSql();

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

                                FinalizeInsertCommand(cmd);

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
        protected virtual string GetPagingSql()
        {
            return "usp1_ApplicationLogs_get_page";
        }
        protected virtual string GetPurgeSql()
        {
            return "usp1_ApplicationLogs_purge";
        }
        protected virtual void FinalizePagingCommand(SqlCommand cmd)
        {
        }
        protected virtual void FinalizePurgeCommand(SqlCommand cmd)
        {
        }
        protected virtual LogItem Transform(IDataReader reader)
        {
            var result = new LogItem
            {
                Row = SafeClrConvert.ToLong(reader["Row"]),
                Id = SafeClrConvert.ToInt(reader["Id"]),
                Member = SafeClrConvert.ToString(reader["Member"]),
                Category = SafeClrConvert.ToString(reader["Category"]),
                Message = SafeClrConvert.ToString(reader["Message"]),
                FilePath = SafeClrConvert.ToString(reader["FilePath"]),
                LogDate = SafeClrConvert.ToDateTime(reader["LogDate"]),
                Line = SafeClrConvert.ToInt(reader["Line"]),
            };

            return result;
        }
        public virtual LoggerGetPageResponse GetPage(LoggerGetPageRequest request)
        {
            var response = new LoggerGetPageResponse();

            if (ConnectionStringProvider != null)
            {
                try
                {
                    var query = GetPagingSql();

                    var constr = ConnectionStringProvider.GetConnectionString();

                    if (!string.IsNullOrEmpty(constr))
                    {
                        using (var con = new SqlConnection(constr))
                        {
                            using (var cmd = new SqlCommand(query, con))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;

                                cmd.Parameters.AddInputOutput("@CurrentPage", request.CurrentPage);
                                cmd.Parameters.AddInputOutput("@PageSize", request.PageSize);
                                cmd.Parameters.AddOutput("@RecordCount", SqlDbType.Int);
                                cmd.Parameters.AddOutput("@PageCount", SqlDbType.Int);
                                cmd.Parameters.AddInput("@Member", request.Member);
                                cmd.Parameters.AddInput("@Category", request.Category);
                                cmd.Parameters.AddInput("@Message", request.Message);
                                cmd.Parameters.AddInput("@FromDate", request.FromDate);
                                cmd.Parameters.AddInput("@ToDate", request.ToDate);
                                cmd.Parameters.AddInput("@OrderBy", request.OrderBy);
                                cmd.Parameters.AddInput("@OrderDir", request.OrderDir);

                                FinalizePagingCommand(cmd);

                                con.Open();
                                var reader = cmd.ExecuteReader();

                                response.Data.CurrentPage = SafeClrConvert.ToInt(cmd.Parameters[0].Value);
                                response.Data.PageSize = SafeClrConvert.ToInt(cmd.Parameters[1].Value);
                                response.Data.RecordCount = SafeClrConvert.ToLong(cmd.Parameters[2].Value);
                                response.Data.PageCount = SafeClrConvert.ToInt(cmd.Parameters[3].Value);
                                response.Data.Items = new List<LogItem>();

                                while (reader.Read())
                                {
                                    var item = Transform(reader);

                                    response.Data.Items.Add(item);
                                }
                            }
                        }

                        response.Succeeded();
                    }
                    else
                    {
                        response.Message = "ConnectionStringProvider has no connection string";
                        response.Info = $"Provider = {ConnectionStringProvider.GetType().Name}";
                        response.SetStatus("NoConStr");
                    }
                }
                catch (Exception e)
                {
                    response.Failed(e);
                }
            }
            else
            {
                response.Message = "No ConnectionStringProvider is specified";
                response.SetStatus("NoConStrProvider");
            }

            return response;
        }
        public virtual LoggerPurgeResponse Purge(LoggerPurgeRequest request)
        {
            var response = new LoggerPurgeResponse();

            if (ConnectionStringProvider != null)
            {
                try
                {
                    var query = GetPurgeSql();

                    var constr = ConnectionStringProvider.GetConnectionString();

                    if (!string.IsNullOrEmpty(constr))
                    {
                        using (var con = new SqlConnection(constr))
                        {
                            using (var cmd = new SqlCommand(query, con))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;

                                cmd.Parameters.AddOutput("@Result", SqlDbType.NVarChar, 100);
                                cmd.Parameters.AddOutput("@Info", SqlDbType.NVarChar);
                                cmd.Parameters.AddInput("@FromDate", request.FromDate);
                                cmd.Parameters.AddInput("@ToDate", request.ToDate);

                                FinalizePurgeCommand(cmd);

                                con.Open();
                                cmd.ExecuteNonQuery();

                                response.SetStatus(cmd.Parameters[0].Value);
                                response.Info = SafeClrConvert.ToString(cmd.Parameters[1].Value);
                            }
                        }
                    }
                    else
                    {
                        response.Message = "ConnectionStringProvider has no connection string";
                        response.Info = $"Provider = {ConnectionStringProvider.GetType().Name}";
                        response.SetStatus("NoConStr");
                    }
                }
                catch (Exception e)
                {
                    response.Failed(e);
                }
            }
            else
            {
                response.Message = "No ConnectionStringProvider is specified";
                response.SetStatus("NoConStrProvider");
            }

            return response;
        }
    }
}
