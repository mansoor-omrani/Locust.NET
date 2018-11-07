using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Extensions
{
    public static class NetExtensions
    {
        // source: https://stackoverflow.com/questions/11164275/how-to-add-cookies-to-webrequest
        public static bool TryAddCookie(this WebRequest webRequest, Cookie cookie)
        {
            HttpWebRequest httpRequest = webRequest as HttpWebRequest;
            if (httpRequest == null)
            {
                return false;
            }

            if (httpRequest.CookieContainer == null)
            {
                httpRequest.CookieContainer = new CookieContainer();
            }

            httpRequest.CookieContainer.Add(cookie);
            return true;
        }
        public static bool TryAddCookie(this WebRequest webRequest, string cookieName, string cookieValue, string cookiePath = "", string cookieDomain = "")
        {
            var c = new Cookie(cookieName, cookieValue, cookiePath, cookieDomain);

            if (!string.IsNullOrEmpty(cookiePath))
            {
                c.Path = cookiePath;
            }
            if (!string.IsNullOrEmpty(cookieDomain))
            {
                c.Domain = cookieDomain;
            }
            
            return webRequest.TryAddCookie(c);
        }
        public static string Join(this CookieCollection cookies, string separator = ",")
        {
            var sb = new StringBuilder();
            var i = 0;
            foreach (Cookie c in cookies)
            {
                sb.Append(String.Format("{0} {1}: {2}", (i > 0) ? separator : "", c.Name, c.Value));
                i++;
            }
            return sb.ToString();
        }
        public static string Join(this CookieCollection cookies, Func<Cookie, string> transform, string separator = ",")
        {
            var sb = new StringBuilder();
            var i = 0;
            foreach (Cookie c in cookies)
            {
                sb.Append(String.Format("{0} {1}", (i > 0) ? separator : "", transform(c)));
                i++;
            }
            return sb.ToString();
        }
    }
}
