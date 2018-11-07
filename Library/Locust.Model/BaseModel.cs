using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using Newtonsoft.Json;
using System.Xml.Serialization;
using Locust.Base;
using Locust.Extensions;
using Locust.Calendar;
using Locust.Conversion;
using Locust.BaseInfo;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Web.UI;
using Locust.Collections;
using Locust.Data;
using Locust.Json;
using Locust.ModelField;
using Locust.Serialization;
using JsonReader = Locust.Json.JsonReader;
using TypeHelper = Locust.Base.TypeHelper;
using ModelHelper = Locust.ModelField.TypeHelper;
using Locust.Formatting;

namespace Locust.Model
{
    public enum ModelSourceType
    {
        Json,
        KeyValue
    }
    public class ModelSource
    {
        public string Input { get; set; }
        public ModelSourceType Type { get; set; }
        public string Prefix { get; set; }
        public string Suffix { get; set; }
        public string Delimiter { get; set; }
        public string Separator { get; set; }
    }
    public class ModelListSource
    {
        public bool HasHeaderRow { get; set; }
        public string RowDelimiter { get; set; }
        public string ColumnDelimiter { get; set; }
    }
    public class SetPropertyArgs
    {
        public string PropertyName { get; set; }
        public object GivenValue { get; set; }
        public ModelReadType Conversion { get; set; }
        public CaseInsensitiveStringDictionary Args { get; set; }
        public bool ThrowIfMissing { get; set; }
        public bool ThrowIfNotBindable { get; set; }
        public bool IgnoreWriteOnly { get; set; }
        public bool IgnoreCase { get; set; }
        public SetPropertyArgs()
        {
            this.Args = new CaseInsensitiveStringDictionary();
        }
    }
    public class BaseModel:JsonModel
    {
        #region static methods

        protected static string[] DateTimeValues = new string[]
        {
            "gregorian", "persian", "hijri", "korean", "japanese", "taiwan", "hebrew",
            "koreanlunisolar", "japaneselunisolar", "chineselunisolar", "taiwanlunisolar"
        };

        protected static void _init_dtf_arg_property_lookup(ModelReadTemplateItem mrti, ref ChangeArgs dtf_arg_property_lookup)
        {
            if (dtf_arg_property_lookup == null)
            {
                dtf_arg_property_lookup = new ChangeArgs
                {
                    DefaultValue = "Gregorian",
                    Values = DateTimeValues
                };
                mrti.Args.Change("property", dtf_arg_property_lookup);
            }
        }
        protected static void _init_dtf_arg_result_type_lookup(ModelReadTemplateItem mrti, ref ChangeArgs dtf_arg_result_type_lookup)
        {
            if (dtf_arg_result_type_lookup == null)
            {
                dtf_arg_result_type_lookup = new ChangeArgs
                {
                    DefaultValue = "default",
                    Values = new string[] { "string", "datetime" }
                };
                mrti.Args.Change("type", dtf_arg_result_type_lookup);
            }
        }
        protected static void _init_dtf_arg_nulls_lookup(ModelReadTemplateItem mrti, ref ChangeArgs dtf_arg_nulls_lookup)
        {
            if (dtf_arg_nulls_lookup == null)
            {
                dtf_arg_nulls_lookup = new ChangeArgs
                {
                    DefaultValue = "ignore",
                    Values = new string[] { "dbnull" }
                };
                mrti.Args.Change("nulls", dtf_arg_nulls_lookup);
            }
        }
        protected static object GetDateTimeFieldProperty(object value, ModelReadTemplateItem mrti, ref ChangeArgs dtf_arg_property_lookup, ref ChangeArgs dtf_arg_result_type_lookup, ref ChangeArgs dtf_arg_nulls_lookup)
        {
            var dtf = value as DateTimeField;
            object result = null;

            if (dtf != null)
            {
                if (dtf.HasValue)
                {
                    _init_dtf_arg_property_lookup(mrti, ref dtf_arg_property_lookup);

                    var datePropertyName = dtf_arg_property_lookup.Result;

                    if (dtf_arg_property_lookup.Status == ChangeStatus.ValueNotFound)
                    {
                        throw new ApplicationException(string.Format("{0} does not have a {1} property", mrti.Source,
                            mrti.Args["property"]));
                    }

                    var dateProperty = dtf.GetType()
                        .GetProperty(datePropertyName,
                            BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                    DateTimeValue dtv;

                    if (dateProperty != null)
                    {
                        dtv = dateProperty.GetValue(dtf) as DateTimeValue;
                    }
                    else
                    {
                        throw new ApplicationException(string.Format("{0} does not have a {1} property", mrti.Source,
                            datePropertyName));
                    }

                    if (dtv != null)
                    {
                        _init_dtf_arg_result_type_lookup(mrti, ref dtf_arg_result_type_lookup);

                        var resultType = dtf_arg_result_type_lookup.Result;

                        if (string.Compare(resultType, "default", StringComparison.OrdinalIgnoreCase) == 0)
                        {
                            if (dtv is PersianDateValue)
                            {
                                resultType = "string";
                            }
                            else
                            {
                                resultType = "datetime";
                            }
                        }

                        switch (resultType)
                        {
                            case "string":
                                var format = mrti.Args.Get("format",
                                    DateTimeFormat.ShortDate.yyyyMMdd + " " + DateTimeFormat.ShortTime.HHmm);

                                result = dtv.Format(format);
                                break;
                            default:
                                result = dtv.ToDateTime();
                                break;
                        }
                    }
                    else
                    {
                        throw new ApplicationException(string.Format("{0}.{1} is not a DateTimeValue object",
                            mrti.Source, datePropertyName));
                    }
                }
                else
                {
                    _init_dtf_arg_nulls_lookup(mrti, ref dtf_arg_nulls_lookup);

                    if (string.Compare(dtf_arg_nulls_lookup.Result, "dbnull", StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        result = DBNull.Value;
                    }
                    else
                    {
                        // ignore
                    }
                }
            }

            return result;
        }

        protected static object GetBasicDataProperty(string propertyName, BasicData basicData, ModelReadTemplateItem mrti)
        {
            object result = null;

            if (basicData != null)
            {
                var lookup = new ChangeArgs
                {
                    DefaultValue = "id",
                    Values = new string[] { "id", "code", "name" }
                };

                var targetPropName = mrti.Args.Change("property", lookup);

                if (lookup.Status == ChangeStatus.ValueNotFound)
                {
                    throw new ApplicationException(string.Format("{0} does not have a {1} property", propertyName, targetPropName));
                }

                switch (targetPropName)
                {
                    case "ID":
                        result = basicData.Id;
                        break;
                    case "code":
                        result = basicData.Code;
                        break;
                    case "name":
                        result = basicData.Name;
                        break;
                }
            }

            return result;
        }
        protected static void ReadProperties(Type type, BaseModel model, Action<string, Type, object> reader, ModelReadTemplate template = null, bool nesting = false)
        {
            if (model != null)
            {
                var modelType = model.GetType();

                if (modelType != type)
                {
                    throw new ApplicationException(string.Format("Model object is not an instance of {0}", type));
                }
            }

            if (template == null)
            {
                template = ModelReadTemplate.GetDefault(type);
            }

            foreach (var mrti in template.Items)
            {
                PropertyInfo property = null;

                var flags = BindingFlags.Public | BindingFlags.Instance; ;

                if (mrti.SourceComparison.HasValue)
                {
                    if (mrti.SourceComparison.Value == StringComparison.OrdinalIgnoreCase ||
                        mrti.SourceComparison.Value == StringComparison.InvariantCultureIgnoreCase ||
                        mrti.SourceComparison.Value == StringComparison.CurrentCultureIgnoreCase)
                    {
                        flags = flags | BindingFlags.IgnoreCase;
                    }
                }

                var dotIndex = mrti.Source.IndexOf('.');

                if (dotIndex > 0 && nesting)
                {
                    var propertyName = mrti.Source.Left(dotIndex);
                    property = type.GetProperty(propertyName, flags);
                    var propertyType = property.PropertyType;

                    if (propertyType.IsBaseModel())
                    {
                        var baseModelObject = property.GetValue(model) as BaseModel;

                        if (baseModelObject != null)
                        {
                            reader(propertyName, propertyType, baseModelObject);
                        }
                    }
                }
                else
                {
                    property = type.GetProperty(mrti.Source, flags);

                    ChangeArgs dtf_arg_property_lookup = null;
                    ChangeArgs dtf_arg_result_type_lookup = null;
                    ChangeArgs dtf_arg_nulls_lookup = null;

                    if (property != null)
                    {
                        if (IsExportable(property))
                        {
                            var propertyType = property.PropertyType;
                            object value = null;

                            if (model != null)
                            {
                                if (property.PropertyType.IsDateTimeField())
                                {
                                    var dtf = property.GetValue(model);
                                    value = GetDateTimeFieldProperty(dtf, mrti, ref dtf_arg_property_lookup,
                                        ref dtf_arg_result_type_lookup, ref dtf_arg_nulls_lookup);

                                }
                                else if (property.PropertyType.IsBaseInfoType())
                                {
                                    value = GetBasicDataProperty(mrti.Source, property.GetValue(model) as BasicData,
                                        mrti);
                                }
                                else if (property.PropertyType.DescendsFrom(ModelHelper.TypeOfField))
                                {
                                    var propValue = property.GetValue(model) as Field;

                                    if (propValue != null)
                                    {
                                        var valueProp = propValue.GetType().GetProperty("Value");
                                        value = valueProp.GetValue(propValue);
                                    }
                                }
                                else
                                {
                                    value = property.GetValue(model);
                                }
                            }

                            var propName = mrti.Target;

                            if (string.IsNullOrEmpty(mrti.Target))
                            {
                                propName = mrti.Source;
                            }

                            if (propertyType.IsNullable())
                            {
                                reader(propName, Nullable.GetUnderlyingType(propertyType), value);
                            }
                            else
                            {
                                Type targetType = null;

                                if (propertyType.IsBaseInfoType())
                                {
                                    var lookup = new ChangeArgs
                                    {
                                        DefaultValue = "ID",
                                        Values = new string[] {"Name", "Code"}
                                    };
                                    var targetProp = mrti.Args.Change("property", lookup);
                                    switch (targetProp)
                                    {
                                        case "Code":
                                            targetType = TypeHelper.TypeOfString;
                                            break;
                                        case "Name":
                                            targetType = TypeHelper.TypeOfString;
                                            break;
                                        default:
                                            targetType = TypeHelper.TypeOfInt;
                                            break;
                                    }
                                }
                                else if (propertyType.IsDateTimeField())
                                {
                                    _init_dtf_arg_property_lookup(mrti, ref dtf_arg_property_lookup);

                                    var targetProp = dtf_arg_property_lookup.Result;

                                    _init_dtf_arg_result_type_lookup(mrti, ref dtf_arg_result_type_lookup);

                                    var resultType = dtf_arg_result_type_lookup.Result;

                                    if (string.Compare(resultType, "default", StringComparison.OrdinalIgnoreCase) == 0)
                                    {
                                        if (string.Compare(targetProp, "persian", StringComparison.OrdinalIgnoreCase) ==
                                            0)
                                        {
                                            resultType = "string";
                                        }
                                        else
                                        {
                                            resultType = "datetime";
                                        }
                                    }
                                    switch (resultType)
                                    {
                                        case "string":
                                            targetType = TypeHelper.TypeOfString;
                                            break;
                                        default:
                                            targetType = TypeHelper.TypeOfDateTime;
                                            break;
                                    }
                                }
                                else
                                {
                                    var isModelField = type.IsSubclassOf(ModelHelper.TypeOfField);
                                    Type[] genericArgTypes = null;

                                    if (!isModelField)
                                    {
                                        var _type = propertyType;

                                        while (_type != TypeHelper.TypeOfObject && _type != null)
                                        {
                                            if (_type.IsGenericType &&
                                                _type.GetGenericTypeDefinition() == ModelHelper.TypeOfField)
                                            {
                                                isModelField = true;
                                                genericArgTypes = _type.GetGenericArguments();
                                                break;
                                            }

                                            _type = _type.BaseType;
                                        }
                                    }

                                    if (isModelField && genericArgTypes != null && genericArgTypes.Length > 0)
                                    {
                                        targetType = genericArgTypes[0];
                                    }
                                    else
                                    {
                                        targetType = property.PropertyType;
                                    }
                                }

                                reader(propName, targetType, value);
                            }
                        }
                    }
                    else
                    {
                        throw new ApplicationException(string.Format("{0} object does not have a {1} property",
                            type.ToString(), mrti.Source));
                    }
                }
            }
        }
        public static DataTable GetDataTable<T>(ModelReadTemplate template = null)
        {
            return GetDataTable(typeof(T), template);
        }
        public static DataTable GetDataTable(Type type, ModelReadTemplate template = null)
        {
            DataTable result = new DataTable();

            ReadProperties(type, null, (name, _type, value) => result.Columns.Add(name, _type), template);
            
            return result;
        }
        protected static bool IsAllowedType(Type type)
        {
            return type.IsNullableOrBasicType() || type.IsEnum || type.IsDateTimeField() || type.IsBaseInfoType() || type.IsModelField() || type.IsCommandParameterType();
        }
        public static bool IsBindable(PropertyInfo property)
        {
            return property.CanWrite && IsAllowedType(property.PropertyType);
        }
        public static bool IsExportable(PropertyInfo property)
        {
            return property.CanRead && IsAllowedType(property.PropertyType);
        }
        #endregion static methods
        #region to methods
        public virtual string ToXml(ModelReadTemplate template = null)
        {
            var sb = new List<string>();
            var modelType = this.GetType();

            sb.Add("<" + modelType.Name + ">");

            ReadProperties(modelType, this, (name, type, value) =>
            {
                if (type.IsNumeric())
                {
                    sb.Add(string.Format("<{0}>{1}</{0}>", name, value));
                }
                else if (type == TypeHelper.TypeOfBool)
                {
                    if ((bool)value)
                    {
                        sb.Add(string.Format("<{0}>true</{0}>", name));
                    }
                    else
                    {
                        sb.Add(string.Format("<{0}>false</{0}>", name));
                    }
                }
                else if (type == typeof(BaseModel))
                {
                    sb.Add(string.Format("<{0}>{1}</{0}>", name, (value as BaseModel).ToXml()));
                }
                else
                {
                    sb.Add(string.Format("<{0}>{1}</{0}>", name, value));
                }
            }, template, true);

            sb.Add("</" + modelType + ">");

            return sb.Join("");
        }
        public virtual string ToJson(ModelReadTemplate template)
        {
            var sb = new List<string>();

            ReadProperties(this.GetType(), this, (name, type, value) =>
            {
                if (value == null)
                {
                    
                }

                if (type.IsNumeric() || type.IsNumericField())
                {
                    sb.Add(string.Format("\"{0}\":{1}", name, value));
                }
                else if (type == TypeHelper.TypeOfBool || type.DescendsFrom(ModelHelper.TypeOfTBoolean))
                {
                    if ((bool) value)
                    {
                        sb.Add(string.Format("\"{0}\":true", name));
                    }
                    else
                    {
                        sb.Add(string.Format("\"{0}\":false", name));
                    }
                }
                else if (type.IsBaseModel())
                {
                    if (value != null)
                    {
                        sb.Add(string.Format("\"{0}\":{{ {1} }}", name, (value as BaseModel).ToJson()));
                    }
                }
                else if (type.IsEnumerableBaseModel())
                {
                    sb.Add(string.Format("\"{0}\":[", name));
                    var _sb = new StringBuilder();
                    var e = value as IEnumerable;
                    foreach (var item in e)
                    {
                        var b = item as BaseModel;
                        _sb.AppendWithComma(b.ToJson());
                    }
                    sb.Add(string.Format("{0}]", _sb.ToString()));
                }
                else
                {
                    sb.Add(string.Format("\"{0}\":\"{1}\"", name, value));
                }
            }, template, true);

            return "{" + sb.Join(",") + "}";
        }
        public virtual IDictionary<string, object> ToDictionary(ModelReadTemplate template = null)
        {
            var result = new Dictionary<string, object>();

            ReadProperties(this.GetType(), this, (name, type, value) => result.Add(name, value), template);

            return result;
        }
        public virtual ModelValues ToValues(ModelReadTemplate template = null)
        {
            var result = new ModelValues();

            ReadProperties(this.GetType(), this, (name, type, value) => result.Add(name, value), template);

            return result;
        }
        public virtual DataRow ToDataRow(ModelReadTemplate template = null, DataTable dt = null)
        {
            var modelType = this.GetType();

            if (dt == null)
            {
                dt = GetDataTable(modelType);
            }

            var result = dt.NewRow();

            ReadProperties(modelType, this, (name, type, value) => result[name] = value, template);

            return result;
        }
        #endregion to methods
        protected static ForceConvert _forceConvert = new ForceConvert();
        #region JsonModel overrides
        protected override void OnBasicPropertyDetected(string propertyName, string propertyValue, JsonValueType propertyType)
        {
            SetProperty(new SetPropertyArgs
            {
                PropertyName = propertyName,
                GivenValue = propertyValue,
                Conversion = ModelReadType.SafeConvert,
                IgnoreCase = true,
                ThrowIfMissing = false,
                ThrowIfNotBindable = true,
                IgnoreWriteOnly = true
            });
        }

        protected override bool OnArrayPropertyDetected(string propertyName, JsonReader reader)
        {
            var prop = this.GetType().GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);

            if (prop != null)
            {
                var value = prop.GetValue(this);

                if (value == null)
                {
                    value = Activator.CreateInstance(prop.PropertyType);
                    prop.SetValue(this, value);
                }

                Type itemType;

                if (prop.PropertyType.TryGetItemType(out itemType))
                {
                    // currently we only support List<T>
                    // that said, we add items to the list using List<T>.Add() method

                    var list = value as IList;

                    if (list != null)
                    {
                        if (itemType.IsBasicType())
                        {
                            var x = new JsonArrayOfBasicType();
                            x.ReadJson(reader);

                            foreach (var item in x)
                            {
                                list.Add(item);
                            }

                            return true;
                        }
                        else
                        {
                            if (itemType.IsJsonModel())
                            {
                                var x = new JsonArrayOfObject(itemType);
                                x.ReadJson(reader);

                                foreach (var item in x)
                                {
                                    list.Add(item);
                                }

                                return true;
                            }
                        }
                    }
                }
            }

            return false;
        }

        #endregion
        protected void ForceSetNullableOrBasicProperty(PropertyInfo property, object propertyValue)
        {
            var propertyType = property.PropertyType;
            
            if (propertyType.IsNullable())
            {
                propertyType = Nullable.GetUnderlyingType(propertyType);
            }

            if (propertyType == TypeHelper.TypeOfByte)
                property.SetValue(this, _forceConvert.ToByte(propertyValue));
            else
                if (propertyType == TypeHelper.TypeOfSByte)
                    property.SetValue(this, _forceConvert.ToSByte(propertyValue));
                else
                    if (propertyType == TypeHelper.TypeOfShort)
                        property.SetValue(this, _forceConvert.ToInt16(propertyValue));
                    else
                        if (propertyType == TypeHelper.TypeOfInt)
                            property.SetValue(this, _forceConvert.ToInt32(propertyValue));
                        else
                            if (propertyType == TypeHelper.TypeOfLong)
                                property.SetValue(this, _forceConvert.ToInt64(propertyValue));
                            else
                                if (propertyType == TypeHelper.TypeOfUShort)
                                    property.SetValue(this, _forceConvert.ToUInt16(propertyValue));
                                else
                                    if (propertyType == TypeHelper.TypeOfUInt)
                                        property.SetValue(this, _forceConvert.ToUInt32(propertyValue));
                                    else
                                        if (propertyType == TypeHelper.TypeOfULong)
                                            property.SetValue(this, _forceConvert.ToUInt64(propertyValue));
                                        else
                                            if (propertyType == TypeHelper.TypeOfBool)
                                                property.SetValue(this, _forceConvert.ToBoolean(propertyValue));
                                            else
                                                if (propertyType == TypeHelper.TypeOfChar)
                                                    property.SetValue(this, _forceConvert.ToChar(propertyValue));
                                                else
                                                    if (propertyType == TypeHelper.TypeOfString)
                                                        property.SetValue(this, _forceConvert.ToString(propertyValue));
                                                    else
                                                        if (propertyType == TypeHelper.TypeOfDateTime)
                                                            property.SetValue(this, _forceConvert.ToDateTime(propertyValue));
                                                        else
                                                            if (propertyType == TypeHelper.TypeOfDecimal)
                                                                property.SetValue(this, _forceConvert.ToDecimal(propertyValue));
                                                            else
                                                                if (propertyType == TypeHelper.TypeOfFloat)
                                                                    property.SetValue(this, _forceConvert.ToSingle(propertyValue));
                                                                else
                                                                    if (propertyType == TypeHelper.TypeOfDouble)
                                                                        property.SetValue(this, _forceConvert.ToDouble(propertyValue));
                                                                    else
                                                                        if (propertyType == TypeHelper.TypeOfDecimal)
                                                                            property.SetValue(this, _forceConvert.ToDecimal(propertyValue));
                                                                        else
                                                                            if (propertyType == TypeHelper.TypeOfByteArray)
                                                                                property.SetValue(this, _forceConvert.ToByteArray(propertyValue));
        }
        protected void SetBasicDataProperty(BasicData basicData, object value, ModelReadType conversion, CaseInsensitiveStringDictionary args)
        {
            if (basicData != null && value != null)
            {
                var targetPropName = "ID";

                if (args.ContainsKey("property"))
                {
                    if (string.Compare(args["property"], "code", StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        targetPropName = "Code";
                    }
                    else
                    {
                        if (string.Compare(args["property"], "name", StringComparison.OrdinalIgnoreCase) == 0)
                        {
                            targetPropName = "Name";
                        }
                    }
                }
                else
                {
                    var s = value as string;

                    if (s != null)
                    {
                        if (string.IsNullOrEmpty(s) ||
                            string.Compare(s, "null", StringComparison.OrdinalIgnoreCase) == 0)
                        {
                            return;
                        }

                        if (s.IsNumeric())
                        {
                            targetPropName = "Code";
                        }
                        else
                        {
                            targetPropName = "Name";
                        }
                    }
                }

                switch (conversion)
                {
                    case ModelReadType.SafeConvert:
                        switch (targetPropName)
                        {
                            case "Code":
                                basicData.Code = _forceConvert.ToString(value);
                                break;
                            case "Name":
                                basicData.Name = value.ToString();
                                break;
                            default:
                                basicData.Id = _forceConvert.ToInt32(value);
                                break;
                        }
                        break;
                    default:
                        switch (targetPropName)
                        {
                            case "Code":
                                basicData.Code = value as string;
                                break;
                            case "Name":
                                basicData.Name = value.ToString();
                                break;
                            default:
                                basicData.Id = (int)value;
                                break;
                        }
                        break;
                }
            }
        }
        protected void SetDateTimeFieldProperty(string propertyName, DateTimeField property, object value, CaseInsensitiveStringDictionary args)
        {
            if (property != null && value != null)
            {
                DateTimeValue dtv = null; // = property.Gregorian;
                var arg = "Gregorian";

                if (args.ContainsKey("property"))
                {
                    arg = args["property"];

                    if (string.Compare(arg, "persian", StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        dtv = property.Persian;
                    }
                    else if (string.Compare(arg, "hijri", StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        dtv = property.Hijri;
                    }
                    else if (string.Compare(arg, "arabic", StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        dtv = property.Hijri;
                    }
                    else if (string.Compare(arg, "farsi", StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        dtv = property.Persian;
                    }
                    else if (string.Compare(arg, "korean", StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        dtv = property.Korean;
                    }
                    else if (string.Compare(arg, "japanese", StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        dtv = property.Japanese;
                    }
                    else if (string.Compare(arg, "taiwan", StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        dtv = property.Taiwan;
                    }
                    else if (string.Compare(arg, "hebrew", StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        dtv = property.Hebrew;
                    }
                    else if (string.Compare(arg, "koreanlunisolar", StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        dtv = property.KoreanLunisolar;
                    }
                    else if (string.Compare(arg, "japaneselunisolar", StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        dtv = property.JapaneseLunisolar;
                    }
                    else if (string.Compare(arg, "taiwanlunisolar", StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        dtv = property.TaiwanLunisolar;
                    }
                    else if (string.Compare(arg, "chineselunisolar", StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        dtv = property.ChineseLunisolar;
                    }
                }
                else
                {
                    dtv = property.Gregorian;
                }

                if (dtv != null)
                {
                    if (value is DateTime)
                    {
                        dtv.Read((DateTime)value);
                    }
                    else
                    {
                        var s = value as string;

                        if (s != null)
                        {
                            if (!string.IsNullOrEmpty(s) && string.Compare(s, "null", StringComparison.OrdinalIgnoreCase) != 0)
                            {
                                dtv.Parse(s, '/', false);
                            }
                        }
                        else
                        {
                            throw new ApplicationException(string.Format("{0} is provided with an incorrect value of type {1}", propertyName, value.GetType().ToString()));
                        }
                    }
                }
            }
        }

        protected void SetFieldProperty(object field, object propertyValue, Type propertyType, ModelReadType conversion)
        {
            var valueProp = propertyType.GetProperty("Value");
            object value = null;

            if (propertyValue == null)
            {
                return;
            }

            if (string.Compare(propertyValue.ToString(), "null", StringComparison.OrdinalIgnoreCase) == 0)
            {
                if (propertyType != ModelHelper.TypeOfTString)
                {
                    return;
                }
                else
                {
                    goto property_is_tstring;
                }
            }

            if (propertyType == ModelHelper.TypeOfTBoolean || propertyType.DescendsFrom(ModelHelper.TypeOfTBoolean))
            {
                switch (conversion)
                {
                    case ModelReadType.SafeConvert:
                        value = _forceConvert.ToBoolean(propertyValue);
                        break;
                    default:
                        value = (bool)propertyValue;
                        break;
                }
                goto set_value;
            }

            if (propertyType == ModelHelper.TypeOfTByte || propertyType.DescendsFrom(ModelHelper.TypeOfTByte))
            {
                switch (conversion)
                {
                    case ModelReadType.SafeConvert:
                        value = _forceConvert.ToByte(propertyValue);
                        break;
                    default:
                        value = (byte)propertyValue;
                        break;
                }
                goto set_value;
            }

            if (propertyType == ModelHelper.TypeOfTChar || propertyType.DescendsFrom(ModelHelper.TypeOfTChar))
            {
                switch (conversion)
                {
                    case ModelReadType.SafeConvert:
                        value = _forceConvert.ToChar(propertyValue);
                        break;
                    default:
                        value = (char)propertyValue;
                        break;
                }
                goto set_value;
            }

            if (propertyType == ModelHelper.TypeOfTDateTime || propertyType.DescendsFrom(ModelHelper.TypeOfTDateTime))
            {
                switch (conversion)
                {
                    case ModelReadType.SafeConvert:
                        value = _forceConvert.ToDateTime(propertyValue);
                        break;
                    default:
                        value = (DateTime)propertyValue;
                        break;
                }
                goto set_value;
            }

            if (propertyType == ModelHelper.TypeOfTDecimal || propertyType.DescendsFrom(ModelHelper.TypeOfTDecimal))
            {
                switch (conversion)
                {
                    case ModelReadType.SafeConvert:
                        value = _forceConvert.ToDecimal(propertyValue);
                        break;
                    default:
                        value = (decimal)propertyValue;
                        break;
                }
                goto set_value;
            }

            if (propertyType == ModelHelper.TypeOfTDouble || propertyType.DescendsFrom(ModelHelper.TypeOfTDouble))
            {
                switch (conversion)
                {
                    case ModelReadType.SafeConvert:
                        value = _forceConvert.ToDouble(propertyValue);
                        break;
                    default:
                        value = (double)propertyValue;
                        break;
                }
                goto set_value;
            }

            if (propertyType == ModelHelper.TypeOfTFloat || propertyType.DescendsFrom(ModelHelper.TypeOfTFloat))
            {
                switch (conversion)
                {
                    case ModelReadType.SafeConvert:
                        value = _forceConvert.ToSingle(propertyValue);
                        break;
                    default:
                        value = (float)propertyValue;
                        break;
                }

            }
            if (propertyType == ModelHelper.TypeOfTGuid || propertyType.DescendsFrom(ModelHelper.TypeOfTGuid))
            {
                switch (conversion)
                {
                    case ModelReadType.SafeConvert:
                        value = _forceConvert.ToGuid(propertyValue);
                        break;
                    default:
                        value = Guid.Parse(propertyValue.ToString());
                        break;
                }
                goto set_value;
            }

            if (propertyType == ModelHelper.TypeOfTInt || propertyType.DescendsFrom(ModelHelper.TypeOfTInt))
            {
                switch (conversion)
                {
                    case ModelReadType.SafeConvert:
                        value = _forceConvert.ToInt32(propertyValue);
                        break;
                    default:
                        value = (int)propertyValue;
                        break;
                }
                goto set_value;
            }

            if (propertyType == ModelHelper.TypeOfTInt16 || propertyType.DescendsFrom(ModelHelper.TypeOfTInt16))
            {
                switch (conversion)
                {
                    case ModelReadType.SafeConvert:
                        value = _forceConvert.ToInt16(propertyValue);
                        break;
                    default:
                        value = (Int16)propertyValue;
                        break;
                }
                goto set_value;
            }

            if (propertyType == ModelHelper.TypeOfTInt32 || propertyType.DescendsFrom(ModelHelper.TypeOfTInt32))
            {
                switch (conversion)
                {
                    case ModelReadType.SafeConvert:
                        value = _forceConvert.ToInt32(propertyValue);
                        break;
                    default:
                        value = (Int32)propertyValue;
                        break;
                }
                goto set_value;
            }

            if (propertyType == ModelHelper.TypeOfTInt64 || propertyType.DescendsFrom(ModelHelper.TypeOfTInt64))
            {
                switch (conversion)
                {
                    case ModelReadType.SafeConvert:
                        value = _forceConvert.ToInt64(propertyValue);
                        break;
                    default:
                        value = (Int64)propertyValue;
                        break;
                }
                goto set_value;
            }

            if (propertyType == ModelHelper.TypeOfTLong || propertyType.DescendsFrom(ModelHelper.TypeOfTLong))
            {
                switch (conversion)
                {
                    case ModelReadType.SafeConvert:
                        value = _forceConvert.ToLong(propertyValue);
                        break;
                    default:
                        value = (long)propertyValue;
                        break;
                }
                goto set_value;
            }

            if (propertyType == ModelHelper.TypeOfTSByte || propertyType.DescendsFrom(ModelHelper.TypeOfTSByte))
            {
                switch (conversion)
                {
                    case ModelReadType.SafeConvert:
                        value = _forceConvert.ToSByte(propertyValue);
                        break;
                    default:
                        value = (sbyte)propertyValue;
                        break;
                }
                goto set_value;
            }

            if (propertyType == ModelHelper.TypeOfTShort || propertyType.DescendsFrom(ModelHelper.TypeOfTShort))
            {
                switch (conversion)
                {
                    case ModelReadType.SafeConvert:
                        value = _forceConvert.ToShort(propertyValue);
                        break;
                    default:
                        value = (Int16)propertyValue;
                        break;
                }
                goto set_value;
            }

            if (propertyType == ModelHelper.TypeOfTSingle || propertyType.DescendsFrom(ModelHelper.TypeOfTSingle))
            {
                switch (conversion)
                {
                    case ModelReadType.SafeConvert:
                        value = _forceConvert.ToSingle(propertyValue);
                        break;
                    default:
                        value = (Single)propertyValue;
                        break;
                }
                goto set_value;
            }
property_is_tstring:
            if (propertyType == ModelHelper.TypeOfTString || propertyType.DescendsFrom(ModelHelper.TypeOfTString))
            {
                switch (conversion)
                {
                    case ModelReadType.SafeConvert:
                        value = _forceConvert.ToString(propertyValue);
                        break;
                    default:
                        value = (string)propertyValue;
                        break;
                }
                goto set_value;
            }

            if (propertyType == ModelHelper.TypeOfTUInt || propertyType.DescendsFrom(ModelHelper.TypeOfTUInt))
            {
                switch (conversion)
                {
                    case ModelReadType.SafeConvert:
                        value = _forceConvert.ToUInt32(propertyValue);
                        break;
                    default:
                        value = (UInt32)propertyValue;
                        break;
                }
                goto set_value;
            }

            if (propertyType == ModelHelper.TypeOfTUInt16 || propertyType.DescendsFrom(ModelHelper.TypeOfTUInt16))
            {
                switch (conversion)
                {
                    case ModelReadType.SafeConvert:
                        value = _forceConvert.ToUInt16(propertyValue);
                        break;
                    default:
                        value = (UInt16)propertyValue;
                        break;
                }
                goto set_value;
            }

            if (propertyType == ModelHelper.TypeOfTUInt32 || propertyType.DescendsFrom(ModelHelper.TypeOfTUInt32))
            {
                switch (conversion)
                {
                    case ModelReadType.SafeConvert:
                        value = _forceConvert.ToUInt32(propertyValue);
                        break;
                    default:
                        value = (UInt32)propertyValue;
                        break;
                }
                goto set_value;
            }

            if (propertyType == ModelHelper.TypeOfTUInt64 || propertyType.DescendsFrom(ModelHelper.TypeOfTUInt64))
            {
                switch (conversion)
                {
                    case ModelReadType.SafeConvert:
                        value = _forceConvert.ToUInt64(propertyValue);
                        break;
                    default:
                        value = (UInt64)propertyValue;
                        break;
                }
                goto set_value;
            }

            if (propertyType == ModelHelper.TypeOfTULong || propertyType.DescendsFrom(ModelHelper.TypeOfTULong))
            {
                switch (conversion)
                {
                    case ModelReadType.SafeConvert:
                        value = _forceConvert.ToUInt64(propertyValue);
                        break;
                    default:
                        value = (UInt64)propertyValue;
                        break;
                }
                goto set_value;
            }
set_value:
            valueProp.SetValue(field, value);
        }
        protected virtual void SetProperty(SetPropertyArgs args)
        {
            var flags = BindingFlags.Instance | BindingFlags.Public;

            if (args.IgnoreCase)
            {
                flags |= BindingFlags.IgnoreCase;
            }

            var dotIndex = args.PropertyName.IndexOf('.');

            if (dotIndex > 0)
            {
                var propertyName = args.PropertyName.Left(dotIndex);
                var property = this.GetType().GetProperty(propertyName, flags);
                var propertyType = property.PropertyType;

                if (propertyType.IsBaseModel())
                {
                    var baseModelObject = property.GetValue(this) as BaseModel;

                    if (baseModelObject != null)
                    {
                        var spa = new SetPropertyArgs
                        {
                            PropertyName = args.PropertyName.Right(args.PropertyName.Length - dotIndex - 1),
                            GivenValue = args.GivenValue,
                            Conversion = args.Conversion,
                            IgnoreCase = args.IgnoreCase,
                            ThrowIfMissing = args.ThrowIfMissing,
                            ThrowIfNotBindable = args.ThrowIfNotBindable,
                            IgnoreWriteOnly = args.IgnoreWriteOnly,
                            Args = args.Args
                        };

                        baseModelObject.SetProperty(spa);
                    }
                }
            }
            else
            {
                var property = this.GetType().GetProperty(args.PropertyName, flags);

                if (property != null)
                {
                    var propertyType = property.PropertyType;

                    if (BaseModel.IsBindable(property))
                    {
                        // note:
                        // it is important to check for enums at first
                        // because IsNullableOrBasicType() already returns true
                        // both for enums and Nullable and Basic Types
                        // so, the specific logic for handling enum properties
                        // will not be imposed if checking for enums is performed
                        // after IsNullableOrBasicType()

                        if (propertyType.IsEnum)
                        {
                            object x = null;

                            if (!DBNull.Value.Equals(args.GivenValue))
                            {
                                if (!Enum.IsDefined(propertyType, args.GivenValue) && args.Args.ContainsKey("default"))
                                {
                                    x = Enum.Parse(propertyType, args.Args["default"]);
                                }
                                else
                                {
                                    x = args.GivenValue;
                                }
                            }
                            else
                            {
                                if (args.Args.ContainsKey("default"))
                                {
                                    x = Enum.Parse(propertyType, args.Args["default"]);
                                }
                            }

                            if (x != null)
                            {
                                property.SetValue(this, x);
                            }
                        }
                        else if (propertyType.IsNullableOrBasicType())
                        {
                            switch (args.Conversion)
                            {
                                case ModelReadType.SafeConvert:
                                    ForceSetNullableOrBasicProperty(property, args.GivenValue);
                                    break;
                                default:
                                    property.SetValue(this, args.GivenValue);
                                    break;
                            }
                        }
                        else if (propertyType.DescendsFrom(ModelHelper.TypeOfField))
                        {
                            var field = property.GetValue(this);

                            if (field == null)
                            {
                                field = Activator.CreateInstance(propertyType);
                                property.SetValue(this, field);
                            }

                            if (field != null)
                            {
                                SetFieldProperty(field, args.GivenValue, propertyType, args.Conversion);
                            }
                        }
                        else if (propertyType.IsDateTimeField())
                        {
                            if (!DBNull.Value.Equals(args.GivenValue))
                            {
                                var dtf = property.GetValue(this);

                                if (dtf == null)
                                {
                                    dtf = Activator.CreateInstance(propertyType);
                                    property.SetValue(this, dtf);
                                }

                                SetDateTimeFieldProperty(args.PropertyName, dtf as DateTimeField, args.GivenValue, args.Args);
                            }
                        }
                        else if (propertyType.IsBaseInfoType())
                        {
                            if (!DBNull.Value.Equals(args.GivenValue))
                            {
                                var basicData = property.GetValue(this);

                                if (basicData == null)
                                {
                                    basicData = Activator.CreateInstance(propertyType);
                                    property.SetValue(this, basicData);
                                }

                                SetBasicDataProperty(basicData as BasicData, args.GivenValue, args.Conversion, args.Args);
                            }
                        }
                        else if (propertyType.IsCommandParameterType())
                        {
                            var propertyValue = property.GetValue(this);
                            var cmd = propertyValue as CommandParameter;
                            if (cmd != null)
                            {
                                cmd.Value = args.GivenValue;
                            }
                        }
                    }
                    else
                    {
                        if (args.ThrowIfNotBindable && !args.IgnoreWriteOnly)
                        {
                            throw new ApplicationException(string.Format("property {0} is not bindable",
                                args.PropertyName));
                        }
                    }
                }
                else
                {
                    if (args.ThrowIfMissing)
                    {
                        throw new ApplicationException(string.Format("{0} object does not have a {1} property",
                            this.GetType().ToString(), args.PropertyName));
                    }
                }
            }
        }
        public virtual void Read(ModelValues values, ModelReadTemplate template = null)
        {
            if (values == null)
            {
                return;
            }

            if (template == null)
            {
                template = ModelReadTemplate.GetDefault(this.GetType()); 
            }

            foreach (var mrti in template.Items.OrderBy(item => item.Target))
            {
                if (!mrti.Ignore) 
                {
                    var source = mrti.Source;

                    if (string.IsNullOrEmpty(source))
                    {
                        source = mrti.Target;
                    }

                    var comparison = template.DefaultComparison;

                    if (mrti.SourceComparison.HasValue)
                    {
                        comparison = mrti.SourceComparison.Value;
                    }

                    var conversion = template.DefaultConversion;

                    if (mrti.Conversion.HasValue)
                    {
                        conversion = mrti.Conversion.Value;
                    }

                    var found = false;

                    object givenValueForProperty = null;

                    if (comparison == StringComparison.OrdinalIgnoreCase)
                    {
                        if (values.ContainsKey(source))
                        {
                            givenValueForProperty = values[source];

                            found = true;
                        }
                    }
                    else
                    {
                        foreach (var item in values)
                        {
                            if (string.Compare(item.Key, source, comparison) == 0)
                            {
                                givenValueForProperty = item.Value;

                                found = true;

                                break;
                            }
                        }
                    }

                    if (!found && mrti.DefaultValue != null)
                    {
                        givenValueForProperty = mrti.DefaultValue;

                        found = true;
                    }

                    if (found)
                    {
                        var targetIgnoreCase = true;

                        if (mrti.TargetIgnoreCase.HasValue)
                        {
                            targetIgnoreCase = mrti.TargetIgnoreCase.Value;
                        }

                        var spa = new SetPropertyArgs
                        {
                            PropertyName = mrti.Target,
                            GivenValue = givenValueForProperty,
                            Conversion = conversion,
                            ThrowIfMissing = mrti.ThrowOnMissingProperty,
                            ThrowIfNotBindable = mrti.ThrowIfNotBindable,
                            IgnoreWriteOnly = mrti.IgnoreWriteOnly,
                            IgnoreCase = targetIgnoreCase
                        };

                        foreach (var a in mrti.Args)
                        {
                            spa.Args.Add(a);
                        }

                        SetProperty(spa);
                    }
                    else
                    {
                        if (mrti.ThrowOnMissingValue)
                        {
                            throw new ApplicationException("Missing value for " + mrti.Target);
                        }
                    }
                }
            }
        }
        #region Read() utility methods

        public void Read(string input)
        {
            throw new NotImplementedException();
        }
        public virtual void Read(IDataRecord record, ModelReadTemplate template = null)
        {
            Read(record.Values(), template);
        }
        public virtual void Read(IDataRecord record, string jsonTemplate)
        {
            Read(record.Values(), jsonTemplate);
        }
        public virtual void Read(DataRow row, ModelReadTemplate template = null)
        {
            Read(row.Values(), template);
        }
        public virtual void Read(DataRow record, string jsonTemplate)
        {
            Read(record.Values(), jsonTemplate);
        }
        public virtual void Read(HttpRequest request, RequestValues source = RequestValues.All, ModelReadTemplate template = null)
        {
            Read(request.Values(source), template);
        }
        public virtual void Read(HttpRequest request, RequestValues source, string jsonTemplate)
        {
            Read(request.Values(), jsonTemplate);
        }

        public virtual void Read(HttpRequestBase request, RequestValues source = RequestValues.All, ModelReadTemplate template = null)
        {
            Read(request.Values(source), template);
        }
        public virtual void Read(HttpRequestBase request, RequestValues source, string jsonTemplate)
        {
            Read(request.Values(), jsonTemplate);
        }
        public virtual void Read(IDbCommand cmd, ModelReadTemplate template = null)
        {
            Read(cmd.Values(), template);
        }
        public virtual void Read(IDbCommand cmd, string jsonTemplate)
        {
            Read(cmd.Values(), jsonTemplate);
        }
        public virtual void Read(IDictionary<string, object> dictionary, ModelReadTemplate template = null)
        {
            Read(dictionary.ModelValues(), template);
        }
        public virtual void Read(IDictionary<string, object> dictionary, string jsonTemplate)
        {
            Read(dictionary.ModelValues(), jsonTemplate);
        }
        public virtual void Read(BaseModel model, ModelReadTemplate template = null)
        {
            Read(model.ToValues(), template);
        }
        public virtual void Read(BaseModel model, string jsonTemplate)
        {
            Read(model.ToValues(), jsonTemplate);
        }
        public virtual void Read(ModelValues values, string jsonTemplate)
        {
            var template = ModelReadTemplate.FromJson(jsonTemplate);

            Read(values, template);
        }
        #endregion Read() utility methods

        protected KeyValuePair<string, object> AddProperty(string propertyName)
        {
            var prop = this.GetType().GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);

            if (prop != null)
            {
                if (prop.PropertyType.IsDateTimeField())
                {
                    var dtf = prop.GetValue(this) as DateTimeField;
                    var dc = prop.GetCustomAttributes(true).FirstOrDefault(attr => attr.GetType() == Calendar.TypeHelper.TypeOfDefaultCalendarAttribute) as DefaultCalendarAttribute;
                    
                    if (dc != null)
                    {
                        switch (dc.Value)
                        {
                            case Calendars.Gregorian:
                                return AddProperty(prop.Name, (dtf.HasValue) ? dtf.Gregorian.ToString() : "null");
                            case Calendars.Persian:
                                return AddProperty(prop.Name, (dtf.HasValue) ? dtf.Persian.ToString() : "null");
                            case Calendars.Hebrew:
                                return AddProperty(prop.Name, (dtf.HasValue) ? dtf.Hebrew.ToString() : "null");
                            case Calendars.Hijri:
                                return AddProperty(prop.Name, (dtf.HasValue) ? dtf.Hijri.ToString() : "null");
                            case Calendars.Julian:
                                return AddProperty(prop.Name, (dtf.HasValue) ? dtf.Julian.ToString() : "null");
                            case Calendars.Japanese:
                                return AddProperty(prop.Name, (dtf.HasValue) ? dtf.Japanese.ToString() : "null");
                            case Calendars.Korean:
                                return AddProperty(prop.Name, (dtf.HasValue) ? dtf.Korean.ToString() : "null");
                            case Calendars.Taiwan:
                                return AddProperty(prop.Name, (dtf.HasValue) ? dtf.Taiwan.ToString() : "null");
                            case Calendars.KoreanLunisolar:
                                return AddProperty(prop.Name, (dtf.HasValue) ? dtf.KoreanLunisolar.ToString() : "null");
                            case Calendars.TaiwanLunisolar:
                                return AddProperty(prop.Name, (dtf.HasValue) ? dtf.TaiwanLunisolar.ToString() : "null");
                            case Calendars.JapaneseLunisolar:
                                return AddProperty(prop.Name, (dtf.HasValue) ? dtf.JapaneseLunisolar.ToString() : "null");
                            case Calendars.ChineseLunisolar:
                                return AddProperty(prop.Name, (dtf.HasValue) ? dtf.ChineseLunisolar.ToString() : "null");
                        }
                    }

                    return AddProperty(prop.Name, (dtf.HasValue) ? dtf.Gregorian.ToString() : "null");
                }

                if (prop.PropertyType.IsModelField())
                {
                    var fo = prop.GetValue(this);
                    if (fo != null)
                    {
                        var valueProp = fo.GetType().GetProperty("Value", BindingFlags.Public | BindingFlags.Instance);
                        if (valueProp != null)
                        {
                            return AddProperty(prop.Name, valueProp.GetValue(fo));
                        }
                    }
                }

                return AddProperty(prop.Name, prop.GetValue(this));
            }

            return new KeyValuePair<string, object>("", null);
        }
    }
}
