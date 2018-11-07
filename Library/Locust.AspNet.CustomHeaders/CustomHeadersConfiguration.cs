using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Locust.AspNet.CustomHeaders
{
    public class CustomHeadersSection : ConfigurationSection
    {
        [ConfigurationProperty("", IsRequired = true, IsDefaultCollection = true)]
        [ConfigurationCollection(typeof(CustomHeadersCollection),
          AddItemName = "add",
          RemoveItemName = "remove")]
        public CustomHeadersCollection Headers
        {
            get { return (CustomHeadersCollection)this[""]; }
            set { this[""] = value; }
        }
    }
    [ConfigurationCollection(typeof(CustomHeaderElement))]
    public class CustomHeadersCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new CustomHeaderElement();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((CustomHeaderElement)element).Name;
        }
        public List<CustomHeader> GetAll()
        {
            var result = new List<CustomHeader>();
            var itemsProp = this.GetType().BaseType.GetProperty("Items", BindingFlags.NonPublic | BindingFlags.Instance);
            var arr = itemsProp.GetValue(this) as ArrayList;
            Type type = null;

            foreach (var a in arr)
            {
                if (type == null)
                    type = a.GetType();

                var item = new CustomHeader();

                FieldInfo fld;
                object fldValue;

                fld = type.GetField("_key", BindingFlags.NonPublic | BindingFlags.Instance);
                if (fld != null)
                {
                    fldValue = fld.GetValue(a);
                    item.Name = fldValue?.ToString();
                }

                fld = type.GetField("_value", BindingFlags.NonPublic | BindingFlags.Instance);
                if (fld != null)
                {
                    fldValue = fld.GetValue(a);
                    if (fldValue != null)
                    {
                        var cs = fldValue as CustomHeaderElement;

                        item.Value = cs?.Value;
                    }
                }

                fld = type.GetField("_entryType", BindingFlags.NonPublic | BindingFlags.Instance);

                if (fld != null)
                {
                    fldValue = fld.GetValue(a);
                    if (fldValue != null)
                    {
                        item.Add = fldValue.ToString() != "Removed";
                    }
                }

                result.Add(item);
            }

            return result;
        }
    }
    public class CustomHeader
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public bool Add { get; set; }
    }
    public class CustomHeaderElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
        public string Name
        {
            get { return (string)base["name"]; }
            set { base["name"] = value; }
        }
        [ConfigurationProperty("value")]
        public string Value
        {
            get { return (string)base["value"]; }
            set { base["value"] = value; }
        }
        public bool Added { get; set; }
    }
}
