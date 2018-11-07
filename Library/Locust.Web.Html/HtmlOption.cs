using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Web.Html
{
    public class HtmlOption: HtmlElement
    {
        public HtmlOption()
        {
            TagName = "option";
        }
        public bool Selected
        {
            get
            {
                if (Attributes.ContainsKey("selected"))
                    return true;

                return false;
            }
            set
            {
                if (value)
                    Attributes["selected"] = "selected";
                else
                {
                    if (Attributes.ContainsKey("selected"))
                    {
                        Attributes.Remove("selected");
                    }
                }
            }
        }
        public string Value
        {
            get
            {
                return Attributes["value"];
            }
            set
            {
                SetAttribute("value", value);
            }
        }
        public string Text
        {
            get
            {
                return this.InnerText;
            }
            set
            {
                this.InnerText = value;
            }
        }
    }
}
