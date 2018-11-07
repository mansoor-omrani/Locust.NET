using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Locust.Extensions;

namespace Locust.Cryptography
{
    public class AESEncryption: IEncryption
    {
        public String GetKey(string n, Encoding e)
        {
            char[] x = new char[36];
            String y = n.ToByteArray(e).ToBinary();
            for (int i = 0; i < x.Length; i++)
            {
                x[i] = (char)(((i < 10) ? 48 : 87) + i);
            }

            for (byte z = 0; z < y.Length; z++)
            {
                if (y.CharAt(z) == '1')
                {
                    byte i = 0;
                    while (i < x.Length)
                    {
                        byte m = (byte)(i + z + 1);

                        if (m > (x.Length - 1))
                            m = (byte)(m - x.Length);

                        char t = x[i];
                        if (m % 3 == 0)
                        {
                            x[i] = x[m];
                        }
                        else
                        {
                            if (m % 2 == 0)
                            {
                                x[i] = Char.ToUpper(x[m]);
                            }
                            else
                            {
                                x[i] = Char.ToLower(x[m]);
                            }
                        }
                        x[m] = t;

                        i += (byte)(z + 2);
                    }
                }
            }

            return new string(x).Substring(0, 16);
        }
        private RijndaelManaged GetCryptoTransform(string key)
        {
            string key_string64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(key));

            RijndaelManaged aes = new RijndaelManaged();
            aes.BlockSize = 128;
            aes.KeySize = 256;

            // It is equal in java 
            /// Cipher _Cipher = Cipher.getInstance("AES/CBC/PKCS5PADDING");    
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            byte[] keyArr = Convert.FromBase64String(key_string64);
            byte[] KeyArrBytes32Value = new byte[keyArr.Length];

            Array.Copy(keyArr, KeyArrBytes32Value, keyArr.Length);

            // Initialization vector.   
            // It could be any value or generated using a random number generator.
            byte[] ivArr = { 1, 2, 3, 4, 5, 6, 6, 5, 4, 3, 2, 1, 7, 7, 7, 7 };
            byte[] IVBytes16Value = new byte[16];

            Array.Copy(ivArr, IVBytes16Value, 16);

            aes.Key = KeyArrBytes32Value;
            aes.IV = IVBytes16Value;

            return aes;
        }
        public string Encrypt(string PlainText, string key)
        {
            var aes = GetCryptoTransform(key);
            var encrypto = aes.CreateEncryptor();
            
            byte[] plainTextByte = ASCIIEncoding.UTF8.GetBytes(PlainText);
            byte[] CipherText = encrypto.TransformFinalBlock(plainTextByte, 0, plainTextByte.Length);

            return Convert.ToBase64String(CipherText);

        }

        public string Decrypt(string CipherText, string key)
        {
            var aes = GetCryptoTransform(key);
            var decrypto = aes.CreateDecryptor();
            
            byte[] encryptedBytes = Convert.FromBase64CharArray(CipherText.ToCharArray(), 0, CipherText.Length);
            byte[] decryptedData = decrypto.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);

            return ASCIIEncoding.UTF8.GetString(decryptedData);
        }
    }
}
