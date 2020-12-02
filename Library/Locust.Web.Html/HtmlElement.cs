using Locust.Collections;
using Locust.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Locust.Web.Html
{
    public abstract class HtmlElement
    {
        public bool SelfClose { get; protected set; }
        public virtual string TagName { get; protected set; }
        public virtual string Id { get; set; }
        private IList<string> classes;
        public virtual IList<string> Classes
        {
            get
            {
                if (classes == null)
                    classes = new ItemEquatableList<string>(3);

                return classes;
            }
        }
        public virtual string Class
        {
            get
            {
                return Classes.Join(" ");
            }
        }
        private IDictionary<string, string> attributes;
        public virtual IDictionary<string, string> Attributes
        {
            get
            {
                if (attributes == null)
                    attributes = new CaseInsensitiveStringDictionary(ignoreNotExistingKeys: true);
                return attributes;
            }
            set
            {
                attributes = value;
            }
        }
        public string GetAttributes()
        {
            if (attributes == null)
            {
                return string.Empty;
            }

            var sb = new StringBuilder();
            foreach (var item in attributes)
            {
                if (TagName == "input" || TagName == "label" || TagName == "select" || TagName == "button" || TagName == "form")
                {
                    if (",readonly,disabled,novalidate,autofocus,multiple,required,".IndexOf("," + item.Key + ",") >= 0)
                    {
                        sb.Append($" {WebUtility.HtmlEncode(item.Key)}");
                    }
                    else
                    {
                        sb.Append($" {WebUtility.HtmlEncode(item.Key)}=\"{WebUtility.HtmlEncode(item.Value)}\"");
                    }
                }
                else
                {
                    sb.Append($" {WebUtility.HtmlEncode(item.Key)}=\"{WebUtility.HtmlEncode(item.Value)}\"");
                }
            }

            return sb.ToString();
        }
        public virtual void SetAttribute(string name, string value)
        {
            if (Attributes.ContainsKey(name))
                Attributes[name] = value;
            else
                Attributes.Add(name, value);
        }
        public virtual void SetStyle(string name, string value)
        {
            if (Styles.ContainsKey(name))
                Styles[name] = value;
            else
                Styles.Add(name, value);
        }
        public virtual void SetStyles(string styles)
        {
            if (string.IsNullOrEmpty(styles))
                return;

            var arrStyles = styles.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in arrStyles)
            {
                var i = item.IndexOf(':');
                if (i > 1 && i < item.Length)
                {
                    var key = item.Substring(0, i);
                    var value = item.Substring(i + 1);

                    SetStyle(key, value);
                }
            }
        }
        public virtual string[] GetClasses()
        {
            if (!string.IsNullOrEmpty(Class))
            {
                return Class.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(c => c.Trim()).ToArray();
            }

            return new string[] { };
        }
        private IDictionary<string, string> styles;
        public virtual IDictionary<string, string> Styles
        {
            get
            {
                if (styles == null)
                    styles = new CaseInsensitiveStringDictionary(ignoreNotExistingKeys: true);
                return styles;
            }
            set
            {
                styles = value;
            }
        }
        public virtual string GetStyles()
        {
            if (styles == null)
            {
                return string.Empty;
            }

            var sb = new StringBuilder();

            foreach (var item in styles)
            {
                var semicolon = sb.Length == 0 ? string.Empty : ";";

                sb.Append($"{WebUtility.HtmlEncode(item.Key)}: {WebUtility.HtmlEncode(item.Value)}{semicolon}");
            }

            return " style=\"" + sb.ToString() + "\"";
        }
        private List<HtmlElement> children;
        public virtual List<HtmlElement> Children
        {
            get
            {
                if (SelfClose || children == null)
                    children = new List<HtmlElement>();

                return children;
            }
            set
            {
                if (SelfClose)
                    throw new ApplicationException("This is not a container element");

                children = value;
            }
        }
        private string GetInnerText(HtmlElement e)
        {
            var sb = new StringBuilder();

            foreach (var child in e.Children)
            {
                sb.Append(child.InnerText);
            }

            return sb.ToString();
        }
        public virtual string InnerText
        {
            get
            {
                return GetInnerText(this);
            }
            set
            {
                Children.Clear();
                Children.Add(new HtmlLiteral { InnerText = value });
            }
        }
        public virtual string Title
        {
            get
            {
                return Attributes["title"];
            }
            set
            {
                SetAttribute("title", value);
            }
        }
    }
}
