using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Web.Html
{
    public class HtmlRenderableElement
    {
        protected HtmlRenderer renderer;
        public HtmlRenderableElement()
        {
            renderer = new HtmlRenderer();
        }
        public virtual HtmlElement Element { get; set; }
        public virtual string RenderBegin()
        {
            return renderer.RenderBegin(Element);
        }
        public virtual string RenderChildren()
        {
            return renderer.RenderChildren(Element);
        }
        public virtual string RenderEnd()
        {
            return renderer.RenderEnd(Element);
        }
        public virtual string Render()
        {
            return renderer.Render(Element);
        }
        #region Decorator members
        public bool SelfClose { get { return Element.SelfClose; } }
        public virtual string TagName { get { return Element.TagName; } }
        public string Id { get { return Element.Id; } set { Element.Id = value; } }
        public string Class { get { return Element.Class; } }
        public IList<string> Classes
        {
            get
            {
                return Element.Classes;
            }
        }
        public IDictionary<string, string> Attributes
        {
            get
            {
                return Element.Attributes;
            }
            set
            {
                Element.Attributes = value;
            }
        }
        public string GetAttributes()
        {
            return Element.GetAttributes();
        }
        public void SetStyles(string styles)
        {
            Element.SetStyles(styles);
        }
        public string[] GetClasses()
        {
            return Element.GetClasses();
        }
        public IDictionary<string, string> Styles
        {
            get
            {
                return Element.Styles;
            }
            set
            {
                Element.Styles = value;
            }
        }
        public string GetStyles()
        {
            return Element.GetStyles();
        }
        public List<HtmlElement> Children
        {
            get
            {
                return Element.Children;
            }
            set
            {
                Element.Children = value;
            }
        }
        public string InnerText
        {
            get { return Element.InnerText; }
            set { Element.InnerText = value; }
        }
        #endregion
    }
    public class HtmlRenderableElement<T>: HtmlRenderableElement where T: HtmlElement, new()
    {
        private T e;
        public HtmlRenderableElement()
        {
            e = new T();
        }
        public override HtmlElement Element
        {
            get
            {
                return e;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Element");

                var _e = value as T;

                if (_e == null)
                    throw new Exception("Type mismatch");

                e = _e;
            }
        }
    }
}
