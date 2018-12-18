using Locust.Conversion;
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
    public class PlainCookieStateProvider<T>: BaseStateProvider<T> where T : class, new()
    {
        protected string DOMAIN;
        protected string PATH;
        #region ctor
        public PlainCookieStateProvider(string name) : base(name)
        { }
        public PlainCookieStateProvider(string name, string domain, string path):base(name)
        {
            Init(domain, path);
        }
        public PlainCookieStateProvider(string name, HttpContextBase context): base(name, context)
        {
        }
        public PlainCookieStateProvider(string name, HttpContextBase context, string domain, string path) : base(name, context)
        {
            Init(domain, path);
        }
        public PlainCookieStateProvider(string name, IHttpContextProvider provider, ISerializer serializer):base(name, provider, serializer)
        { }
        public PlainCookieStateProvider(string name, IHttpContextProvider httpContextProvider, ISerializer serializer, string domain, string path) : base(name, httpContextProvider, serializer)
        {
            Init(domain, path);
        }
        private void Init(string domain, string path)
        {
            DOMAIN = domain;
            PATH = path;
        }
        #endregion
        protected virtual string TransformAfterRead(string data)
        {
            return data;
        }
        protected virtual string TransformBeforeWrite(string data)
        {
            return data;
        }
        private string GetString(T value)
        {
            var base64 = new Cryptography.Base64Encoder();

            var bytes = Serializer.Serialize(value);
            var str = Encoding.UTF8.GetString(bytes);
            str = TransformBeforeWrite(str);
            var chars = base64.Encode(str, Encoding.UTF8);
            str = new string(chars);

            return str;
        }
        public override bool Exists()
        {
            var cookie = HttpContext.Request.Cookies.Get(Name);

            return (cookie != null);
        }
        protected override void StoreInternal()
        {
            Logger?.LogCategory($"PlainCookieStateProvider<{typeof(T).Name}>('{Name}').Store()");
            Logger?.Log("Creating cookies ...");

            var cookie = new HttpCookie(Name);
            var statCookie = new HttpCookie(Name + ".stat");

            if (!string.IsNullOrEmpty(DOMAIN))
            {
                cookie.Domain = DOMAIN;
                statCookie.Domain = DOMAIN;
            }
            if (!string.IsNullOrEmpty(PATH))
            {
                cookie.Path = PATH;
                statCookie.Path = PATH;
            }

            cookie.HttpOnly = true;
            statCookie.HttpOnly = true;
            
            if (Stat.Removed)
            {
                Logger?.Log("Item is removed. Removing cookies ...");

                cookie.Expires = DateTime.Now.AddDays(-1d);
                statCookie.Expires = DateTime.Now.AddDays(-1d);
            }
            else
            {
                cookie.Value = GetString(Value);

                var base64 = new Cryptography.Base64Encoder();
                var bytes = Serializer.Serialize(Stat);
                var str = Encoding.UTF8.GetString(bytes);
                var chars = base64.Encode(str, Encoding.UTF8);

                statCookie.Value = new string(chars);
            }

            try
            {
                HttpContext.Response.Cookies.Add(cookie);
                HttpContext.Response.Cookies.Add(statCookie);

                Stored();
            }
            catch (System.Web.HttpException e)
            {
                if (!e.Message.Contains("cannot modify cookies"))
                {
                    ExceptionLogger?.LogException(e);
                }
            }
            catch (Exception e)
            {
                ExceptionLogger?.LogException(e);
            }
        }
        public override void Restore()
        {
            Logger?.LogCategory($"PlainCookieStateProvider<{typeof(T).Name}>('{Name}').Restore()");
            Logger?.Log("Reading cookies ...");

            var cookie = HttpContext.Request.Cookies.Get(Name);

            if (cookie != null)
            {
                try
                {
                    var value = cookie.Value;

                    if (!string.IsNullOrEmpty(value))
                    {
                        var currentValue = Value == null ? "" : GetString(Value);

                        if (string.Compare(value, currentValue, false) == 0)
                        {
                            Logger?.Log("Current value equals given cookie. Restore skipped.");
                        }
                        else
                        {
                            Logger?.Log("Decoding from base64 ...");

                            var base64 = new Cryptography.Base64Decoder();
                            var str = base64.Decode(value, Encoding.UTF8);
                            str = TransformAfterRead(str);
                            var bytes = Encoding.UTF8.GetBytes(str);

                            if (bytes.Length > 0)
                            {
                                Value = Serializer.Deserialize(bytes, typeof(T)) as T;
                            }

                            var statCookie = HttpContext.Request.Cookies.Get(Name + ".stat");

                            if (statCookie != null)
                            {
                                value = statCookie.Value;

                                if (!string.IsNullOrEmpty(value))
                                {
                                    str = base64.Decode(value, Encoding.UTF8);
                                    bytes = Encoding.UTF8.GetBytes(str);

                                    if (bytes.Length > 0)
                                    {
                                        Stat = Serializer.Deserialize(bytes, typeof(StateProviderItem)) as StateProviderItem;
                                    }
                                }
                                else
                                {
                                    Logger?.Log("stat cookie is empty");
                                }
                            }
                        }
                    }
                    else
                    {
                        Logger?.Log("cookie is empty");
                    }
                }
                catch (Exception e)
                {
                    Logger?.Log($"FAILED: {e.Message}");
                    ExceptionLogger?.LogException(e, $"PlainCookieStateProvider<{typeof(T).Name}>('{Name}').Restore() Failed");
                }
            }
        }
    }
}
