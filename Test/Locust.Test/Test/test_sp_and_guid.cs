using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Data;
using Locust.Db;

namespace Locust.Test.Test
{
    public class test_sp_and_guid: BaseTest
    {
        void test2()
        {
            var args = new Dictionary<string, object>();

            args.Add("Result", CommandParameter.Output(SqlDbType.VarChar, 50));
            args.Add("Args", CommandParameter.Output(SqlDbType.NVarChar, 1000));
            args.Add("execMode", 0);
            args.Add("ClientKey", CommandParameter.Guid("F9FA3F42-7568-4FDC-AF12-A88994997596"));
            //(args["ClientKey"] as GuidCommandParameter).Value = "F9FA3F42-7568-4FDC-AF12-A88994997596";
            var dbr = DA.DefaultDb.ExecuteSingle("usp1_ApiClient_GetByKey", (IDataReader reader) =>
            {
                var result = new Locust.Modules.Api.Model.ApiClient.Full();
                result.Read(reader);
                return result;
            }, args);

            if (dbr.Success)
            {
                switch (dbr.MessageType)
                {
                    case MessageType.SingleSuccess:
                        //Console.WriteLine(dbr.Data.ClientKey);
                        //Console.WriteLine(JsonConvert.SerializeObject(dbr.Data));
                        Console.WriteLine(dbr.Data.ToJson());
                        break;
                    case MessageType.SingleNotFound:
                        Console.WriteLine("Not found");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Error: {0}", dbr.Exception.Message);
            }
        }
        void test1()
        {
            var cnnstr = "Data Source=server\\I2k14,61129;Initial Catalog=TASSBase;User ID=admin;Password=adm321(;Connect Timeout=3";
            using (var con = new SqlConnection(cnnstr))
            {
                using (var cmd = new SqlCommand("usp1_ApiClient_GetByKey", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    cmd.Parameters.Add(new SqlParameter("@result", SqlDbType.VarChar, 50));
                    cmd.Parameters.Add(new SqlParameter("@args", SqlDbType.NVarChar, 1000));
                    cmd.Parameters.AddWithValue("@execMode", 0);
                    cmd.Parameters.Add(new SqlParameter("@ClientKey", SqlDbType.UniqueIdentifier));
                    cmd.Parameters[0].Direction = ParameterDirection.Output;
                    cmd.Parameters[1].Direction = ParameterDirection.Output;
                    cmd.Parameters[3].Value = new System.Data.SqlTypes.SqlGuid("F9FA3F42-7568-4FDC-AF12-A88994997596");
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    var c = new Locust.Modules.Api.Model.ApiClient.Full();
                    while (reader.Read())
                    {
                        c.Read(reader);
                    }
                    con.Close();
                    Console.WriteLine(c.ToJson());
                }
            }
        }
        public override void Test()
        {
            test1();
            Console.WriteLine();
            test2();
        }
    }
}
