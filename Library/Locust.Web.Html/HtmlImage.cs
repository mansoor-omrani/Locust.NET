using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Web.Html
{
    public class HtmlImage: HtmlElement
    {
        private string alt;
        public string Alt
        {
            get
            {
                return alt;
            }
            set
            {
                SetAttribute("alt", alt);
            }
        }
        public HtmlImage()
        {
            TagName = "img";
            SelfClose = true;
        }
    }
}
