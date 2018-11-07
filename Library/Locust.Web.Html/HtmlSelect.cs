using Locust.Conversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Locust.Web.Html
{
    public class HtmlOptions : IList<HtmlOption>
    {
        private HtmlSelect parent;
        public HtmlSelect Parent
        {
            get { return parent; }
            set { parent = value; }
        }
        public HtmlOptions(HtmlSelect parent)
        {
            this.parent = parent;
        }
        public HtmlOption this[int index]
        {
            get
            {
                var element = parent.Children[index];
                var option = element as HtmlOption;

                return option;
            }

            set
            {
                parent.Children[index] = value;
            }
        }

        public int Count
        {
            get
            {
                return parent.Children.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public void Add(HtmlOption item)
        {
            parent.Children.Add(item);
        }

        public void Clear()
        {
            parent.Children.Clear();
        }

        public bool Contains(HtmlOption item)
        {
            return parent.Children.Contains(item);
        }

        public void CopyTo(HtmlOption[] array, int arrayIndex)
        {
            var source = new List<HtmlOption>();

            foreach (var element in parent.Children)
            {
                var option = element as HtmlOption;
                if (option != null)
                {
                    source.Add(option);
                }

            }

            Array.Copy(source.ToArray(), array, arrayIndex);
        }

        public IEnumerator<HtmlOption> GetEnumerator()
        {
            foreach (var element in parent.Children)
            {
                var option = element as HtmlOption;
                if (option != null)
                {
                    yield return option;
                }
            }
        }

        public int IndexOf(HtmlOption item)
        {
            return parent.Children.IndexOf(item);
        }

        public void Insert(int index, HtmlOption item)
        {
            parent.Children.Insert(index, item);
        }

        public bool Remove(HtmlOption item)
        {
            return parent.Children.Remove(item);
        }

        public void RemoveAt(int index)
        {
            parent.Children.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var element in parent.Children)
            {
                var option = element as HtmlOption;
                if (option != null)
                {
                    yield return option;
                }
            }
        }
    }
    public class HtmlSelect: HtmlElement
    {
        public HtmlSelect()
        {
            TagName = "select";
            ValueComparer = StringComparer.CurrentCultureIgnoreCase;
        }
        public IEqualityComparer<string> ValueComparer { get; set; }
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
        public bool Multiple
        {
            get
            {
                if (Attributes.ContainsKey("multiple"))
                    return true;

                return false;
            }
            set
            {
                if (value)
                    Attributes["multiple"] = "multiple";
                else
                {
                    if (Attributes.ContainsKey("multiple"))
                    {
                        Attributes.Remove("multiple");
                    }
                }
            }
        }
        public int? Size
        {
            get
            {
                if (Attributes.ContainsKey("size"))
                    return SafeClrConvert.ToInt(Attributes["size"]);

                return null;
            }
            set
            {
                if (value != null)
                    Attributes["size"] = value.ToString();
                else
                {
                    if (Attributes.ContainsKey("size"))
                    {
                        Attributes.Remove("size");
                    }
                }
            }
        }
        public string SelectedValue
        {
            get
            {
                var result = "";

                foreach (var option in Options)
                {
                    if (option.Selected)
                    {
                        result = option.Value;
                        break;
                    }
                }

                return result;
            }
            set
            {
                foreach (var option in Options)
                {
                    if (option.Selected)
                    {
                        if (string.Compare(option.Value, value, true) != 0)
                        {
                            option.Selected = false;
                        }
                    }
                    else
                    {
                        if (string.Compare(option.Value, value, true) == 0)
                        {
                            option.Selected = true;
                        }
                    }
                }
            }
        }
        public List<string> SelectedValues
        {
            get
            {
                var result = new List<string>();

                foreach (var option in Options)
                {
                    if (option.Selected)
                    {
                        result.Add(option.Value);
                    }
                }

                return result;
            }
            set
            {
                foreach (var option in Options)
                {
                    if (option.Selected)
                    {
                        if (!value?.Contains(option.Value, ValueComparer) ?? false)
                        {
                            option.Selected = false;
                        }
                    }
                    else
                    {
                        if (value?.Contains(option.Value, ValueComparer) ?? false)
                        {
                            option.Selected = true;
                        }
                    }
                }
            }
        }
        public int SelectedIndex
        {
            get
            {
                var result = -1;
                var index = 0;

                foreach (var option in Options)
                {
                    if (option.Selected)
                    {
                        result = index;
                        break;
                    }

                    index++;
                }

                return result;
            }
            set
            {
                var index = 0;

                foreach (var option in Options)
                {
                    if (option.Selected)
                    {
                        if (index != value)
                        {
                            option.Selected = false;
                        }
                    }
                    else
                    {
                        if (index == value)
                        {
                            option.Selected = true;
                        }
                    }

                    index++;
                }
            }
        }
        public List<int> SelectedIndexes
        {
            get
            {
                var result = new List<int>();
                var index = 0;
                foreach (var option in Options)
                {
                    if (option.Selected)
                    {
                        result.Add(index);
                    }
                    index++;
                }

                return result;
            }
            set
            {
                var index = 0;
                foreach (var option in Options)
                {
                    if (option.Selected)
                    {
                        if (!value?.Contains(index) ?? false)
                        {
                            option.Selected = false;
                        }
                    }
                    else
                    {
                        if (value?.Contains(index) ?? false)
                        {
                            option.Selected = true;
                        }
                    }
                    index++;
                }
            }
        }
        private string defaultValue;
        public string DefaultValue
        {
            get
            {
                return defaultValue;
            }
            set
            {
                defaultValue = value;

                if (string.IsNullOrEmpty(SelectedValue))
                {
                    SelectedValue = value;
                }
            }
        }
        private HtmlOption firstOption;
        public HtmlOption FirstOption
        {
            get
            {
                if (firstOption == null)
                {
                    firstOption = new HtmlOption();
                    Options.Insert(0, firstOption);
                }

                return firstOption;
            }
            set
            {
                if (value == null && firstOption != null)
                {
                    options.RemoveAt(0);
                    firstOption = null;
                }
                else
                {
                    firstOption = value;
                    Options[0] = value;
                }
            }
        }
        private HtmlOptions options;
        public HtmlOptions Options
        {
            get
            {
                if (options == null)
                    options = new HtmlOptions(this);

                return options;
            }
            set
            {
                this.Children.Clear();

                options = value;
                options.Parent = this;
            }
        }
    }
}
