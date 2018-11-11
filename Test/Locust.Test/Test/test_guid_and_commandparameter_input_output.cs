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
    public class test_guid_and_commandparameter_input_output:BaseTest
    {
        public override void Test()
        {
            var guid = Guid.NewGuid();
            var _args = new { p1 = CommandParameter.Guid(guid), p2 = CommandParameter.Output(SqlDbType.UniqueIdentifier) };
            var dbr = DA.DefaultDb.ExecuteNonQuery("ust_test1", _args);
            if (dbr.Success)
            {
                var s = SafeClrConvert.ToString(_args.p2.Value);
                System.Console.WriteLine("p2: " + s);
            }
            else
            {
                System.Console.WriteLine(dbr.Exception.Message);
            }
        }
    }
}
