using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Locust.WebExtensions
{
    public static class StringExtensions
    {
        public static string HtmlEncode(this string s)
        {
            return HttpUtility.HtmlEncode(s);
        }
        public static void HtmlEncode(this string s, TextWriter writer)
        {
            HttpUtility.HtmlEncode(s, writer);
        }
        public static string HtmlDecode(this string s)
        {
            return HttpUtility.HtmlDecode(s);
        }
        public static void HtmlDecode(this string s, TextWriter writer)
        {
            HttpUtility.HtmlDecode(s, writer);
        }
        public static string UrlEncode(this string s)
        {
            return HttpUtility.UrlEncode(s);
        }
        public static string UrlEncode(this string s, Encoding e)
        {
            return HttpUtility.UrlEncode(s, e);
        }
        public static string UrlDecode(this string s)
        {
            return HttpUtility.UrlDecode(s);
        }
        public static string UrlDecode(this string s, Encoding e)
        {
            return HttpUtility.UrlDecode(s, e);
        }
        public static byte[] UrlEncodeToBytes(this string s)
        {
            return HttpUtility.UrlEncodeToBytes(s);
        }
        public static byte[] UrlEncodeToBytes(this string s, Encoding e)
        {
            return HttpUtility.UrlEncodeToBytes(s, e);
        }
        public static byte[] UrlDecodeToBytes(this string s)
        {
            return HttpUtility.UrlDecodeToBytes(s);
        }
        public static byte[] UrlDecodeToBytes(this string s, Encoding e)
        {
            return HttpUtility.UrlDecodeToBytes(s, e);
        }
        public static string HtmlAttributeEncode(this string s)
        {
            return HttpUtility.HtmlAttributeEncode(s);
        }
        public static void HtmlAttributeEncode(this string s, TextWriter writer)
        {
            HttpUtility.HtmlAttributeEncode(s, writer);
        }
        public static string JavascriptDecode(this string s)
        {
            return HttpUtility.JavaScriptStringEncode(s);
        }
        public static string JavascriptDecode(this string s, bool addDoubleQuotes)
        {
            return HttpUtility.JavaScriptStringEncode(s, addDoubleQuotes);
        }
        public static NameValueCollection ParseQueryString(this string s)
        {
            return HttpUtility.ParseQueryString(s);
        }
        public static NameValueCollection ParseQueryString(this string s, Encoding encoding)
        {
            return HttpUtility.ParseQueryString(s, encoding);
        }
    }
}
