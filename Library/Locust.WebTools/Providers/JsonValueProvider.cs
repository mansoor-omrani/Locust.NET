using Locust.Conversion;
using Locust.WebExtensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Locust.WebTools.Providers
{
    public class JsonValueProvider : ValueProviderFactory
    {
        public override IValueProvider GetValueProvider(ControllerContext controllerContext)
        {
            if (controllerContext == null)
            {
                throw new ArgumentNullException("controllerContext");
            }

            if (controllerContext.HttpContext == null)
            {
                throw new ArgumentNullException("controllerContext.HttpContext");
            }

            var data = "";

            try
            {
                var skip = SafeClrConvert.ToBoolean(controllerContext.HttpContext.Items["x_request_body_read"]);

                if (!skip)
                {
                    using (var reader = new StreamReader(controllerContext.HttpContext.Request.InputStream))
                    {
                        data = reader.ReadToEnd();
                    }

                    controllerContext.HttpContext.Items.Add("x_request_body_read", true);
                    controllerContext.HttpContext.Items.Add("x_request_body", data);
                }
                else
                {
                    data = controllerContext.HttpContext.Items["x_request_body"]?.ToString();
                }

                if (!string.IsNullOrEmpty(data) && controllerContext.HttpContext.Request.IsJson())
                {
                    data = data.Trim();

                    if (!string.IsNullOrEmpty(data))
                    {
                        Object JSONObject = null;

                        if (data[0] == '[')
                            JSONObject = JsonConvert.DeserializeObject<List<ExpandoObject>>(data,
                                new ExpandoObjectConverter());
                        else
                            JSONObject = JsonConvert.DeserializeObject<ExpandoObject>(data,
                                new ExpandoObjectConverter());

                        var backingStore =
                            new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);

                        if (JSONObject != null)
                        {
                            // add all properties to this backing store
                            AddToBackingStore(backingStore, String.Empty, JSONObject);
                        }

                        // return the object in a dictionary value provider so the MVC understands it
                        return new DictionaryValueProvider<object>(backingStore, CultureInfo.CurrentCulture);
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                
            }

            return null;
        }
        private void AddToBackingStore(Dictionary<string, object> backingStore, string prefix, object value)
        {
            var d = value as IDictionary<string, object>;

            if (d != null)
            {
                foreach (var entry in d)
                {
                    AddToBackingStore(backingStore, MakePropertyKey(prefix, entry.Key), entry.Value);
                }

                return;
            }

            var l = value as IList;

            if (l != null)
            {
                for (var i = 0; i < l.Count; i++)
                {
                    AddToBackingStore(backingStore, MakeArrayKey(prefix, i), l[i]);
                }

                return;
            }

            // primitive
            backingStore[prefix] = value;
        }

        private string MakeArrayKey(string prefix, int index)
        {
            return prefix + "[" + index.ToString(CultureInfo.InvariantCulture) + "]";
        }

        private string MakePropertyKey(string prefix, string propertyName)
        {
            return (String.IsNullOrEmpty(prefix)) ? propertyName : prefix + "." + propertyName;
        }
    }
}
