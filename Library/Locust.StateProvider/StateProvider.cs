using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.StateProvider
{
    public static class StateProvider
    {
        // Important Note:
        // these properties should return a new instance with every get call,
        // otherwise (if we return a single static instance) the dictionary inside
        // them will be shared among threads and data will be corrupted.
        // returning a new instance with every get call does not incur that much cost.
        // since loading the dictionary happens only once when ReadAll() is called
        // and ReadAll() is called only in Application_BeginRequest(). after that
        // the dictionary will be put in HttpContext.Items[] collections. so, each
        // new instance refers to HttpContext.Items[] afterwards.
        public static PlainCookieStateProvider<T> PlainCookie<T>(string name) where T:class, new()
        {
            return new PlainCookieStateProvider<T>(name);
        }
        public static SecureCookieStateProvider<T> SecureCookie<T>(string name) where T : class, new()
        {
            var result = new SecureCookieStateProvider<T>(name);
            result.CryptKey = ConfigurationManager.AppSettings["CryptKey"];

            return result;
        }
        public static SessionStateProvider<T> Session<T>(string name) where T : class, new()
        {
            return new SessionStateProvider<T>(name);
        }
    }
}
