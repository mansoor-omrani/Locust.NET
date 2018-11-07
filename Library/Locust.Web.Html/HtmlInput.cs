using Locust.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Web.Html
{
    public enum InputMode
    {
        verbatim,
        latin,
        latinName,
        latinProse,
        fullWidthLatin,
        kana,
        katakana,
        numeric,
        tel,
        email,
        url
    }
    public enum InputType
    {
        text,
        button,
        checkbox,
        color,
        date,
        datetimeLocal,
        email,
        file,
        hidden,
        image,
        month,
        number,
        password,
        radio,
        range,
        reset,
        search,
        submit,
        tel,
        time,
        url,
        week
    }
    public class HtmlInput : HtmlElement
    {
        private InputType type;
        public InputType Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;

                SetAttribute("type", value.ToString().UnCamel());
            }
        }
        private InputMode inputmode;
        public InputMode InputMode
        {
            get
            {
                return inputmode;
            }
            set
            {
                inputmode = value;
                SetAttribute("inputmode", value.ToString().UnCamel());
            }
        }
        public string PlaceHolder
        {
            get
            {
                return Attributes["placeholder"];
            }
            set
            {
                SetAttribute("placeholder", value);
            }
        }
        private bool @checked;
        public bool Checked
        {
            get
            {
                return @checked;
            }
            set
            {
                @checked = value;
                if (value)
                    SetAttribute("checked", "checked");
                else
                    Attributes.Remove("checked");
            }
        }
        private bool @readonly;
        public bool Readonly
        {
            get
            {
                return @readonly;
            }
            set
            {
                @readonly = value;
                if (value)
                    SetAttribute("readonly", "readonly");
                else
                    Attributes.Remove("readonly");
            }
        }
        private bool @autofocus;
        public bool AutoFocus
        {
            get
            {
                return @autofocus;
            }
            set
            {
                @autofocus = value;
                if (value)
                    SetAttribute("autofocus", "autofocus");
                else
                    Attributes.Remove("autofocus");
            }
        }
        private bool @disabled;
        public bool Disabled
        {
            get
            {
                return @disabled;
            }
            set
            {
                @disabled = value;
                if (value)
                    SetAttribute("disabled", "disabled");
                else
                    Attributes.Remove("disabled");
            }
        }
        public string Name
        {
            get
            {
                return Attributes["name"];
            }
            set
            {
                SetAttribute("name", value);
            }
        }
        public string Pattern
        {
            get
            {
                return Attributes["pattern"];
            }
            set
            {
                SetAttribute("pattern", value);
            }
        }
        public string List
        {
            get
            {
                return Attributes["list"];
            }
            set
            {
                SetAttribute("list", value);
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
        public string FormAction
        {
            get
            {
                return Attributes["formaction"];
            }
            set
            {
                SetAttribute("formaction", value);
            }
        }
        public string FormEnctype
        {
            get
            {
                return Attributes["formenctype"];
            }
            set
            {
                SetAttribute("formenctype", value);
            }
        }
        public string FormTarget
        {
            get
            {
                return Attributes["formtarget"];
            }
            set
            {
                SetAttribute("formtarget", value);
            }
        }
        private bool formnovalidate;
        public bool FormNoValidate
        {
            get
            {
                return formnovalidate;
            }
            set
            {
                formnovalidate = value;
                if (value)
                    SetAttribute("formnovalidate", "formnovalidate");
                else
                    Attributes.Remove("formnovalidate");
            }
        }
        private bool novalidate;
        public bool NoValidate
        {
            get
            {
                return novalidate;
            }
            set
            {
                novalidate = value;
                if (value)
                    SetAttribute("novalidate", "novalidate");
                else
                    Attributes.Remove("novalidate");
            }
        }
        private HttpMethod formmethod;
        public HttpMethod FormMethod
        {
            get
            {
                return formmethod;
            }
            set
            {
                formmethod = value;
                SetAttribute("formmethod", value.ToString());
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
        private int size;
        public int Size
        {
            get
            {
                return size;
            }
            set
            {
                size = value;
                SetAttribute("size", size.ToString());
            }
        }
        private int min;
        public int Min
        {
            get
            {
                return min;
            }
            set
            {
                min = value;
                SetAttribute("min", min.ToString());
            }
        }
        private int max;
        public int Max
        {
            get
            {
                return max;
            }
            set
            {
                max = value;
                SetAttribute("max", max.ToString());
            }
        }
        private int maxlength;
        public int MaxLength
        {
            get
            {
                return maxlength;
            }
            set
            {
                maxlength = value;
                SetAttribute("maxlength", maxlength.ToString());
            }
        }
        private bool @autocomplete;
        public bool AutoComplete
        {
            get
            {
                return @autocomplete;
            }
            set
            {
                @autocomplete = value;
                if (value)
                    SetAttribute("autocomplete", (@autocomplete ? "on" : "off"));
                else
                    Attributes.Remove("autocomplete");
            }
        }
        private int width;
        public int Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
                SetAttribute("width", width.ToString());
            }
        }
        private int height;
        public int Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
                SetAttribute("Height", height.ToString());
            }
        }
        private int step;
        public int Step
        {
            get
            {
                return step;
            }
            set
            {
                step = value;
                SetAttribute("step", step.ToString());
            }
        }
        private bool multiple;
        public bool Multiple
        {
            get
            {
                return multiple;
            }
            set
            {
                multiple = value;
                if (multiple)
                    SetAttribute("multiple", "multiple");
                else
                    Attributes.Remove("multiple");
            }
        }
        private bool required;
        public bool Required
        {
            get
            {
                return required;
            }
            set
            {
                required = value;
                if (required)
                    SetAttribute("required", "required");
                else
                    Attributes.Remove("required");
            }
        }
        public HtmlInput()
        {
            TagName = "input";
            SelfClose = true;
        }
    }
}
