using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Web.Html
{
    public sealed class HtmlLiteral : HtmlElement
    {
        public HtmlLiteral()
        {
            SelfClose = true;
        }
        private string text;
        public override string InnerText
        {
            get { return text; }
            set { text = value; }
        }
    }
}
