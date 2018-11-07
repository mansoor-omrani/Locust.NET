using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Cryptography
{
    public static class Cryptography
    {
        public static AESEncryption AES { get; set; }
        public static TripleDES DES { get; set; }
        public static AES2 AES2 { get; set; }
        public static Base64 Base64 { get; set; }
        public static IXorEncryption Xor { get; set; }
        static Cryptography()
        {
            AES = new AESEncryption();
            DES = new TripleDES();
            AES2 = new AES2();
            Base64 = new Base64();
            Xor = new XorEncryption();
        }
        public static string GetChecksumSHA256FromString(string data)
        {
            var sha = new SHA256Managed();
            var bytes = Encoding.UTF8.GetBytes(data);
            byte[] checksum = sha.ComputeHash(bytes);

            return BitConverter.ToString(checksum).Replace("-", String.Empty);
        }
        //GetChecksumSHA256FromFile - source: http://peterkellner.net/2010/11/24/efficiently-generating-sha256-checksum-for-files-using-csharp/
        public static string GetChecksumSHA256FromFile(string file)
        {
            using (FileStream stream = File.OpenRead(file))
            {
                var sha = new SHA256Managed();
                byte[] checksum = sha.ComputeHash(stream);
                return BitConverter.ToString(checksum).Replace("-", String.Empty);
            }
        }

        public static string GetMD5(string data)
        {
            return GetMD5(data, Encoding.UTF8);
        }
        public static string GetMD5(string data, Encoding e)
        {
            var md5 = MD5.Create();
            var encoder = e;
            var hash = md5.ComputeHash(encoder.GetBytes(data));
            var sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }

            var result = sb.ToString();

            return result;
        }
        public static string GetChecksumMD5FromString(string data)
        {
            using (var md5 = MD5.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(data);

                return BitConverter.ToString(md5.ComputeHash(bytes)).Replace("-", string.Empty);
            }
        }
        // GetMD5HashFromFile - source: https://social.msdn.microsoft.com/Forums/vstudio/en-US/d448e5bc-1ede-4b6c-8e98-92d534ed7370/how-to-calculate-md5-checksum-for-a-file?forum=csharpgeneral
        public static string GetChecksumMD5FromFile(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", string.Empty);
                }
            }
        }

        // Checksum - source: https://stackoverflow.com/questions/10947717/how-to-calculate-checksum
        public static string CheckSum(string dataToCalculate)
        {
            byte[] byteToCalculate = Encoding.ASCII.GetBytes(dataToCalculate);
            int checksum = 0;
            foreach (byte chData in byteToCalculate)
            {
                checksum += chData;
            }
            checksum &= 0xff;
            return checksum.ToString("X2");
        }
    }
}
