using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Extensions
{
    public static class NumberExtensions
    {
        public static String ToBinary(this Byte[] data, string separator = "")
        {
            return string.Join(separator.ToString(), data.Select(byt => Convert.ToString(byt, 2).PadLeft(8, '0')));
        }

        public static string ToBinaryString(this int x)
        {
            //char[] b = new char[sizeof(Int32) * 8];

            //for (int i = 0; i < b.Length; i++)
            //    b[b.Length - 1 - i] = ((n & (1 << i)) != 0) ? '1' : '0';

            //return new string(b).TrimStart('0');

            char[] bits = new char[32];
            int i = 0;

            while (x != 0)
            {
                bits[i++] = (x & 1) == 1 ? '1' : '0';
                x >>= 1;
            }

            Array.Reverse(bits, 0, i);

            return new string(bits);
        }
        public static string ToBinaryString(this short x)
        {
            //char[] b = new char[sizeof(Int32) * 8];

            //for (int i = 0; i < b.Length; i++)
            //    b[b.Length - 1 - i] = ((n & (1 << i)) != 0) ? '1' : '0';

            //return new string(b).TrimStart('0');

            char[] bits = new char[32];
            int i = 0;

            while (x != 0)
            {
                bits[i++] = (x & 1) == 1 ? '1' : '0';
                x >>= 1;
            }

            Array.Reverse(bits, 0, i);

            return new string(bits);
        }
    }
}
