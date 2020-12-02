using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Locust.Web.Html
{
    public class HtmlRenderer
    {
        public virtual string RenderBegin(HtmlElement element)
        {
            if (element == null)
                return string.Empty;

            var literal = element as HtmlLiteral;
            if (literal != null)
                return literal.InnerText;

            var id = string.IsNullOrEmpty(element.Id) ? string.Empty : $" id=\"{WebUtility.HtmlEncode(element.Id)}\"";
            var @class = string.IsNullOrEmpty(element.Class) ? string.Empty : $" class=\"{WebUtility.HtmlEncode(element.Class)}\"";
            var attrs = element.GetAttributes();
            var styles = element.GetStyles();
            var selfClose = element.SelfClose ? "/" : string.Empty;

            return $"<{element.TagName}{id}{@class}{attrs}{styles}{selfClose}>";
        }
        public virtual string RenderChildren(HtmlElement element)
        {
            if (element == null)
                return string.Empty;

            var literal = element as HtmlLiteral;
            if (literal != null)
                return literal.InnerText;

            var sb = new StringBuilder();

            //sb.Append(element.InnerText);

            foreach (var x in element.Children)
            {
                sb.Append(Render(x));
            }

            return sb.ToString();
        }
        public virtual string RenderEnd(HtmlElement element)
        {
            if (element == null)
                return string.Empty;

            var literal = element as HtmlLiteral;
            if (literal != null)
                return string.Empty;

            return element.SelfClose ? string.Empty : $"</{element.TagName}>";
        }
        public virtual string Render(HtmlElement element)
        {
            if (element == null)
                return string.Empty;

            var literal = element as HtmlLiteral;
            if (literal != null)
                return literal.InnerText;

            var sb = new StringBuilder();

            sb.Append(RenderBegin(element));
            sb.Append(RenderChildren(element));
            sb.Append(RenderEnd(element));

            return sb.ToString();
        }
    }
}
