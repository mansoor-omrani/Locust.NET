using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Locust.Db.SqlServer
{
    public static class SqlParams
    {
        public static SqlParameter Output(string name, SqlDbType type, int? size = null)
        {
            var result = new SqlParameter(name, type);

            result.Direction = ParameterDirection.Output;

            if (size.HasValue)
            {
                result.Size = size.Value;
            }

            return result;
        }
        public static SqlParameter Return(string name, SqlDbType type)
        {
            var result = new SqlParameter(name, type);

            result.Direction = ParameterDirection.ReturnValue;

            return result;
        }
        public static SqlParameter InputOutput(string name, object value = null)
        {
            var result = new SqlParameter(name, value);
            
            if (value == null)
            {
                result.Value = DBNull.Value;
            }
            
            result.Direction = ParameterDirection.InputOutput;

            return result;
        }
        public static SqlParameter Input(string name, object value)
        {
            var result = new SqlParameter(name, value);

            if (value == null)
            {
                result.Value = DBNull.Value;
            }

            result.Direction = ParameterDirection.Input;

            return result;
        }
        public static SqlParameter Input(string name, SqlDbType type, object value)
        {
            var result = new SqlParameter(name, type);

            if (value == null)
            {
                result.Value = DBNull.Value;
            }
            else
            {
                result.Value = value;
            }

            result.Direction = ParameterDirection.Input;

            return result;
        }
        public static SqlParameter Input(string name, SqlDbType type, object value, int size = 0)
        {
            var result = new SqlParameter(name, type);

            if (value == null)
            {
                result.Value = DBNull.Value;
            }
            else
            {
                result.Value = value;
            }

            result.Size = size;
            result.Direction = ParameterDirection.Input;

            return result;
        }
        public static SqlParameter Structured(string name, string typename, DataTable value)
        {
            var result = new SqlParameter(name, SqlDbType.Structured);

            result.TypeName = typename;
            result.Value = value;

            return result;
        }
        public static SqlParameter Structured(string name, string typename, DbDataReader value)
        {
            var result = new SqlParameter(name, SqlDbType.Structured);

            result.TypeName = typename;
            result.Value = value;

            return result;
        }
        public static SqlParameter Udt(string name, string udtname, object value)
        {
            var result = new SqlParameter(name, SqlDbType.Udt);

            result.UdtTypeName = udtname;
            result.Value = value;

            return result;
        }
        public static SqlParameter UdtOutput(string name, string udtname)
        {
            var result = new SqlParameter(name, SqlDbType.Udt);

            result.UdtTypeName = udtname;
            result.Direction = ParameterDirection.Output;

            return result;
        }
        #region Input Helpers
        public static SqlParameter VarChar(string name, object value, int size = 0)
        {
            return Input(name, SqlDbType.VarChar, value, size);
        }
        public static SqlParameter NVarChar(string name, object value, int size = 0)
        {
            return Input(name, SqlDbType.NVarChar, value, size);
        }
        public static SqlParameter Int(string name, object value)
        {
            return Input(name, SqlDbType.Int, value);
        }
        public static SqlParameter TinyInt(string name, object value)
        {
            return Input(name, SqlDbType.TinyInt, value);
        }
        public static SqlParameter BigInt(string name, object value)
        {
            return Input(name, SqlDbType.BigInt, value);
        }
        public static SqlParameter Binary(string name, object value, int size = 0)
        {
            return Input(name, SqlDbType.Binary, value, size);
        }
        public static SqlParameter Bit(string name, object value)
        {
            return Input(name, SqlDbType.Bit, value);
        }
        public static SqlParameter Char(string name, object value, int size = 0)
        {
            return Input(name, SqlDbType.Char, value, size);
        }
        public static SqlParameter Date(string name, object value)
        {
            return Input(name, SqlDbType.Date, value);
        }
        public static SqlParameter DateTime(string name, object value)
        {
            return Input(name, SqlDbType.DateTime, value);
        }
        public static SqlParameter DateTime2(string name, object value)
        {
            return Input(name, SqlDbType.DateTime2, value);
        }
        public static SqlParameter DateTimeOffset(string name, object value)
        {
            return Input(name, SqlDbType.DateTimeOffset, value);
        }
        public static SqlParameter Decimal(string name, object value)
        {
            return Input(name, SqlDbType.Decimal, value);
        }
        public static SqlParameter Float(string name, object value)
        {
            return Input(name, SqlDbType.Float, value);
        }
        public static SqlParameter Image(string name, object value, int size = 0)
        {
            return Input(name, SqlDbType.Image, value, size);
        }
        public static SqlParameter Money(string name, object value)
        {
            return Input(name, SqlDbType.Money, value);
        }
        public static SqlParameter NChar(string name, object value, int size = 0)
        {
            return Input(name, SqlDbType.NChar, value, size);
        }
        public static SqlParameter NText(string name, object value, int size = 0)
        {
            return Input(name, SqlDbType.NText, value, size);
        }
        public static SqlParameter Real(string name, object value)
        {
            return Input(name, SqlDbType.Real, value);
        }
        public static SqlParameter SmallDateTime(string name, object value)
        {
            return Input(name, SqlDbType.SmallDateTime, value);
        }
        public static SqlParameter SmallInt(string name, object value)
        {
            return Input(name, SqlDbType.SmallInt, value);
        }
        public static SqlParameter SmallMoney(string name, object value)
        {
            return Input(name, SqlDbType.SmallMoney, value);
        }
        public static SqlParameter Text(string name, object value, int size = 0)
        {
            return Input(name, SqlDbType.Text, value, size);
        }
        public static SqlParameter Time(string name, object value)
        {
            return Input(name, SqlDbType.Time, value);
        }
        public static SqlParameter Timestamp(string name, object value)
        {
            return Input(name, SqlDbType.Timestamp, value);
        }
        public static SqlParameter UniqueIdentifier(string name, object value)
        {
            System.Guid _guid;

            if (value != null && System.Guid.TryParse(value?.ToString(), out _guid))
            {
                return Input(name, SqlDbType.UniqueIdentifier, _guid);
            }
            else
            {
                return Input(name, SqlDbType.UniqueIdentifier, DBNull.Value);
            }
        }
        public static SqlParameter Guid(string name, object value)
        {
            return UniqueIdentifier(name, value);
        }
        public static SqlParameter VarBinary(string name, object value, int size = 0)
        {
            return Input(name, SqlDbType.VarBinary, value, size);
        }
        public static SqlParameter Variant(string name, object value, int size = 0)
        {
            return Input(name, SqlDbType.Variant, value, size);
        }
        public static SqlParameter Xml(string name, object value, int size = 0)
        {
            return Input(name, SqlDbType.Xml, value, size);
        }
        #endregion
        #region Output Helpers
        public static SqlParameter VarCharOut(string name = "", int size = 0)
        {
            return Output(name, SqlDbType.VarChar, size);
        }
        public static SqlParameter NVarCharOut(string name = "", int size = 0)
        {
            return Output(name, SqlDbType.NVarChar, size);
        }
        public static SqlParameter IntOut(string name = "")
        {
            return Output(name, SqlDbType.Int);
        }
        public static SqlParameter TinyIntOut(string name = "")
        {
            return Output(name, SqlDbType.TinyInt);
        }
        public static SqlParameter BigIntOut(string name = "")
        {
            return Output(name, SqlDbType.BigInt);
        }
        public static SqlParameter BinaryOut(string name = "", int size = 0)
        {
            return Output(name, SqlDbType.Binary, size);
        }
        public static SqlParameter BitOut(string name = "")
        {
            return Output(name, SqlDbType.Bit);
        }
        public static SqlParameter CharOut(string name = "", int size = 0)
        {
            return Output(name, SqlDbType.Char, size);
        }
        public static SqlParameter DateOut(string name = "")
        {
            return Output(name, SqlDbType.Date);
        }
        public static SqlParameter DateTimeOut(string name = "")
        {
            return Output(name, SqlDbType.DateTime);
        }
        public static SqlParameter DateTime2Out(string name = "")
        {
            return Output(name, SqlDbType.DateTime2);
        }
        public static SqlParameter DateTimeOffsetOut(string name = "")
        {
            return Output(name, SqlDbType.DateTimeOffset);
        }
        public static SqlParameter DecimalOut(string name = "")
        {
            return Output(name, SqlDbType.Decimal);
        }
        public static SqlParameter FloatOut(string name = "")
        {
            return Output(name, SqlDbType.Float);
        }
        public static SqlParameter ImageOut(string name = "", int size = 0)
        {
            return Output(name, SqlDbType.Image, size);
        }
        public static SqlParameter MoneyOut(string name = "")
        {
            return Output(name, SqlDbType.Money);
        }
        public static SqlParameter NCharOut(string name = "", int size = 0)
        {
            return Output(name, SqlDbType.NChar, size);
        }
        public static SqlParameter NTextOut(string name = "", int size = 0)
        {
            return Output(name, SqlDbType.NText, size);
        }
        public static SqlParameter RealOut(string name = "")
        {
            return Output(name, SqlDbType.Real);
        }
        public static SqlParameter SmallDateTimeOut(string name = "")
        {
            return Output(name, SqlDbType.SmallDateTime);
        }
        public static SqlParameter SmallIntOut(string name = "")
        {
            return Output(name, SqlDbType.SmallInt);
        }
        public static SqlParameter SmallMoneyOut(string name = "")
        {
            return Output(name, SqlDbType.SmallMoney);
        }
        public static SqlParameter TextOut(string name = "", int size = 0)
        {
            return Output(name, SqlDbType.Text, size);
        }
        public static SqlParameter TimeOut(string name = "")
        {
            return Output(name, SqlDbType.Time);
        }
        public static SqlParameter TimestampOut(string name = "")
        {
            return Output(name, SqlDbType.Timestamp);
        }
        public static SqlParameter UniqueIdentifierOut(string name = "")
        {
            return Output(name, SqlDbType.UniqueIdentifier);
        }
        public static SqlParameter GuidOut(string name = "")
        {
            return Output(name, SqlDbType.UniqueIdentifier);
        }
        public static SqlParameter VarBinaryOut(string name = "", int size = 0)
        {
            return Output(name, SqlDbType.VarBinary, size);
        }
        public static SqlParameter VariantOut(string name = "", int size = 0)
        {
            return Output(name, SqlDbType.Variant, size);
        }
        public static SqlParameter XmlOut(string name = "", int size = 0)
        {
            return Output(name, SqlDbType.Xml, size);
        }
        #endregion
    }
    public static class SqlExtensions
    {
        public static SqlParameter AddOutput(this SqlParameterCollection spc, string name, SqlDbType type, int? size = null)
        {
            var param = SqlParams.Output(name, type, size);

            return spc.Add(param);
        }
        public static SqlParameter AddReturn(this SqlParameterCollection spc, string name, SqlDbType type)
        {
            var param = SqlParams.Return(name, type);

            return spc.Add(param);
        }
        public static SqlParameter AddInputOutput(this SqlParameterCollection spc, string name, object value)
        {
            var param = SqlParams.InputOutput(name, value);

            return spc.Add(param);
        }
        public static SqlParameter AddInput(this SqlParameterCollection spc, string name, object value)
        {
            var param = SqlParams.Input(name, value);

            return spc.Add(param);
        }
        public static SqlParameter AddStructured(this SqlParameterCollection spc, string name, string typename, DataTable value)
        {
            var param = SqlParams.Structured(name, typename, value);

            return spc.Add(param);
        }
        public static SqlParameter AddStructured(this SqlParameterCollection spc, string name, string typename, DbDataReader value)
        {
            var param = SqlParams.Structured(name, typename, value);

            return spc.Add(param);
        }
        public static SqlParameter AddUdt(this SqlParameterCollection spc, string name, string udtname, object value)
        {
            var param = SqlParams.Udt(name, udtname, value);

            return spc.Add(param);
        }
        public static SqlParameter AddUdtOutput(this SqlParameterCollection spc, string name, string udtname)
        {
            var param = SqlParams.UdtOutput(name, udtname);

            return spc.Add(param);
        }
    }
}
