using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Conversion;
using Locust.Data;
using Locust.Db;

namespace Locust.Test.Test
{
    public class test_da_nvarchar_max:BaseTest
    {
        public override void Test()
        {
            var _args = new { a = "alireza", b = CommandParameter.Output(SqlDbType.NVarChar, -1) };
            var dbr = DA.DefaultDb.ExecuteNonQuery("ust_test2", _args);
            if (dbr.Success)
            {
                var s = SafeClrConvert.ToString(_args.b.Value);
                System.Console.WriteLine("b: " + s);
            }
            else
            {
                System.Console.WriteLine(dbr.Exception.Message);
            }
        }
    }
}
