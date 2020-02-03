using Locust.Base;
using Locust.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Db
{
    public class CommandParameter
    {
        public string Name { get; set; }
        private object _value;
        public string ListSeparator { get; set; }
        public object Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (value == null ||  DBNull.Value.Equals(value))
                {
                    _value = DBNull.Value;
                }
                else
                {
                    var valueType = value.GetType();

                    if (valueType.IsEnumerable() && valueType != TypeHelper.TypeOfString)
                    {
                        var e = value as System.Collections.IEnumerable;

                        if (e != null)
                        {
                            var sb = new StringBuilder();

                            foreach (var x in e)
                            {
                                sb.Append((sb.Length == 0 ? "" : ListSeparator) + x.ToString());
                            }

                            _value = sb.ToString();
                        }
                        else
                        {
                            _value = value.ToString();
                        }
                    }
                    else
                    {
                        _value = value;
                    }
                }
            }
        }
        public string TypeProp { get; set; }
        public dynamic Type { get; set; }
        public byte? Scale { get; set; }
        public byte? Precision { get; set; }
        public ParameterDirection Direction { get; set; }
        public int? Size { get; set; }
        public CommandParameter()
        {
            ListSeparator = ",";
        }
        public static CommandParameter Output(dynamic type, int? size = null)
        {
            return new CommandParameter { Type = type, Size = size, Direction = ParameterDirection.Output };
        }
        public static CommandParameter Output(string name, dynamic type, int? size = null)
        {
            return new CommandParameter { Name = name, Type = type, Size = size, Direction = ParameterDirection.Output };
        }
        public static CommandParameter Output(dynamic type, string typeProp, int? size = null)
        {
            return new CommandParameter { Type = type, TypeProp = typeProp, Size = size, Direction = ParameterDirection.Output };
        }
        public static CommandParameter Output(string name, string typeProp, dynamic type, int? size = null)
        {
            return new CommandParameter { Name = name, TypeProp = typeProp, Type = type, Size = size, Direction = ParameterDirection.Output };
        }
        public override string ToString()
        {
            return Value == null || DBNull.Value.Equals(Value) ? "" : Value.ToString();
        }
    }
}
