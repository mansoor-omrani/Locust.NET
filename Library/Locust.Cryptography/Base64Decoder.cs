using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Extensions;

namespace Locust.Cryptography
{
    public class Base64Decoder: IBase64Decoder
    {
        public byte[] Decode(char[] input)
        {
            char[] source;
            int length, length2, length3;
            int blockCount;
            int paddingCount;
            int temp = 0;
            source = input;
            length = input.Length;

            //find how many padding are there
            for (int x = 0; x < 2; x++)
            {
                if (input[length - x - 1] == '=')
                    temp++;
            }
            paddingCount = temp;
            //calculate the blockCount;
            //assuming all whitespace and carriage returns/newline were removed.
            blockCount = length / 4;
            length2 = blockCount * 3;

            byte[] buffer = new byte[length];   //first conversion result
            byte[] buffer2 = new byte[length2]; //decoded array with padding

            for (int x = 0; x < length; x++)
            {
                buffer[x] = source[x].As6Bit();
            }

            byte b, b1, b2, b3;
            byte temp1, temp2, temp3, temp4;

            for (int x = 0; x < blockCount; x++)
            {
                temp1 = buffer[x * 4];
                temp2 = buffer[x * 4 + 1];
                temp3 = buffer[x * 4 + 2];
                temp4 = buffer[x * 4 + 3];

                b = (byte)(temp1 << 2);
                b1 = (byte)((temp2 & 48) >> 4);
                b1 += b;

                b = (byte)((temp2 & 15) << 4);
                b2 = (byte)((temp3 & 60) >> 2);
                b2 += b;

                b = (byte)((temp3 & 3) << 6);
                b3 = temp4;
                b3 += b;

                buffer2[x * 3] = b1;
                buffer2[x * 3 + 1] = b2;
                buffer2[x * 3 + 2] = b3;
            }
            //remove paddings
            length3 = length2 - paddingCount;
            byte[] result = new byte[length3];

            for (int x = 0; x < length3; x++)
            {
                result[x] = buffer2[x];
            }

            return result;
        }
        public byte[] Decode(string base64)
        {
            return Decode(base64.ToCharArray());
        }


        public string Decode(string base64, Encoding e)
        {
            var r = Decode(base64);

            return e.GetString(r);
        }

        public string Decode(char[] base64, Encoding e)
        {
            var r = Decode(base64);

            return e.GetString(r);
        }
    }
}
