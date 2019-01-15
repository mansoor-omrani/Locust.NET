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
        public static CommandListParameter List<T>(IEnumerable<T> value)
        {
            return new CommandListParameter<T>(value);
        }
        public static CommandListParameter List<T>(string name, IEnumerable<T> value)
        {
            return new CommandListParameter<T>(name, value);
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
}
