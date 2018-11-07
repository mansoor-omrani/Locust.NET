using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Web.Html
{
    public class HtmlLabel : HtmlElement
    {
        public string For
        {
            get
            {
                return Attributes["for"];
            }
            set
            {
                SetAttribute("for", value);
            }
        }
        public string Form
        {
            get
            {
                return Attributes["form"];
            }
            set
            {
                SetAttribute("form", value);
            }
        }
        public HtmlLabel()
        {
            TagName = "label";
        }
    }
}
