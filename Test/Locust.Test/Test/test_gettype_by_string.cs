using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Test.Test
{
    public class test_gettype_by_string:BaseTest
    {
        public override void Test()
        {
            try
            {
                var s = "GetById";
                var t = Type.GetType("Locust.Modules.ACL.Service.RoleCategory.GetById.RoleCategory" + s + "Context, Locust.Modules.ACL.Service.RoleCategory");
                if (t == null)
                {
                    System.Console.WriteLine("type not found");
                }
                else
                {
                    System.Console.WriteLine(t.Name);
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine("err: " + e.Message);
            }
        }
    }
}
