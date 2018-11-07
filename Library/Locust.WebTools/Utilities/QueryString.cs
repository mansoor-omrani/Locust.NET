using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Locust.WebTools
{
    public class QueryStringHelper
    {
        private HttpContext context;
        private string toStringResult;
        private bool toStringResultIsUptoDate;
        private Dictionary<string, string> parameters;
        private List<string> defaults;
        public Dictionary<string, string> Parameter { get { return parameters; } }

        public QueryStringHelper()
        {
            parameters = new Dictionary<string, string>();
            defaults = new List<string>();
            context = HttpContext.Current;
            toStringResult = "";
            toStringResultIsUptoDate = false;
        }
        public void Add(string name, string value, string defaultValue = "")
        {
            if (!parameters.ContainsKey(name))
            {
                parameters.Add(name, value);
                defaults.Add(defaultValue);
                toStringResultIsUptoDate = false;
            }
        }
        public string this[int index]
        {
            get
            {
                return parameters.ElementAtOrDefault(index).Value;
            }
        }
        public string this[string name]
        {
            get
            {
                return parameters[name];
            }
            set
            {
                parameters[name] = value;
                toStringResultIsUptoDate = false;
            }
        }
        public int Count
        {
            get { return parameters.Count; }
        }
        public override string ToString()
        {
            if (!toStringResultIsUptoDate)
            {
                toStringResult = "";
                var i = 0;
                foreach (var p in parameters)
                {
                    if (String.Compare(p.Value, defaults[i], false) != 0)
                    {
                        if (!String.IsNullOrEmpty(p.Value))
                        {
                            var param = p.Key + "=" + context.Server.UrlEncode(p.Value);
                            toStringResult = (toStringResult.Length > 0) ? toStringResult + "&" + param : param;
                        }
                    }
                    i++;
                }
                toStringResultIsUptoDate = true;
            }

            return toStringResult;
        }
        public string QueryString
        {
            get
            {
                var s = ToString();
                if (String.IsNullOrEmpty(s))
                    return "";
                else
                    return "?" + s;
            }
        }
    }
}