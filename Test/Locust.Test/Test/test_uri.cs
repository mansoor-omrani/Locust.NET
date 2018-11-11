using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.WebExtensions;

namespace Locust.Test.Test
{
    public class test_uri: BaseTest
    {
        public override void Test()
        {
            var u = "http://www.cinematicket.org";
            Uri uri;
            if (Uri.TryCreate(u, UriKind.Absolute, out uri))
            {
                Console.WriteLine("Absolute Uri");
                foreach (var item in uri.ToCollection())
                {
                    Console.WriteLine("{0}: {1}", item.Key, item.Value);
                }
            }
            else
            {
                if (Uri.TryCreate(u, UriKind.Relative, out uri))
                {
                    Console.WriteLine("Relative Uri");
                    foreach (var item in uri.ToCollection())
                    {
                        Console.WriteLine("{0}: {1}", item.Key, item.Value);
                    }
                }
                else
                {
                    Console.WriteLine("uri error");
                }
            }
        }
    }
}
