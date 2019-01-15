using Locust.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Data
{
    public class CommandListParameter: CommandParameter
    {
        protected SqlDbType dbType;
        [JsonConverter(typeof(StringEnumConverter))]
        public override SqlDbType DbType
        {
            get { return dbType; }
        }
        protected DataTable _value;
        public override dynamic Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (value != null)
                {
                    var dt = value as DataTable;

                    if (dt != null)
                    {
                        _value = dt;
                        return;
                    }
                    var e = value as IEnumerable;

                    if (e != null)
                    {
                        _value = e.ToDataTable();
                        return;
                    }
                }
            }
        }
        public DataTable StrongValue
        {
            get { return _value; }
        }
        public string Name { get; set; }
        public CommandListParameter()
        {
            dbType = SqlDbType.Structured;
            Direction = ParameterDirection.Input;
        }
        public CommandListParameter(string name): this()
        {
            this.Name = name;
        }
        public CommandListParameter(string name, IEnumerable value) : this()
        {
            this.Name = name;
            this.Value = value;
        }
    }
    public class CommandListParameter<T>: CommandListParameter
    {
        public CommandListParameter(string name):base(name)
        { }
        public CommandListParameter(IEnumerable<T> value)
        {
            Name = typeof(T).Name;
            _value = value?.ToDataTable();
        }
        public CommandListParameter(string name, IEnumerable<T> value) : base(name)
        {
            _value = value?.ToDataTable();
        }
    }
}
