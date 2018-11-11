using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.RandomGenerator;

namespace Locust.Test.Test
{
    public class test_random_numbers:BaseTest
    {
        public override void Test()
        {
            var srg = new SimpleRandomGenerator();
            var rgs = new RandomGeneratorSetting(RandomCodeType.AlphaNum, 8);
            var data = new List<string>();
            
            for (var i = 0; i < 20; i++)
            {
                var x = srg.Generate(rgs);
                data.Add(x);
            }

            foreach (var code in data)
            {
                System.Console.WriteLine(code);
            }
        }
    }
}
