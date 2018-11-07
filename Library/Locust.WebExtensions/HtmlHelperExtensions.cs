using Locust.Expressions;
using Locust.Extensions;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Locust.WebExtensions
{
    public static class HtmlHelperExtensions
    {
        private static PropertyProvider propProvider = new PropertyProvider();
        public static IDictionary<string, object> AttributesAndData(this HtmlHelper helper, object dataArgs, object attributes, bool uncamel = false)
        {
            return helper.Attributes(attributes).Merge(helper.Data(dataArgs, uncamel));
        }
        public static IDictionary<string, object> DataAndAttributes(this HtmlHelper helper, object dataArgs, object attributes, bool uncamel = false)
        {
            return helper.Data(dataArgs, uncamel).Merge(helper.Attributes(attributes));
        }
        public static IDictionary<string, object> PostDataAndAttributes(this HtmlHelper helper, object postDataArgs, object attributes, bool uncamel = false)
        {
            return helper.PostData(postDataArgs, uncamel).Merge(helper.Attributes(attributes));
        }
        public static IDictionary<string, object> AttributesAndPostData(this HtmlHelper helper, object postDataArgs, object attributes, bool uncamel = false)
        {
            return helper.Attributes(attributes).Merge(helper.PostData(postDataArgs, uncamel));
        }
        public static IDictionary<string, object> DataAndPostData(this HtmlHelper helper, object dataArgs, object postDataArgs, bool uncamel = false)
        {
            return helper.Data(dataArgs, uncamel).Merge(helper.PostData(postDataArgs, uncamel));
        }
        public static IDictionary<string, object> DataAndPostDataAndAttributes(this HtmlHelper helper, object dataArgs, object postDataArgs, object attributes, bool uncamel = false)
        {
            return helper.Data(dataArgs, uncamel).Merge(helper.PostData(postDataArgs, uncamel)).Merge(helper.Attributes(attributes));
        }
        public static IDictionary<string, object> Attributes(this HtmlHelper helper, object args)
        {
            var result = (IDictionary<string, object>)null;

            if (args != null)
            {
                result = new Dictionary<string, object>();
                var props = PropertyProvider.PropertyCache.GetPublicInstanceReadableProperties(args.GetType());

                foreach (var prop in props)
                {
                    if (prop.CanRead)
                    {
                        result.Add(prop.Name, propProvider.Read(args, prop.Name));
                    }
                }
            }

            return result;
        }
        public static IDictionary<string, object> Data(this HtmlHelper helper, object args, bool uncamel = false)
        {
            return helper.Data("", args, uncamel);
        }
        public static IDictionary<string, object> Data(this HtmlHelper helper, string prefix, object args, bool uncamel = false)
        {
            var result = (IDictionary<string, object>)null;

            if (args != null)
            {
                result = new Dictionary<string, object>();
                prefix = string.IsNullOrEmpty(prefix) ? "" : prefix + "-";
                var props = PropertyProvider.PropertyCache.GetPublicInstanceReadableProperties(args.GetType());

                foreach (var prop in props)
                {
                    if (prop.CanRead)
                    {
                        result.Add("data-" + prefix + (!uncamel ? prop.Name : prop.Name.UnCamel()), propProvider.Read(args, prop.Name));
                    }
                }
            }

            return result;
        }
        public static IDictionary<string, object> PostData(this HtmlHelper helper, object args, bool uncamel = false)
        {
            return helper.Data("post", args, uncamel);
        }
    }
}
