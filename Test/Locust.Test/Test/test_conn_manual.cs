using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Test.Test
{
    public class test_conn_manual : BaseTest
    {
        public override void Test()
        {
            var connstr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
            var conn = new SqlConnection(connstr);
            try
            {
                conn.Open();
                System.Console.WriteLine("conn success");
            }
            catch(Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
            
        }
    }
}
