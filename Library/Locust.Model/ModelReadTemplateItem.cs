using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Base;
using Locust.Collections;
using Locust.Conversion;
using Locust.Extensions;
using Locust.Json;

namespace Locust.Model
{
    public enum ModelReadType
    {
        Default,
        SafeConvert
    }
    public class ModelReadTemplateItem : JsonModel
    {
        public string Source { get; set; }
        public string Target { get; set; }
        public string DefaultValue { get; set; }
        public ModelReadType? Conversion { get; set; }
        public ModelTemplateItemArgs Args { get; set; }
        public bool Ignore { get; set; }
        public bool ThrowOnMissingProperty { get; set; }
        public bool ThrowIfNotBindable { get; set; }
        public bool ThrowOnMissingValue { get; set; }
        public bool IgnoreWriteOnly { get; set; }
        public StringComparison? SourceComparison { get; set; }
        public bool? TargetIgnoreCase { get; set; }
        public ModelReadTemplateItem Clone()
        {
            var result = new ModelReadTemplateItem
            {
                Source = this.Source,
                Target = this.Target,
                DefaultValue = this.DefaultValue,
                Conversion = this.Conversion,
                Ignore = this.Ignore,
                ThrowOnMissingProperty = this.ThrowOnMissingProperty,
                ThrowOnMissingValue = this.ThrowOnMissingValue,
                ThrowIfNotBindable = this.ThrowIfNotBindable,
                SourceComparison = this.SourceComparison,
                TargetIgnoreCase = this.TargetIgnoreCase
            };

            foreach (var item in this.Args)
            {
                result.Args.Add(item.Key, item.Value);
            }

            return result;
        }

        public ModelReadTemplateItem()
        {
            this.Args = new ModelTemplateItemArgs(caseInsensitiveKeys: true);
            this.DefaultValue = null;
        }

        protected override void OnBasicPropertyDetected(string propertyName, string propertyValue, JsonValueType itemType)
        {
            var isNumeric = !string.IsNullOrEmpty(propertyValue) && propertyValue.GetType().IsNumeric();

            switch (propertyName[0])
            {
                case 's':
                    if (propertyName.Length == 6)
                    {
                        Source = propertyValue;
                    }
                    else
                    {
                        if (isNumeric)
                        {
                            SourceComparison = SafeClrConvert.ToInt32(propertyValue).ToEnum<StringComparison>();
                        }
                        else
                        {
                            StringComparison x;

                            if (Enum.TryParse(propertyValue, out x))
                            {
                                SourceComparison = x;
                            }
                        }
                    }
                    break;
                case 't':
                    if (propertyName.Length > 1)
                    {
                        switch (propertyName[1])
                        {
                            case 'a':
                                if (propertyName.Length == 6)
                                {
                                    Target = propertyValue;
                                }
                                else
                                {
                                    TargetIgnoreCase = SafeClrConvert.ToBoolean(propertyValue);
                                }
                                break;
                            case 'h':
                                switch (propertyName.Length)
                                {
                                    case 22:
                                        ThrowOnMissingProperty = SafeClrConvert.ToBoolean(propertyValue);
                                        break;
                                    case 18:
                                        ThrowIfNotBindable = SafeClrConvert.ToBoolean(propertyValue);
                                        break;
                                    case 19:
                                        ThrowOnMissingValue = SafeClrConvert.ToBoolean(propertyValue);
                                        break;
                                }
                                break;
                        }
                    }
                    else
                    {
                        Target = propertyValue;
                    }
                    break;
                case 'd':
                    DefaultValue = propertyValue;
                    break;
                case 'c':
                    if (isNumeric)
                    {
                        Conversion = SafeClrConvert.ToInt32(propertyValue).ToEnum<ModelReadType>();
                    }
                    else
                    {
                        ModelReadType x;
                        if (Enum.TryParse<ModelReadType>(propertyValue, out x))
                        {
                            Conversion = x;
                        }
                    }
                    break;
                case 'i':
                    Ignore = SafeClrConvert.ToBoolean(propertyValue);
                    break;
                case 'a':
                    break;
            }
        }

        protected override bool OnObjectPropertyDetected(string propertyName, JsonReader reader)
        {
            Args.ReadJson(reader);

            return true;
        }
    }


    public class ModelTemplateItemArgs : JsonDictionary
    {
        public ModelTemplateItemArgs() : base() { }

        public ModelTemplateItemArgs(bool caseInsensitiveKeys) : base(caseInsensitiveKeys)
        { }

        public string Get(string key, string defaultValue = null)
        {
            var result = defaultValue;

            if (dictionary.ContainsKey(key))
            {
                result = dictionary[key];

                if (string.IsNullOrEmpty(result) || string.IsNullOrWhiteSpace(result))
                {
                    result = defaultValue;
                }
            }

            return result;
        }

        public string Change(string key, ChangeArgs lookup)
        {
            var result = lookup.DefaultValue;
            var keyNotFound = true;
            var valueNotFound = true;

            if (dictionary.ContainsKey(key))
            {
                keyNotFound = false;
                result = dictionary[key];

                if (lookup.Values != null)
                {
                    foreach (var value in lookup.Values)
                    {
                        if (string.Compare(result, value, lookup.ValueComparison) == 0)
                        {
                            valueNotFound = false;
                            result = value;
                            break;
                        }
                    }

                    if (valueNotFound)
                    {
                        result = lookup.DefaultValue;
                    }
                }

                if (string.IsNullOrEmpty(result) || string.IsNullOrWhiteSpace(result))
                {
                    result = lookup.DefaultValue;
                }
            }

            if (lookup.AllowReplace)
            {
                if (keyNotFound)
                {
                    dictionary.Add(key, result);
                }
                else
                {
                    if (valueNotFound)
                    {
                        dictionary[key] = result;
                    }
                }
            }

            if (keyNotFound)
            {
                if (lookup.AllowReplace)
                {
                    lookup.Status = ChangeStatus.Added;
                }
                else
                {
                    lookup.Status = ChangeStatus.KeyNotFound;
                }
            }
            else
            {
                if (lookup.AllowReplace)
                {
                    if (valueNotFound)
                    {
                        lookup.Status = ChangeStatus.Updated;
                    }
                    else
                    {
                        lookup.Status = ChangeStatus.NotChange;
                    }
                }
                else
                {
                    if (valueNotFound)
                    {
                        lookup.Status = ChangeStatus.ValueNotFound;
                    }
                    else
                    {
                        lookup.Status = ChangeStatus.NotChange;
                    }
                }
            }

            lookup.Result = result;

            return result;
        }
    }

}
