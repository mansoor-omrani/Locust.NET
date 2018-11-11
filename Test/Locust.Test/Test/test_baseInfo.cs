using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.BaseInfo;

namespace Locust.Test.Test
{
    public class test_baseInfo:BaseTest
    {
        public override void Test()
        {
            BasicData x;
            IBaseInfoProvider bip;

            bip = BaseInfo.BaseInfo.DefaultProvider;

            x = bip.GetByCode("ShowType", "2");
            System.Console.WriteLine("\nId: {0}\nName: {2}\nCode: {3}", x.Id, x.Title, x.Name, x.Code);

            x = bip.GetById("ShowType", 3);
            System.Console.WriteLine("\nId: {0}\nName: {2}\nCode: {3}", x.Id, x.Title, x.Name, x.Code);

            x = bip.GetByName("ShowType", "ScreenShow");
            System.Console.WriteLine("\nId: {0}\nName: {2}\nCode: {3}", x.Id, x.Title, x.Name, x.Code);
        }
    }
}
