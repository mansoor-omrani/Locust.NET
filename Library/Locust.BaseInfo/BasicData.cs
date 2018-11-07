using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Base;
using Locust.Caching;
using Locust.Db;
using Locust.Extensions;
using Locust.Serialization;

namespace Locust.BaseInfo
{
    public class BasicData:IJsonSerializable
    {
        public virtual string Category { get; set; }
        public virtual string Name { get; set; }
        public virtual int Id { get; set; }
        public virtual int Parent { get; set; }
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
        public virtual string Code { get; set; }
        public virtual string ToJson(JsonSerializationOptions options = null)
        {
            var _options = new JsonSerializationOptions(options);
            var indent = _options.CurrentIndent + _options.Indent;
            var crlf = Environment.NewLine;
            var currentIndent = _options.CurrentIndent;

            if (!_options.UseIndentation)
            {
                indent = "";
                currentIndent = "";
                crlf = "";
            }
            var sb = new StringBuilder();

            sb.AppendFormat("\"Category\":\"{0}\"", Category);
            sb.AppendFormatWithComma("\"Name\":\"{0}\"", Name);
            sb.AppendFormatWithComma("\"Id\":{0}", Id);
            sb.AppendFormatWithCommaIfNotEmpty("\"Title\":\"{0}\"", Title);
            sb.AppendFormatWithCommaIfNotEmpty("\"Description\":\"{0}\"", Description);
            sb.AppendFormatWithCommaIfNotEmpty("\"Code\":\"{0}\"", Code);
            sb.AppendFormatWithCommaIf("\"Parent\":\"{0}\"", Parent != 0, Parent);

            return "{" + sb + "}";
        }
    }
    public sealed class BasicData<T> : BasicData where T : struct
    {
        private T _value;
        private BasicData _data;
        
        public BasicData()
        {
            _data = new BasicData();
        }
        public override string Category
        {
            get { return typeof(T).Name; }
        }
        public override string Name
        {
            set
            {
                _data = BaseInfo.DefaultProvider.GetByName(Category, value);
                _value = _data.Id.ToEnum<T>();

                //if (_data.Id != value)
                //{
                //    _data = BaseInfo.DefaultProvider.GetByCode(Category, (Convert.ChangeType(_value, TypeHelper.TypeOfInt)).ToString());
                //}
                //_value = BaseInfo.DefaultProvider.ToEnumByID<T>(_data.ID);
            }
            get { return _data.Name; }
        }

        public override int Id
        {
            set
            {
                _data = BaseInfo.DefaultProvider.GetById(Category, value);
                _value = value.ToEnum<T>();

                if (_data.Id != value)
                {
                    _data = BaseInfo.DefaultProvider.GetByCode(Category, ( Convert.ChangeType(_value, TypeHelper.TypeOfInt)).ToString());
                }
                //_value = BaseInfo.DefaultProvider.ToEnumByID<T>(_data.ID);
            }
            get { return _data.Id; }
        }

        public override string Title
        {
            get { return _data.Title; }
        }
        public override string Description
        {
            get { return _data.Description; }
        }
        public override string Code
        {
            set
            {
                _data = BaseInfo.DefaultProvider.GetByCode(Category, value);
                _value = _data.Id.ToEnum<T>();

                if (_data.Code != value)
                {
                    _data = BaseInfo.DefaultProvider.GetByCode(Category, _value.ToString());
                }
                //_value = BaseInfo.DefaultProvider.ToEnumByID<T>(_data.ID);
            }
            get { return _data.Code; }
        }
        public T Value
        {
            get { return _value; }
        }
        public override string ToJson(JsonSerializationOptions options = null)
        {
            var sb = new StringBuilder();

            sb.AppendFormat("\"Category\":\"{0}\"", Category);
            sb.AppendFormatWithComma("\"Name\":\"{0}\"", Name);
            sb.AppendFormatWithComma("\"Id\":{0}", Id);
            sb.AppendFormatWithComma("\"Value\":\"{0}\"", Value);
            sb.AppendFormatWithCommaIfNotEmpty("\"Title\":\"{0}\"", Title);
            sb.AppendFormatWithCommaIfNotEmpty("\"Description\":\"{0}\"", Description);
            sb.AppendFormatWithCommaIfNotEmpty("\"Code\":\"{0}\"", Code);
            sb.AppendFormatWithCommaIf("\"Parent\":\"{0}\"", Parent != 0, Parent);

            return "{" + sb + "}";
        }
    }
}
