using Locust.Web.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Locust.Web.Mvc.Bootstrap3.Helpers
{
    public class HtmlHelperElement : IHtmlHelper
    {
        public HtmlElement Element { get; set; }
        private HtmlRenderer renderer;
        public HtmlRenderer Renderer
        {
            get
            {
                if (renderer == null)
                    renderer = new HtmlRenderer();

                return renderer;
            }
            set
            {
                renderer = value;
            }
        }
        public WebViewPage Page { get; set; }
        public HtmlHelperElement()
        {
        }
        public HtmlHelperElement(HtmlElement element)
        {
            Element = element;
        }
        public HtmlHelperElement(HtmlRenderer renderer, HtmlElement element)
        {
            Renderer = renderer;
            Element = element;
        }
        public HtmlHelperElement(HtmlRenderer renderer, HtmlElement element, WebViewPage page)
        {
            Renderer = renderer;
            Element = element;
            Page = page;
        }
        public virtual void Render()
        {
            var x = Renderer.RenderBegin(Element);

            if (!string.IsNullOrEmpty(x))
            {
                Page.Write(x);
            }
        }
        public virtual void Dispose()
        {
            var x = Renderer.RenderEnd(Element);

            if (!string.IsNullOrEmpty(x))
            {
                Page.Write(x);
            }
        }
    }
}
