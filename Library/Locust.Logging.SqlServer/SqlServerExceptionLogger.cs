using Locust.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using Locust.ConnectionString;
using System.Data;
using System.Data.SqlClient;
using Locust.Extensions;
using Newtonsoft.Json;
using System.Collections;

namespace Locust.Logging.SqlServer
{
    public class SqlServerExceptionLogger : BaseExceptionLogger
    {
        public IConnectionStringProvider ConnectionStringProvider { get; set; }
        public string LogTableName { get; set; }
        public SqlServerExceptionLogger()
        {
            Init(new AppConfigConnectionStringProvider());
        }
        public SqlServerExceptionLogger(BaseExceptionLogger next) : base(next)
        {
            Init(new AppConfigConnectionStringProvider());
        }
        public SqlServerExceptionLogger(IConnectionStringProvider constrProvider)
        {
            Init(constrProvider);
        }
        public SqlServerExceptionLogger(IConnectionStringProvider constrProvider, BaseExceptionLogger next):base(next)
        {
            Init(constrProvider);
        }
        private void Init(IConnectionStringProvider constrProvider)
        {
            if (constrProvider == null)
            {
                throw new ArgumentNullException("constrProvider");
            }

            ConnectionStringProvider = constrProvider;

            LogTableName = "[dbo].[ExceptionLog]";
        }
        protected override bool LogExceptionInternal(Exception ex,
                                string info = "",
                                [CallerMemberName] string memberName = "",
                                [CallerFilePath] string sourceFilePath = "",
                                [CallerLineNumber] int sourceLineNumber = 0)
        {
            if (ConnectionStringProvider != null)
            {
                var query =
    $@"INSERT INTO {LogTableName}
    ([Message]
    ,[Source]
    ,[Member]
    ,[FilePath]
    ,[Line]
    ,[StackTrace]
    ,[Data]
    ,[Info])
VALUES
    (case when len(rtrim(ltrim(isnull(@Message, '')))) = 0 then null else @Message end
    ,case when len(rtrim(ltrim(isnull(@Source, '')))) = 0 then null else @Source end
    ,case when len(rtrim(ltrim(isnull(@Member, '')))) = 0 then null else @Member end
    ,case when len(rtrim(ltrim(isnull(@FilePath, '')))) = 0 then null else @FilePath end
    ,case when len(rtrim(ltrim(isnull(@Line, '')))) = 0 then null else @Line end
    ,case when len(rtrim(ltrim(isnull(@StackTrace, '')))) = 0 then null else @StackTrace end
    ,case when len(rtrim(ltrim(isnull(@Data, '')))) = 0 then null else @Data end
    ,case when len(rtrim(ltrim(isnull(@Info, '')))) = 0 then null else @Info end)";

                var constr = ConnectionStringProvider?.GetConnectionString();

                if (!string.IsNullOrEmpty(constr))
                {
                    var data = "";

                    if (ex.Data != null)
                    {
                        foreach (DictionaryEntry de in ex.Data)
                        {
                            data += $"{(data == "" ? "" : ", ")}{de.Key}={de.Value}";
                        }
                    }

                    using (var con = new SqlConnection(constr))
                    {
                        using (var cmd = new SqlCommand(query, con))
                        {
                            cmd.CommandType = CommandType.Text;

                            cmd.Parameters.AddWithValue("@Message", ex.ToString(" --> "));
                            cmd.Parameters.AddWithValue("@Source", ex.Source ?? "");
                            cmd.Parameters.AddWithValue("@Member", memberName ?? "");
                            cmd.Parameters.AddWithValue("@FilePath", sourceFilePath ?? "");
                            cmd.Parameters.AddWithValue("@Line", sourceLineNumber);
                            cmd.Parameters.AddWithValue("@StackTrace", ex.StackTrace ?? "");
                            cmd.Parameters.AddWithValue("@Data", data);
                            cmd.Parameters.AddWithValue("@Info", info ?? "");

                            con.Open();
                            cmd.ExecuteNonQuery();
                        }

                        return true;
                    }
                }
                else
                {
                    Throw($"No ConnectionString: Provider = {ConnectionStringProvider.GetType().Name}");
                }
            }
            else
            {
                Throw($"No ConnectionString Provider");
            }

            return false;
        }
    }
}
