using Locust.Base;
using Locust.Collections;
using Locust.Conversion;
using Locust.Expressions;
using Locust.Extensions;
using Locust.Reflection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Routing;

namespace Locust.WebExtensions
{
    public static class WebHelper
    {
        public static IEnumerable<SelectListItem> CreateSelectList(Type enumType, int? value, IEnumerable<string> itemTexts = null)
        {
            List<SelectListItem> result = null;

            if (enumType != null && enumType.IsEnum)
            {
                var arr = Enum.GetValues(enumType);
                result = new List<SelectListItem>();

                if (itemTexts != null)
                {
                    var e = itemTexts.GetEnumerator();
                    var hasItem = e.MoveNext();

                    foreach (var item in arr)
                    {
                        result.Add(new SelectListItem
                        {
                            Text = hasItem ? e.Current : Enum.GetName(enumType, item),
                            Value = (System.Convert.ToInt32(item)).ToString(),
                            Selected = System.Convert.ToInt32(item) == value
                        });

                        if (hasItem)
                            hasItem = e.MoveNext();
                    }
                }
                else
                {
                    foreach (var item in arr)
                    {
                        result.Add(new SelectListItem
                        {
                            Text = Enum.GetName(enumType, item),
                            Value = (System.Convert.ToInt32(item)).ToString(),
                            Selected = System.Convert.ToInt32(item) == value
                        });
                    }
                }
            }

            if (result == null)
            {
                result = new List<SelectListItem>();
            }

            return result;
        }
        public static IEnumerable<SelectListItem> CreateSelectList<T>(int? value, IEnumerable<string> itemTexts = null) where T : struct
        {
            return CreateSelectList(typeof(T), value, itemTexts);
        }
        public static ViewDataDictionary ToViewData(object x)
        {
            var result = new ViewDataDictionary();

            if (x != null)
            {
                var props = GlobalReflectionPropertyCache.Cache.GetPublicInstanceReadableProperties(x.GetType());

                foreach (var prop in props)
                {
                    result.Add(prop.Name, GlobalPropertyProvider.Read(x, prop.Name));
                }
            }

            return result;
        }
        public static ViewDataDictionary ToPackedViewData(object x)
        {
            var result = new ViewDataDictionary();

            result.Add("viewdata", x);

            return result;
        }
        public static RouteValueDictionary ToRouteValues(object x)
        {
            var result = new RouteValueDictionary();

            if (x != null)
            {
                var props = GlobalReflectionPropertyCache.Cache.GetPublicInstanceReadableProperties(x.GetType());

                foreach (var prop in props)
                {
                    result.Add(prop.Name, GlobalPropertyProvider.Read(x, prop.Name));
                }
            }

            return result;
        }
        public static string MakeSeoFriendly(string name, Dictionary<char, string> customReplace = null)
        {
            var result = "";

            if (!string.IsNullOrEmpty(name))
            {
                var buffer = new CharBuffer(32);
                var prev_ch = default(char);

                foreach (var ch in name)
                {
                    if (customReplace != null && customReplace.Count > 0)
                    {
                        var replace = "";
                        if (customReplace.TryGetValue(ch, out replace))
                        {
                            buffer.Append(replace);
                            continue;
                        }
                    }

                    if (ch == '&')
                    {
                        buffer.Append("and");
                        continue;
                    }

                    if (ch.In('+', '/', '\\', '|', '.', '?', '!', '*', '#', ':', '>', '<', '%', '@', '$', '^', '\t', '\n', '\r'))
                    {
                        continue;
                    }

                    if (ch.In('-', ' ', '(', ')'))
                    {
                        if (prev_ch != '-')
                            buffer.Append('-');
                        prev_ch = '-';
                    }
                    else
                    {
                        buffer.Append(ch);
                        prev_ch = ch;
                    }
                }

                result = buffer.ToString();

                if (result[result.Length - 1] == '-')
                    result = result.Left(result.Length - 1);
            }

            return result;
        }
    }
}
