using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.BaseInfo;

namespace Locust.Test.Test
{
    public class test_baseinfo_in_model: BaseTest
    {
        public enum ShowType
        {
            ScreenShow = 1,
            Theater = 2,
            Show = 3,
            Concert = 4,
            LiveSportShow = 5,
            Tour = 6,
            Conference = 7,
            Workshop = 8
        }

        public class Show
        {
            public int ShowId { get; set; }
            public string Title { get; set; }
            public BasicData<ShowType> Type { get; private set; }
            public int Year { get; set; }
            public string Description { get; set; }

            public Show()
            {
                Type = new BasicData<ShowType>();
            }
        }
        public override void Test()
        {
            var x = new Show();

            x.Type.Code = "3";
            System.Console.WriteLine("Id: {0}\nValue:{1}", x.Type.Id, x.Type.Value);
        }
    }
}
