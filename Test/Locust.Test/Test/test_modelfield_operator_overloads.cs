using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.ModelField;

namespace Locust.Test.Test
{
    class MyInt : TInt32
    {
        public MyInt(int a) : base(a)
        {
        }
    }
    class MyString : TString
    {
        public MyString(string a) : base(a)
        {
        }
    }
    public class test_modelfield_operator_overloads:BaseTest
    {
        private void test2()
        {
            var x = new TString(65.ToString());
            string y = 65.ToString();
            string z = 66.ToString();
            TString xx = null;
            var xy = new MyString(65.ToString());
            var xz = new TString(64.ToString());

            System.Console.WriteLine("x: {0}", x);
            System.Console.WriteLine("y: {0}", y);
            System.Console.WriteLine("z: {0}", z);
            System.Console.WriteLine("xx: {0}", xx);
            System.Console.WriteLine("xy: {0}", xy);
            System.Console.WriteLine("xz: {0}", xz);
            System.Console.WriteLine();

            System.Console.WriteLine("x == null\tresult: {0}\texpected: {1}", x == null, false);
            System.Console.WriteLine("x != null\tresult: {0}\texpected: {1}", x != null, true);
            System.Console.WriteLine();
            System.Console.WriteLine("x == 64.ToString()\tresult: {0}\texpected: {1}", x == 64.ToString(), false);
            System.Console.WriteLine("x != 64.ToString()\tresult: {0}\texpected: {1}", x != 64.ToString(), true);
            System.Console.WriteLine();
            System.Console.WriteLine("x == y\tresult: {0}\texpected: {1}", x == y, true);
            System.Console.WriteLine("x != y\tresult: {0}\texpected: {1}", x != y, false);
            System.Console.WriteLine();
            System.Console.WriteLine("x == z\tresult: {0}\texpected: {1}", x == z, false);
            System.Console.WriteLine("x != z\tresult: {0}\texpected: {1}", x != z, true);
            System.Console.WriteLine();
            System.Console.WriteLine("x == xx\tresult: {0}\texpected: {1}", x == xx, false);
            System.Console.WriteLine("x != xx\tresult: {0}\texpected: {1}", x != xx, true);
            System.Console.WriteLine();
            System.Console.WriteLine("x == xy\tresult: {0}\texpected: {1}", x == xy, true);
            System.Console.WriteLine("x != xy\tresult: {0}\texpected: {1}", x != xy, false);
            System.Console.WriteLine();
            System.Console.WriteLine("x == xz\tresult: {0}\texpected: {1}", x == xz, false);
            System.Console.WriteLine("x != xz\tresult: {0}\texpected: {1}", x != xz, true);
            System.Console.WriteLine();
            System.Console.WriteLine("null == x\tresult: {0}\texpected: {1}", null == x, false);
            System.Console.WriteLine("null != x\tresult: {0}\texpected: {1}", null != x, true);
            System.Console.WriteLine();
            System.Console.WriteLine("64.ToString() == x\tresult: {0}\texpected: {1}", 64.ToString() == x, false);
            System.Console.WriteLine("64.ToString() != x\tresult: {0}\texpected: {1}", 64.ToString() != x, true);
            System.Console.WriteLine();
            System.Console.WriteLine("65.ToString() == x\tresult: {0}\texpected: {1}", 65.ToString() == x, true);
            System.Console.WriteLine("65.ToString() != x\tresult: {0}\texpected: {1}", 65.ToString() != x, false);
            System.Console.WriteLine();
            System.Console.WriteLine("y == x\tresult: {0}\texpected: {1}", y == x, true);
            System.Console.WriteLine("y != x\tresult: {0}\texpected: {1}", y != x, false);
            System.Console.WriteLine();
            System.Console.WriteLine("z == x\tresult: {0}\texpected: {1}", z == x, false);
            System.Console.WriteLine("z != x\tresult: {0}\texpected: {1}", z != x, true);
            System.Console.WriteLine();
            System.Console.WriteLine("xx == x\tresult: {0}\texpected: {1}", xx == x, false);
            System.Console.WriteLine("xx != x\tresult: {0}\texpected: {1}", xx != x, true);
            System.Console.WriteLine();
            System.Console.WriteLine("xy == x\tresult: {0}\texpected: {1}", xy == x, true);
            System.Console.WriteLine("xy != x\tresult: {0}\texpected: {1}", xy != x, false);
            System.Console.WriteLine();
            System.Console.WriteLine("xz == x\tresult: {0}\texpected: {1}", xz == x, false);
            System.Console.WriteLine("xz != x\tresult: {0}\texpected: {1}", xz != x, true);
            System.Console.WriteLine();
            System.Console.WriteLine("xy == 65.ToString()\tresult: {0}\texpected: {1}", xy == 65.ToString(), true);
            System.Console.WriteLine("xy != 65.ToString()\tresult: {0}\texpected: {1}", xy != 65.ToString(), false);
            System.Console.WriteLine();
            System.Console.WriteLine("xy == null\tresult: {0}\texpected: {1}", xy == null, false);
            System.Console.WriteLine("xy != null\tresult: {0}\texpected: {1}", xy != null, true);
            System.Console.WriteLine();
            System.Console.WriteLine("null == xy\tresult: {0}\texpected: {1}", null == xy, false);
            System.Console.WriteLine("null != xy\tresult: {0}\texpected: {1}", null != xy, true);
            System.Console.WriteLine();
            System.Console.WriteLine("65.ToString() == xy\tresult: {0}\texpected: {1}", 65.ToString() == xy, true);
            System.Console.WriteLine("65.ToString() != xy\tresult: {0}\texpected: {1}", 65.ToString() != xy, false);
            System.Console.WriteLine();
            System.Console.WriteLine("64.ToString() == xy\tresult: {0}\texpected: {1}", 64.ToString() == xy, false);
            System.Console.WriteLine("64.ToString() != xy\tresult: {0}\texpected: {1}", 64.ToString() != xy, true);
            System.Console.WriteLine();
            System.Console.WriteLine("y == xy\tresult: {0}\texpected: {1}", y == xy, true);
            System.Console.WriteLine("y != xy\tresult: {0}\texpected: {1}", y != xy, false);
            System.Console.WriteLine();
            System.Console.WriteLine("z == xy\tresult: {0}\texpected: {1}", z == xy, false);
            System.Console.WriteLine("z != xy\tresult: {0}\texpected: {1}", z != xy, true);
            System.Console.WriteLine();
            System.Console.WriteLine("xx == xy\tresult: {0}\texpected: {1}", xx == xy, false);
            System.Console.WriteLine("xx != xy\tresult: {0}\texpected: {1}", xx != xy, true);
            System.Console.WriteLine();
        }
        private void test1()
        {
            var x = new TInt32(65);
            int y = 65;
            int z = 66;
            TInt32 xx = null;
            var xy = new MyInt(65);
            var xz = new TInt32(64);

            System.Console.WriteLine("x: {0}", x);
            System.Console.WriteLine("y: {0}", y);
            System.Console.WriteLine("z: {0}", z);
            System.Console.WriteLine("xx: {0}", xx);
            System.Console.WriteLine("xy: {0}", xy);
            System.Console.WriteLine("xz: {0}", xz);
            System.Console.WriteLine();

            System.Console.WriteLine("x == null\tresult: {0}\texpected: {1}", x == null, false);
            System.Console.WriteLine("x != null\tresult: {0}\texpected: {1}", x != null, true);
            System.Console.WriteLine("x > null\tresult: {0}\texpected: {1}", x > null, true);
            System.Console.WriteLine("x >= null\tresult: {0}\texpected: {1}", x >= null, true);
            System.Console.WriteLine("x < null\tresult: {0}\texpected: {1}", x < null, false);
            System.Console.WriteLine("x <= null\tresult: {0}\texpected: {1}", x <= null, false);
            System.Console.WriteLine();
            System.Console.WriteLine("x == 64\tresult: {0}\texpected: {1}", x == 64, false);
            System.Console.WriteLine("x != 64\tresult: {0}\texpected: {1}", x != 64, true);
            System.Console.WriteLine("x > 64\tresult: {0}\texpected: {1}", x > 64, true);
            System.Console.WriteLine("x >= 64\tresult: {0}\texpected: {1}", x >= 64, true);
            System.Console.WriteLine("x < 64\tresult: {0}\texpected: {1}", x < 64, false);
            System.Console.WriteLine("x <= 64\tresult: {0}\texpected: {1}", x <= 64, false);
            System.Console.WriteLine();
            System.Console.WriteLine("x == y\tresult: {0}\texpected: {1}", x == y, true);
            System.Console.WriteLine("x != y\tresult: {0}\texpected: {1}", x != y, false);
            System.Console.WriteLine("x > y\tresult: {0}\texpected: {1}", x > y, false);
            System.Console.WriteLine("x >= y\tresult: {0}\texpected: {1}", x >= y, true);
            System.Console.WriteLine("x < y\tresult: {0}\texpected: {1}", x < y, false);
            System.Console.WriteLine("x <= y\tresult: {0}\texpected: {1}", x <= y, true);
            System.Console.WriteLine();
            System.Console.WriteLine("x == z\tresult: {0}\texpected: {1}", x == z, false);
            System.Console.WriteLine("x != z\tresult: {0}\texpected: {1}", x != z, true);
            System.Console.WriteLine("x > z\tresult: {0}\texpected: {1}", x > z, false);
            System.Console.WriteLine("x >= z\tresult: {0}\texpected: {1}", x >= z, false);
            System.Console.WriteLine("x < z\tresult: {0}\texpected: {1}", x < z, true);
            System.Console.WriteLine("x <= z\tresult: {0}\texpected: {1}", x <= z, true);
            System.Console.WriteLine();
            System.Console.WriteLine("x == xx\tresult: {0}\texpected: {1}", x == xx, false);
            System.Console.WriteLine("x != xx\tresult: {0}\texpected: {1}", x != xx, true);
            System.Console.WriteLine("x > xx\tresult: {0}\texpected: {1}", x > xx, true);
            System.Console.WriteLine("x >= xx\tresult: {0}\texpected: {1}", x >= xx, true);
            System.Console.WriteLine("x < xx\tresult: {0}\texpected: {1}", x < xx, false);
            System.Console.WriteLine("x <= xx\tresult: {0}\texpected: {1}", x <= xx, false);
            System.Console.WriteLine();
            System.Console.WriteLine("x == xy\tresult: {0}\texpected: {1}", x == xy, true);
            System.Console.WriteLine("x != xy\tresult: {0}\texpected: {1}", x != xy, false);
            System.Console.WriteLine("x > xy\tresult: {0}\texpected: {1}", x > xy, false);
            System.Console.WriteLine("x >= xy\tresult: {0}\texpected: {1}", x >= xy, true);
            System.Console.WriteLine("x < xy\tresult: {0}\texpected: {1}", x < xy, false);
            System.Console.WriteLine("x <= xy\tresult: {0}\texpected: {1}", x <= xy, true);
            System.Console.WriteLine();
            System.Console.WriteLine("x == xz\tresult: {0}\texpected: {1}", x == xz, false);
            System.Console.WriteLine("x != xz\tresult: {0}\texpected: {1}", x != xz, true);
            System.Console.WriteLine("x > xz\tresult: {0}\texpected: {1}", x > xz, true);
            System.Console.WriteLine("x >= xz\tresult: {0}\texpected: {1}", x >= xz, true);
            System.Console.WriteLine("x < xz\tresult: {0}\texpected: {1}", x < xz, false);
            System.Console.WriteLine("x <= xz\tresult: {0}\texpected: {1}", x <= xz, false);
            System.Console.WriteLine();
            System.Console.WriteLine("null == x\tresult: {0}\texpected: {1}", null == x, false);
            System.Console.WriteLine("null != x\tresult: {0}\texpected: {1}", null != x, true);
            System.Console.WriteLine("null > x\tresult: {0}\texpected: {1}", null > x, false);
            System.Console.WriteLine("null >= x\tresult: {0}\texpected: {1}", null >= x, false);
            System.Console.WriteLine("null < x\tresult: {0}\texpected: {1}", null < x, true);
            System.Console.WriteLine("null <= x\tresult: {0}\texpected: {1}", null <= x, true);
            System.Console.WriteLine();
            System.Console.WriteLine("64 == x\tresult: {0}\texpected: {1}", 64 == x, false);
            System.Console.WriteLine("64 != x\tresult: {0}\texpected: {1}", 64 != x, true);
            System.Console.WriteLine("64 > x\tresult: {0}\texpected: {1}", 64 > x, false);
            System.Console.WriteLine("64 >= x\tresult: {0}\texpected: {1}", 64 >= x, false);
            System.Console.WriteLine("64 < x\tresult: {0}\texpected: {1}", 64 < x, true);
            System.Console.WriteLine("64 <= x\tresult: {0}\texpected: {1}", 64 <= x, true);
            System.Console.WriteLine();
            System.Console.WriteLine("65 == x\tresult: {0}\texpected: {1}", 65 == x, true);
            System.Console.WriteLine("65 != x\tresult: {0}\texpected: {1}", 65 != x, false);
            System.Console.WriteLine("65 > x\tresult: {0}\texpected: {1}", 65 > x, false);
            System.Console.WriteLine("65 >= x\tresult: {0}\texpected: {1}", 65 >= x, true);
            System.Console.WriteLine("65 < x\tresult: {0}\texpected: {1}", 65 < x, false);
            System.Console.WriteLine("65 <= x\tresult: {0}\texpected: {1}", 65 <= x, true);
            System.Console.WriteLine();
            System.Console.WriteLine("y == x\tresult: {0}\texpected: {1}", y == x, true);
            System.Console.WriteLine("y != x\tresult: {0}\texpected: {1}", y != x, false);
            System.Console.WriteLine("y > x\tresult: {0}\texpected: {1}", y > x, false);
            System.Console.WriteLine("y >= x\tresult: {0}\texpected: {1}", y >= x, true);
            System.Console.WriteLine("y < x\tresult: {0}\texpected: {1}", y < x, false);
            System.Console.WriteLine("y <= x\tresult: {0}\texpected: {1}", y <= x, true);
            System.Console.WriteLine();
            System.Console.WriteLine("z == x\tresult: {0}\texpected: {1}", z == x, false);
            System.Console.WriteLine("z != x\tresult: {0}\texpected: {1}", z != x, true);
            System.Console.WriteLine("z > x\tresult: {0}\texpected: {1}", z > x, true);
            System.Console.WriteLine("z >= x\tresult: {0}\texpected: {1}", z >= x, true);
            System.Console.WriteLine("z < x\tresult: {0}\texpected: {1}", z < x, false);
            System.Console.WriteLine("z <= x\tresult: {0}\texpected: {1}", z <= x, false);
            System.Console.WriteLine();
            System.Console.WriteLine("xx == x\tresult: {0}\texpected: {1}", xx == x, false);
            System.Console.WriteLine("xx != x\tresult: {0}\texpected: {1}", xx != x, true);
            System.Console.WriteLine("xx > x\tresult: {0}\texpected: {1}", xx > x, false);
            System.Console.WriteLine("xx >= x\tresult: {0}\texpected: {1}", xx >= x, false);
            System.Console.WriteLine("xx < x\tresult: {0}\texpected: {1}", xx < x, true);
            System.Console.WriteLine("xx <= x\tresult: {0}\texpected: {1}", xx <= x, true);
            System.Console.WriteLine();
            System.Console.WriteLine("xy == x\tresult: {0}\texpected: {1}", xy == x, true);
            System.Console.WriteLine("xy != x\tresult: {0}\texpected: {1}", xy != x, false);
            System.Console.WriteLine("xy > x\tresult: {0}\texpected: {1}", xy > x, false);
            System.Console.WriteLine("xy >= x\tresult: {0}\texpected: {1}", xy >= x, true);
            System.Console.WriteLine("xy < x\tresult: {0}\texpected: {1}", xy < x, false);
            System.Console.WriteLine("xy <= x\tresult: {0}\texpected: {1}", xy <= x, true);
            System.Console.WriteLine();
            System.Console.WriteLine("xz == x\tresult: {0}\texpected: {1}", xz == x, false);
            System.Console.WriteLine("xz != x\tresult: {0}\texpected: {1}", xz != x, true);
            System.Console.WriteLine("xz > x\tresult: {0}\texpected: {1}", xz > x, false);
            System.Console.WriteLine("xz >= x\tresult: {0}\texpected: {1}", xz >= x, false);
            System.Console.WriteLine("xz < x\tresult: {0}\texpected: {1}", xz < x, true);
            System.Console.WriteLine("xz <= x\tresult: {0}\texpected: {1}", xz <= x, true);
            System.Console.WriteLine();
            System.Console.WriteLine("xy == 65\tresult: {0}\texpected: {1}", xy == 65, true);
            System.Console.WriteLine("xy != 65\tresult: {0}\texpected: {1}", xy != 65, false);
            System.Console.WriteLine("xy > 65\tresult: {0}\texpected: {1}", xy > 65, false);
            System.Console.WriteLine("xy >= 65\tresult: {0}\texpected: {1}", xy >= 65, true);
            System.Console.WriteLine("xy < 65\tresult: {0}\texpected: {1}", xy < 65, false);
            System.Console.WriteLine("xy <= 65\tresult: {0}\texpected: {1}", xy <= 65, true);
            System.Console.WriteLine();
            System.Console.WriteLine("xy == null\tresult: {0}\texpected: {1}", xy == null, false);
            System.Console.WriteLine("xy != null\tresult: {0}\texpected: {1}", xy != null, true);
            System.Console.WriteLine("xy > null\tresult: {0}\texpected: {1}", xy > null, true);
            System.Console.WriteLine("xy >= null\tresult: {0}\texpected: {1}", xy >= null, true);
            System.Console.WriteLine("xy < null\tresult: {0}\texpected: {1}", xy < null, false);
            System.Console.WriteLine("xy <= null\tresult: {0}\texpected: {1}", xy <= null, false);
            System.Console.WriteLine();
            System.Console.WriteLine("null == xy\tresult: {0}\texpected: {1}", null == xy, false);
            System.Console.WriteLine("null != xy\tresult: {0}\texpected: {1}", null != xy, true);
            System.Console.WriteLine("null > xy\tresult: {0}\texpected: {1}", null > xy, false);
            System.Console.WriteLine("null >= xy\tresult: {0}\texpected: {1}", null >= xy, false);
            System.Console.WriteLine("null < xy\tresult: {0}\texpected: {1}", null < xy, true);
            System.Console.WriteLine("null <= xy\tresult: {0}\texpected: {1}", null <= xy, true);
            System.Console.WriteLine();
            System.Console.WriteLine("65 == xy\tresult: {0}\texpected: {1}", 65 == xy, true);
            System.Console.WriteLine("65 != xy\tresult: {0}\texpected: {1}", 65 != xy, false);
            System.Console.WriteLine("65 > xy\tresult: {0}\texpected: {1}", 65 > xy, false);
            System.Console.WriteLine("65 >= xy\tresult: {0}\texpected: {1}", 65 >= xy, true);
            System.Console.WriteLine("65 < xy\tresult: {0}\texpected: {1}", 65 < xy, false);
            System.Console.WriteLine("65 <= xy\tresult: {0}\texpected: {1}", 65 <= xy, true);
            System.Console.WriteLine();
            System.Console.WriteLine("64 == xy\tresult: {0}\texpected: {1}", 64 == xy, false);
            System.Console.WriteLine("64 != xy\tresult: {0}\texpected: {1}", 64 != xy, true);
            System.Console.WriteLine("64 > xy\tresult: {0}\texpected: {1}", 64 > xy, false);
            System.Console.WriteLine("64 >= xy\tresult: {0}\texpected: {1}", 64 >= xy, false);
            System.Console.WriteLine("64 < xy\tresult: {0}\texpected: {1}", 64 < xy, true);
            System.Console.WriteLine("64 <= xy\tresult: {0}\texpected: {1}", 64 <= xy, true);
            System.Console.WriteLine();
            System.Console.WriteLine("y == xy\tresult: {0}\texpected: {1}", y == xy, true);
            System.Console.WriteLine("y != xy\tresult: {0}\texpected: {1}", y != xy, false);
            System.Console.WriteLine("y > xy\tresult: {0}\texpected: {1}", y > xy, false);
            System.Console.WriteLine("y >= xy\tresult: {0}\texpected: {1}", y >= xy, true);
            System.Console.WriteLine("y < xy\tresult: {0}\texpected: {1}", y < xy, false);
            System.Console.WriteLine("y <= xy\tresult: {0}\texpected: {1}", y <= xy, true);
            System.Console.WriteLine();
            System.Console.WriteLine("z == xy\tresult: {0}\texpected: {1}", z == xy, false);
            System.Console.WriteLine("z != xy\tresult: {0}\texpected: {1}", z != xy, true);
            System.Console.WriteLine("z > xy\tresult: {0}\texpected: {1}", z > xy, true);
            System.Console.WriteLine("z >= xy\tresult: {0}\texpected: {1}", z >= xy, true);
            System.Console.WriteLine("z < xy\tresult: {0}\texpected: {1}", z < xy, false);
            System.Console.WriteLine("z <= xy\tresult: {0}\texpected: {1}", z <= xy, false);
            System.Console.WriteLine();
            System.Console.WriteLine("xx == xy\tresult: {0}\texpected: {1}", xx == xy, false);
            System.Console.WriteLine("xx != xy\tresult: {0}\texpected: {1}", xx != xy, true);
            System.Console.WriteLine("xx > xy\tresult: {0}\texpected: {1}", xx > xy, false);
            System.Console.WriteLine("xx >= xy\tresult: {0}\texpected: {1}", xx >= xy, false);
            System.Console.WriteLine("xx < xy\tresult: {0}\texpected: {1}", xx < xy, true);
            System.Console.WriteLine("xx <= xy\tresult: {0}\texpected: {1}", xx <= xy, true);
            System.Console.WriteLine();


        }

        public override void Test()
        {
            //test1();
            test2();
        }
    }
}
