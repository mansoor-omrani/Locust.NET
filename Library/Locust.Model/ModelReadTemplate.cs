using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Locust.Base;
using Locust.Calendar;
using Locust.Conversion;
using Locust.Extensions;
using Locust.Json;
using JsonReader = Locust.Json.JsonReader;

namespace Locust.Model
{
    public class ModelReadTemplate: JsonModel
    {
        public JsonArrayOfObject<ModelReadTemplateItem> Items { get; protected set; }
        public StringComparison DefaultComparison { get; set; }
        public ModelReadType DefaultConversion { get; set; }
        protected override void OnBasicPropertyDetected(string propertyName, string propertyValue, JsonValueType itemType)
        {
            var isNumeric = !string.IsNullOrEmpty(propertyValue) && propertyValue.GetType().IsNumeric();

            switch (propertyName[9])
            {
                case 'm':
                    if (isNumeric)
                    {
                        DefaultComparison = SafeClrConvert.ToInt32(propertyValue).ToEnum<StringComparison>();
                    }
                    else
                    {
                        StringComparison x;

                        if (Enum.TryParse(propertyValue, out x))
                        {
                            DefaultComparison = x;
                        }
                    }
                    break;
                case 'n':
                    if (isNumeric)
                    {
                        DefaultConversion = SafeClrConvert.ToInt32(propertyValue).ToEnum<ModelReadType>();
                    }
                    else
                    {
                        ModelReadType x;

                        if (Enum.TryParse(propertyValue, out x))
                        {
                            DefaultConversion = x;
                        }
                    }
                    break;
            }
        }

        protected override bool OnArrayPropertyDetected(string propertyName, JsonReader reader)
        {
            if (propertyName == "items" || propertyName == "i")
            {
                Items.ReadJson(reader);

                return true;
            }
            else
            {
                return false;
            }
        }

        protected static ConcurrentDictionary<Type, ModelReadTemplate> defaultTemplates = new ConcurrentDictionary<Type, ModelReadTemplate>();
        public static ModelReadTemplate GetDefault<T>(ModelReadType defaultConversion = ModelReadType.SafeConvert, bool useCache = true)
        {
            return GetDefault(typeof(T), defaultConversion);
        }
        public static ModelReadTemplate GetDefault(Type type, ModelReadType defaultConversion = ModelReadType.SafeConvert, bool useCache = true)
        {
            ModelReadTemplate result;

            if (!defaultTemplates.ContainsKey(type) || !useCache)
            {
                result = new ModelReadTemplate();

                foreach (PropertyInfo property in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {
                    var x = property.Name;
                    if (BaseModel.IsBindable(property))
                    {
                        var mrti = new ModelReadTemplateItem
                        {
                            Source = x,
                            Target = x,
                            Conversion = defaultConversion
                        };

                        result.Items.Add(mrti);
                    }
                    else
                    {
                        if (property.PropertyType.DescendsFrom(typeof (BaseModel)))
                        {
                            var propertyTemplate = GetDefault(property.PropertyType, defaultConversion, useCache);

                            foreach (var item in propertyTemplate.Items)
                            {
                                var mrti = new ModelReadTemplateItem
                                {
                                    Source = x + "." + item.Source,
                                    Target = x + "." + item.Target,
                                    Conversion = defaultConversion
                                };

                                result.Items.Add(mrti);
                            }
                        }
                    }
                }

                defaultTemplates.TryAdd(type, result);
            }
            else
            {
                result = defaultTemplates[type];
            }

            return result;
        }
        public ModelReadTemplate Reverse()
        {
            var result = new ModelReadTemplate();

            foreach (var item in Items)
            {
                var newItem = item.Clone();

                newItem.Source = item.Target;
                newItem.Target = item.Source;

                result.Items.Add(newItem);
            }

            return result;
        }
        public static ModelReadTemplate FromJson(string json)
        {
            var result = new ModelReadTemplate();

            result.ReadJson(json);

            return result;
            //return JsonConvert.DeserializeObject<ModelReadTemplate>(json);
        }
        public ModelReadTemplate()
        {
            Items = new JsonArrayOfObject<ModelReadTemplateItem>();
            DefaultComparison = StringComparison.CurrentCultureIgnoreCase;
            DefaultConversion = ModelReadType.SafeConvert;
        }
    }
}
