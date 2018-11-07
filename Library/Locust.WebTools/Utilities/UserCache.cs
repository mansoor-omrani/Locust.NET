using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Locust.WebTools
{
    public class UserCache
    {
        private static HttpContext context;

        static UserCache()
        {
            context = HttpContext.Current;
        }
        public static void Store(string key, object data)
        {
            if (context != null)
            {
                if (context.Session != null)
                {
                    context.Session["UserCache_" + key] = data;
                }
            }
        }
        public static T Get<T>(string key)
        {
            T result = default(T);

            if (context != null)
            {
                if (context.Session != null)
                {
                    result = (T)context.Session["UserCache_" + key];
                }
            }

            return result;
        }
        public static void Remove(string key)
        {
            if (context != null)
            {
                if (context.Session != null)
                {
                    context.Session.Remove(key);
                }
            }
        }
    }
}