using Locust.Conversion;
using Locust.Cryptography;
using Locust.Serialization;
using Locust.WebTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Locust.StateProvider
{
    public class SecureCookieStateProvider<T> : PlainCookieStateProvider<T> where T:class, new()
    {
        public string CryptKey { get; set; }
        #region ctor
        public SecureCookieStateProvider(string name): base(name)
        { }
        public SecureCookieStateProvider(string name, string domain, string path):base(name, domain, path)
        {
        }
        public SecureCookieStateProvider(string name, HttpContextBase context): base(name, context)
        {
        }
        public SecureCookieStateProvider(string name, HttpContextBase context, string domain, string path) : base(name, context, domain, path)
        {
        }
        public SecureCookieStateProvider(string name, IHttpContextProvider provider, ISerializer serializer) :base(name, provider, serializer)
        { }
        public SecureCookieStateProvider(string name, IHttpContextProvider provider, ISerializer serializer, string domain, string path) : base(name, provider, serializer, domain, path)
        {
        }
        #endregion
        protected override string TransformAfterRead(string data)
        {
            Logger?.Log("Transforming ...");

            var result = data;

            if (!string.IsNullOrEmpty(data))
            {
                Logger?.Log("Decrypting ...");

                try
                {
                    result = Locust.Cryptography.Cryptography.AES.Decrypt(result, CryptKey);
                }
                catch (Exception e)
                {
                    Logger?.Log($"DECRYPT FAILED: {e.Message}");
                    ExceptionLogger?.LogException(e, $"Decrypt Failed, data: {data}");

                    throw;
                }
            }

            return result;
        }
        protected override string TransformBeforeWrite(string data)
        {
            Logger?.Log("Transforming ...");

            var result = data;

            if (!string.IsNullOrEmpty(data))
            {
                try
                {
                    result = Cryptography.Cryptography.AES.Encrypt(result, CryptKey);
                }
                catch (Exception e)
                {
                    Logger?.Log($"ENCRYPT FAILED: {e.Message}");
                    ExceptionLogger?.LogException(e, $"Encrypt Failed, data: {data}");

                    throw;
                }
            }

            return result;
        }
    }
}
