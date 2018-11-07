using Locust.Extensions;
using Locust.Web.Html;
using Locust.Web.Mvc.Bootstrap3.Helpers;
using Locust.Web.Mvc.Bootstrap3.Helpers.Bootstrap;
using Locust.Web.Mvc.Bootstrap3.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Locust.Web.Mvc.Bootstrap3
{
    public partial class BootstrapHelper
    {
        protected static ConcurrentDictionary<Type, ConcurrentDictionary<string, object>> modelPropFuncCache;
        private WebViewPage page;
        private HtmlRenderer renderer;
        public WebViewPage Page => page;
        static BootstrapHelper()
        {
            modelPropFuncCache = new ConcurrentDictionary<Type, ConcurrentDictionary<string, object>>();
        }
        public BootstrapHelper(WebViewPage page)
        {
            this.page = page;
            renderer = new HtmlRenderer();
        }
        public MvcHtmlString Render(HtmlElement e)
        {
            return new MvcHtmlString(renderer.Render(e));
        }
        public IHtmlHelper RenderToPage(HtmlElement e)
        {
            var result = new HtmlHelperElement(renderer, e, Page);

            result.Render();

            return result;
        }
        private IHtmlHelper RenderToPage(IHtmlHelper e)
        {
            e.Page = Page;

            e.Render();

            return e;
        }
        public MvcHtmlString Button(string text, DisplayClass btnClass = DisplayClass.@default, ButtonSize? size = null)
        {
            return page.Html.Partial("Bootstrap.Button", BootstrapButton.Create(ButtonType.button, text, btnClass, size));
        }
        public MvcHtmlString SubmitButton(string text, DisplayClass btnClass = DisplayClass.@default, ButtonSize? size = null)
        {
            return page.Html.Partial("Bootstrap.Button", BootstrapButton.Create(ButtonType.submit, text, btnClass, size));
        }
        public MvcHtmlString Button(BootstrapButton button)
        {
            return page.Html.Partial("Bootstrap.Button", button);
        }
        public MvcHtmlString Glyph(GlyphType type, string id = "", string @class = "")
        {
            var g = new BootstrapGlyph(type);

            g.Id = id;
            g.Classes.Add(@class);

            return Render(g);
        }
        public MvcHtmlString Glyph(BootstrapGlyph glyph)
        {
            return Render(glyph);
        }
        public IHtmlHelper CreateGlyph(GlyphType type, string id = "", string @class = "")
        {
            var g = new BootstrapGlyph(type);

            g.Id = id;
            g.Classes.Add(@class);

            return RenderToPage(g);
        }
        public IHtmlHelper CreateGlyph(BootstrapGlyph glyph)
        {
            return RenderToPage(glyph);
        }
        public MvcHtmlString Image(string src, bool responsive = false, ImageShape shape = ImageShape.none, string id = "", string @class = "", string alt = "")
        {
            var e = new BootstrapImage { Id = id, Responsive = responsive, Shape = shape };

            e.Classes.Add(@class);

            return Render(e);
        }
        public MvcHtmlString Image(HtmlImage image)
        {
            return Render(image);
        }
        public MvcHtmlString Label(string text, bool sronly = false, string @class = "")
        {
            var e = new BootstrapLabel();

            e.ScreenReaderOnly = sronly;
            e.InnerText = text;
            e.Classes.Add(@class);

            return Render(e);
        }
        public MvcHtmlString Label(BootstrapLabel label)
        {
            return Render(label);
        }
        public MvcHtmlString Input(Html.InputType type, string name, string @class = "", string value = "")
        {
            var e = new BootstrapFormInput();

            e.Type = type;
            e.Id = name;
            e.Name = name;
            e.Classes.Add(@class);
            e.Value = value;

            return Render(e);
        }
        public MvcHtmlString Input(BootstrapFormInput input)
        {
            return Render(input);
        }
        public MvcHtmlString FormGroup(string label, Html.InputType inputType, string inputName, string inputValue = "")
        {
            var e = new BootstrapFormGroup();

            e.Label.InnerText = label;
            e.Input.Type = inputType;
            e.Input.Name = inputName;
            e.Input.Id = inputName;
            e.Input.Value = inputValue;

            return Render(e);
        }
        #region Modal
        public MvcHtmlString Modal(string id, string header, string body, List<BootstrapModalButton> buttons = null)
        {
            return page.Html.Partial("Bootstrap.Modal", new BootstrapModal
            {
                Id = id,
                HeaderText = header,
                BodyText = body,
                Buttons = buttons
            });
        }
        public MvcHtmlString Modal(string id, string header, object body, List<BootstrapModalButton> buttons = null)
        {
            return page.Html.Partial("Bootstrap.Modal", new BootstrapModal
            {
                Id = id,
                HeaderText = header,
                Body = body,
                Buttons = buttons
            });
        }
        public MvcHtmlString Modal(string id, string header, string bodyTemplateName, object bodyTemplateModel, List<BootstrapModalButton> buttons)
        {
            return page.Html.Partial("Bootstrap.Modal", new BootstrapModal
            {
                Id = id,
                HeaderText = header,
                BodyTemplateName = bodyTemplateName,
                BodyTemplateModel = bodyTemplateModel,
                Buttons = buttons
            });
        }
        public MvcHtmlString Modal(BootstrapModal model)
        {
            return page.Html.Partial("Bootstrap.Modal", model);
        }
        public MvcHtmlString ModalConfirm(string id, string header, string body, string buttons)
        {
            var arr = buttons.Split(",", MyStringSplitOptions.TrimAndRemoveEmptyEntries);
            var btns = new List<BootstrapModalButton>();

            foreach (var item in arr)
            {
                var _id = "";
                var _text = "";
                var _size = ButtonSize.xs;
                var _display = DisplayClass.@default;

                var props = item.Split(":", MyStringSplitOptions.TrimAndRemoveEmptyEntries);
                _text = props[0];

                if (props.Length > 1)
                {
                    for (var i = 1; i < props.Length; i++)
                    {
                        var x = props[i];

                        if (Enum.GetNames(typeof(ButtonSize)).Contains(x))
                        {
                            _size = (ButtonSize)Enum.Parse(typeof(ButtonSize), x);
                            continue;
                        }

                        if (Enum.GetNames(typeof(DisplayClass)).Contains(x))
                        {
                            _display = (DisplayClass)Enum.Parse(typeof(DisplayClass), x);
                            continue;
                        }

                        _id = x;
                    }
                }

                btns.Add(new BootstrapModalButton { Text = _text, Size = _size, Id = _id, ButtonClass = _display });
            }

            return Modal(id, header, body, btns);
        }
        public IHtmlHelper CreateModal(string id, string header, string body = "")
        {
            var result = new BootstrapModalHelper { Id = id, Header = header, Body = body };

            return RenderToPage(result);
        }
        public IHtmlHelper CreateModal(string id)
        {
            var result = new BootstrapModalHelper
            {
                Id = id,
                RenderHeaderManually = true,
                RenderBodyManually = true,
                RenderFooterManually = true
            };

            return RenderToPage(result);
        }
        public IHtmlHelper CreateModalHeader(string modalid = "", string header = "")
        {
            var result = new BootstrapModalHeaderHelper { ModalId = modalid, Text = header };

            result.ManualContent = string.IsNullOrEmpty(modalid) && string.IsNullOrEmpty(header);

            return RenderToPage(result);
        }
        public IHtmlHelper CreateModalBody(string text = "")
        {
            var result = new BootstrapModalBody();

            if (!string.IsNullOrEmpty(text))
            {
                result.Children.Add(new HtmlLiteral { InnerText = text });
            }

            return RenderToPage(result);
        }
        public MvcHtmlString ModalClose()
        {
            return new MvcHtmlString(@"<button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close""><span aria-hidden=""true"">&times;</span></button>");
        }
        #endregion
        #region HTML
        public IHtmlHelper CreateDiv(int number, string id = "", string @class = "", string styles = "")
        {
            var div = new HtmlDiv { Id = id };

            div.Classes.Add(@class);
            div.SetStyles(styles);

            return RenderToPage(div);
        }
        public IHtmlHelper CreateSpan(int number, string id = "", string @class = "", string styles = "")
        {
            var span = new HtmlSpan { Id = id };

            span.Classes.Add(@class);
            span.SetStyles(styles);

            return RenderToPage(span);
        }
        #endregion
    }
    public partial class BootstrapHelper<TModel>: BootstrapHelper
    {
        public BootstrapHelper(WebViewPage page): base(page)
        {
        }
        private Func<TModel, TModelProperty> GetFunc<TModelProperty>(Expression<Func<TModel, TModelProperty>> e)
        {
            var x = modelPropFuncCache.GetOrAdd(typeof(TModel), new ConcurrentDictionary<string, object>());
            if (e.Body.NodeType == ExpressionType.MemberAccess)
            {
                var memberExp = (MemberExpression)e.Body;
                var propertyName = memberExp.Member is PropertyInfo ? memberExp.Member.Name : null;
                return x.GetOrAdd(propertyName, e.Compile()) as Func<TModel, TModelProperty>;
            }
            return null;
        }
        public MvcHtmlString LabelFor<TModelProperty>(Expression<Func<TModel, TModelProperty>> exp, bool sronly = false, string @class = "")
        {
            var f = GetFunc<TModelProperty>(exp) as Func<TModel, TModelProperty>;
            var label = f((TModel)Page.Model).ToString();

            return Label(label, sronly, @class);
        }
    }
}
