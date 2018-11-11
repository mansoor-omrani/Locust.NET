using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Cryptography;
using Locust.Extensions;

namespace Locust.Test
{
    public static class TassEncryptionKeys
    {
        private static string masterKey;

        static TassEncryptionKeys()
        {
            masterKey = "59723833462648323" + Math.PI.ToString().Substring(2).Reverse();
        }
        public static string GetKey(string s1, string s2)
        {
            if (!string.IsNullOrEmpty(s1) && !string.IsNullOrEmpty(s2))
            {
                s1 = s1.Replace("-", "");
                s2 = s2.Replace("-", "");

                if (s1.Length < s2.Length)
                {
                    var s = s2;
                    s2 = s1;
                    s1 = s;
                }

                var b = new byte[s1.Length];

                for (var i = 0; i < b.Length; i++)
                {
                    var k = i % s2.Length;
                    b[i] = (byte)((byte)(s1[i]) ^ (byte)(s2[k]));
                }
                
                var base64 = new Base64Encoder();
                var result = new String(base64.Encode(b));

                return result.Left(16);
            }
            else
            {
                return string.Empty;
            }
        }
        public static string Key0(string serialno)
        {
            return GetKey(serialno, masterKey);
        }
        public static string Key1(string hardwarecode, string serialno)
        {
            return GetKey(hardwarecode, serialno);
        }
        public static string Key2(string hardwarecode)
        {
            return GetKey(hardwarecode, masterKey);
        }
        public static string Key3(string hardwarecode, string activationkey)
        {
            return GetKey(hardwarecode, activationkey);
        }
    }
}
