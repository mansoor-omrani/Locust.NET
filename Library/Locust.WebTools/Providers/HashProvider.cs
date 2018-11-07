using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.WebTools
{
    public class HashContext
    {
        public string FilePathAndName { get; set; }
        public string Data { get; set; }
        public string BasePath { get; set; }
    }
    public interface IHashProvider
    {
        string GetHash(HashContext context);
    }
    public class RandomHashProvider : IHashProvider
    {
        public string GetHash(HashContext context)
        {
            return GetHash();
        }
        public string GetHash()
        {
            return new Random().Next(99999).ToString();
        }
    }
    public class MD5HashProvider : IHashProvider
    {
        public string GetHash(HashContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            if (string.IsNullOrEmpty(context.FilePathAndName))
            {
                return Locust.Cryptography.Cryptography.GetChecksumMD5FromString(context.Data);
            }
            else
            {
                return Locust.Cryptography.Cryptography.GetChecksumMD5FromFile(context.FilePathAndName);
            }
        }
    }
    public class SHA256HashProvider : IHashProvider
    {
        public string GetHash(HashContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            if (string.IsNullOrEmpty(context.FilePathAndName))
            {
                return Locust.Cryptography.Cryptography.GetChecksumSHA256FromString(context.Data);
            }
            else
            {
                return Locust.Cryptography.Cryptography.GetChecksumSHA256FromFile(context.FilePathAndName);
            }
        }
    }
}
