using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Extensions.EntityFramework
{
    public static class Extensions
    {
        public static SqlParameter CreateQueryParam(this System.Data.Entity.DbContext db, string name, object value)
        {
            return new SqlParameter(name, value);
        }
        public static SqlParameter CreateQueryParam(this System.Data.Entity.DbContext db, string name, SqlDbType type, object value, ParameterDirection direction = ParameterDirection.Input)
        {
            var result = new SqlParameter(name, type);

            result.Direction = direction;

            result.Value = value;

            return result;
        }
        public static SqlParameter CreateQueryParam(this System.Data.Entity.DbContext db, string name, SqlDbType type, int size, object value, ParameterDirection direction = ParameterDirection.Input)
        {
            var result = new SqlParameter(name, type);

            result.Direction = direction;
            result.Size = size;
            result.Value = value;

            return result;
        }

    }
}
