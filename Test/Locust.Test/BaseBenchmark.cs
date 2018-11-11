using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Locust.Test
{
    public class BaseBenchmark
    {
        protected BaseTest test1 { get; set; }
        protected BaseTest test2 { get; set; }
        protected string Description { get; set; }
        protected virtual Tuple<double, double> test_single(int stressCount)
        {
            var sw = new Stopwatch();
            var t1 = 0d;
            sw.Restart();
            for (var i = 0; i < stressCount; i++)
            {
                test1.Test();
            }
            sw.Stop();
            t1 = sw.Elapsed.TotalMilliseconds;

            System.Console.WriteLine();

            sw.Restart();

            var t2 = 0d;
            sw.Restart();
            for (var i = 0; i < stressCount; i++)
            {
                test2.Test();
            }
            sw.Stop();
            t2 = sw.Elapsed.TotalMilliseconds;

            return new Tuple<double, double>(t1, t2);
        }
        protected virtual void test(int repeatCount, int stressCount)
        {
            var results = new List<Tuple<double, double>>();
            var i = 1;

            System.Console.WriteLine("\n" + Description);
            System.Console.WriteLine();

            System.Console.WriteLine("1. " + test1.Title);
            System.Console.WriteLine("2. " + test2.Title);

            System.Console.WriteLine();
            System.Console.WriteLine("\t1\t2");
            System.Console.WriteLine(new string(' ', 4) + new string('-', 15));

            for (i = 0; i < repeatCount; i++)
            {
                var r = test_single(stressCount);
                results.Add(r);
                System.Console.WriteLine("\t{0}\t{1}", Math.Round(r.Item1, 2), Math.Round(r.Item2, 2));
            }

            System.Console.WriteLine();
            System.Console.WriteLine(new string('-', 20));
            System.Console.WriteLine("\n\tAverage:\n");

            var avg1 = Math.Round(results.Average(x => x.Item1), 2);
            var avg2 = Math.Round(results.Average(x => x.Item2), 2);
            var ratio = Math.Round(avg2 / avg1, 2);
            
            var fasterOrslower1 = (ratio > 1) ? "faster" : "slower";
            var fasterOrslower2 = (ratio > 1) ? "slower" : "faster";

            System.Console.WriteLine(" 1. {0}: {1}", test1.Title, avg1);
            System.Console.WriteLine(" 2. {0}: {1}", test2.Title, avg2);
            System.Console.WriteLine();
            System.Console.WriteLine(" {0} is {1} {2} than {3}", test1.Title, ratio, fasterOrslower1, test2.Title);
            System.Console.WriteLine(" {0} is {1} {2} than {3}", test2.Title, ratio, fasterOrslower2, test1.Title);
        }
        public virtual void Run()
        {
            const int repeatCount = 10;
            const int stressCount = 10;
                        
            test(repeatCount, stressCount);
        }
        public virtual void Run(int repeatCount, int stressCount)
        {
            test(repeatCount, stressCount);
        }
    }
}
