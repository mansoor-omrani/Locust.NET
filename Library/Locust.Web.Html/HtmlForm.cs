using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Web.Html
{
    public enum HttpMethod
    {
        Get,
        Post,
        Put,
        Delete,
        Options,
        Head,
        Trace
    }
    public static class FormEncType
    {
        public static string Plain => "text/plain";
        public static string MultiPart => "multipart/form-data";
        public static string Form => "application/x-www-form-urlencoded";
    }
    public class HtmlForm : HtmlElement
    {
        private string action;
        public string Action
        {
            get
            {
                return action;
            }
            set
            {
                action = value;
                SetAttribute("action", value);
            }
        }
        private HttpMethod method;
        public HttpMethod Method
        {
            get
            {
                return method;
            }
            set
            {
                method = value;
                SetAttribute("method", value.ToString());
            }
        }
        private string enctype;
        public string EncType
        {
            get
            {
                return enctype;
            }
            set
            {
                if (
                        !string.IsNullOrEmpty(value) && !string.IsNullOrWhiteSpace(value) &&
                        (
                            (string.Compare(value, FormEncType.Plain, StringComparison.InvariantCultureIgnoreCase) == 0)
                            ||
                            (string.Compare(value, FormEncType.MultiPart, StringComparison.InvariantCultureIgnoreCase) == 0)
                            ||
                            (string.Compare(value, FormEncType.Form, StringComparison.InvariantCultureIgnoreCase) == 0)
                        )
                    )
                {
                    enctype = value;
                    SetAttribute("enctype", value);
                }
            }
        }
        public HtmlForm()
        {
            TagName = "form";
        }
    }
}
