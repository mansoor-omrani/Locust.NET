using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Db;

namespace Locust.Test.Test
{
    public class test_locust_conn:BaseTest
    {
        public override void Test()
        {
            var constr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
            IDbConnection conn;
            var dbr = DA.DefaultDb.GetConnection(out conn);
            if (dbr.Success)
            {
                System.Console.WriteLine("connection succeeded");
            }
            else
            {
                System.Console.WriteLine(dbr.Exception.Message);
            }
        }
    }
}
