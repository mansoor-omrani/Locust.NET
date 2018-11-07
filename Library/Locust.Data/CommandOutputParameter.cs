using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Data
{
    public class CommandOutputParameter : CommandParameter
    {
        public CommandOutputParameter(SqlDbType dbtype, int size = 0)
        {
            Direction = ParameterDirection.Output;
            DbType = dbtype;
            if (size > 0 || ((dbtype == SqlDbType.NVarChar || dbtype == SqlDbType.VarChar) && size == -1))
                Size = size;
        }
    }
    public class CommandInputOutputParameter : CommandParameter
    {
        public CommandInputOutputParameter(SqlDbType dbtype, int size = 0)
        {
            Direction = ParameterDirection.InputOutput;
            DbType = dbtype;
            if (size > 0 || ((dbtype == SqlDbType.NVarChar || dbtype == SqlDbType.VarChar) && size == -1))
                Size = size;
        }
    }
}
