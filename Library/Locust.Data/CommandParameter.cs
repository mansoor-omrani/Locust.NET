using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Locust.Data
{
    public class CommandParameter
    {
        public virtual dynamic Value { get; set; }
        public virtual ParameterDirection Direction { get; protected set; }
        public virtual SqlDbType DbType { get; set; }
        public virtual int Size { get; set; }
        public static CommandParameter Output(SqlDbType dbtype, int size = 0)
        {
            return new CommandOutputParameter(dbtype, size);
        }
        public static CommandParameter InputOutput(SqlDbType dbtype, int size = 0)
        {
            return new CommandInputOutputParameter(dbtype, size);
        }
        public static CommandParameter Guid(string guid)
        {
            return new GuidCommandParameter(guid);
        }
        public static CommandParameter Guid(System.Guid guid)
        {
            return new GuidCommandParameter(guid);
        }

        public virtual string ToJson()
        {
            var value = ((object)Value != null) ? Value.ToString() : "null";
            return string.Format("{{\"Value\": {0}, \"Direction\": {1}, \"DbType\": {2}, \"Size\": {3}}}", value, Direction.ToString(), DbType.ToString(), Size);
        }
        public override string ToString()
        {
            return (object)Value == null ? "" : Value.ToString();
        }
    }

    public class GuidCommandParameter : CommandParameter
    {
        protected dynamic _value;
        public override dynamic Value
        {
            get
            {
                return _value;
            }
            set
            {
                isValid = false;

                if (value != null)
                {
                    System.Guid _guid;
                    if (System.Guid.TryParse(value.ToString(), out _guid))
                    {
                        _value = _guid;
                        isValid = true;
                    }
                }
                else
                {
                    _value = null;
                }
            }
        }

        protected SqlDbType dbType;
        [JsonConverter(typeof(StringEnumConverter))]
        public override SqlDbType DbType
        {
            get { return dbType; }
        }
        public GuidCommandParameter(string guid)
        {
            this.Value = guid;
            dbType = SqlDbType.UniqueIdentifier;
        }
        public GuidCommandParameter(System.Guid guid)
        {
            _value = guid; //guid.ToString();
            isValid = true;
            dbType = SqlDbType.UniqueIdentifier;
        }

        private bool isValid;

        public bool IsValid
        {
            get { return isValid; }
        }

        public override string ToString()
        {
            return _value == null? "":_value.ToString();
        }
    }
}
