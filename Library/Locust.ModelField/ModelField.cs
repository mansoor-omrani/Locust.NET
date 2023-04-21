
using System;
using System.ComponentModel;

namespace Locust.ModelField
{
	public abstract class Field: IComparable
	{
		//public object Value { get; set; }
		public abstract int CompareTo(object x);
	}
    [DefaultProperty("Value")]
    public class Field<T>: Field where T: IComparable
    {
        public T Value { get; set; }
        public static implicit operator Field<T>(T t)
        {
            return new Field<T>(t);
        }
        public static implicit operator T(Field<T> f)
        {
			if (f == null)
				return default(T);
            return f.Value;
        }
        public Field()
        { }
        public Field(T x)
        {
			Value = x;
		}
		public override int CompareTo(object x)
		{
			if (Value == null && x == null)
				return 0;
			if (Value == null)
				return -1;
			if (x == null)
				return 1;
			return Value.CompareTo(x);
		}
		public override int GetHashCode()
        {
			if (Value == null)
				return 0;
            return Value.GetHashCode();
        }
        public override bool Equals(object x)
        {
			if (Value == null && x == null)
				return true;
			if (Value == null || x == null)
				return false;
			return Value.Equals(x);
        }
		public override string ToString()
        {
			if (Value == null)
				return null;
            return Value.ToString();
        }
    }
    public partial class TByte: Field<System.Byte>
    {
		public TByte()
            : base()
        { }
        public TByte(System.Byte x)
            : base(x)
        { }
        public static implicit operator TByte(System.Byte t)
        {
            return new TByte(t);
        }
        public static implicit operator System.Byte(TByte f)
        {
			if ((object)f == null)
				return default(System.Byte);
			else
				return f.Value;
        }
		public override int CompareTo(object x)
		{
						return Value.CompareTo(x);
					}
		public override int GetHashCode()
        {
						return Value.GetHashCode();
			        }
        public override bool Equals(object x)
        {
					return Value.Equals(x);
		        }
		public bool Equals(TByte x)
        {
            if ((object)x == null)
                return false;
            return Value == x.Value;
        }
		public bool Equals(System.Byte x)
        {
							return Value == x;
			        }
		public override string ToString()
        {
					return Value.ToString();
		        }
				//------------------ Equality (TByte, TByte) --------------
        public static bool operator ==(TByte x, TByte y)
        {
            if ((object)x == null && (object)y == null)
                return true;
            if ((object)x == null)
                return false;
            return x.Equals(y);
        }
        public static bool operator !=(TByte x, TByte y)
        {
            if ((object)x == null && (object)y == null)
                return false;
            if ((object)x == null)
                return true;
            return !x.Equals(y);
        }
        //------------------ Equality (TByte, System.Byte) --------------
		/*
        public static bool operator ==(TByte x, System.Byte y)
        {
            if ((object)x == null)
                return false;
            return x.Equals(y);
        }
        public static bool operator !=(TByte x, System.Byte y)
        {
            if ((object)x == null)
                return true;
            return !x.Equals(y);
        }
		*/
        //------------------ Equality (System.Byte, TByte) --------------
		/*
        public static bool operator ==(System.Byte x, TByte y)
        {
            if ((object)y == null)
                return false;
            return y.Equals(x);
        }
        public static bool operator !=(System.Byte x, TByte y)
        {
            if ((object)y == null)
                return true;
            return !y.Equals(x);
        }
		*/
        		
		    }
    public partial class TSByte: Field<System.SByte>
    {
		public TSByte()
            : base()
        { }
        public TSByte(System.SByte x)
            : base(x)
        { }
        public static implicit operator TSByte(System.SByte t)
        {
            return new TSByte(t);
        }
        public static implicit operator System.SByte(TSByte f)
        {
			if ((object)f == null)
				return default(System.SByte);
			else
				return f.Value;
        }
		public override int CompareTo(object x)
		{
						return Value.CompareTo(x);
					}
		public override int GetHashCode()
        {
						return Value.GetHashCode();
			        }
        public override bool Equals(object x)
        {
					return Value.Equals(x);
		        }
		public bool Equals(TSByte x)
        {
            if ((object)x == null)
                return false;
            return Value == x.Value;
        }
		public bool Equals(System.SByte x)
        {
							return Value == x;
			        }
		public override string ToString()
        {
					return Value.ToString();
		        }
				//------------------ Equality (TSByte, TSByte) --------------
        public static bool operator ==(TSByte x, TSByte y)
        {
            if ((object)x == null && (object)y == null)
                return true;
            if ((object)x == null)
                return false;
            return x.Equals(y);
        }
        public static bool operator !=(TSByte x, TSByte y)
        {
            if ((object)x == null && (object)y == null)
                return false;
            if ((object)x == null)
                return true;
            return !x.Equals(y);
        }
        //------------------ Equality (TSByte, System.SByte) --------------
		/*
        public static bool operator ==(TSByte x, System.SByte y)
        {
            if ((object)x == null)
                return false;
            return x.Equals(y);
        }
        public static bool operator !=(TSByte x, System.SByte y)
        {
            if ((object)x == null)
                return true;
            return !x.Equals(y);
        }
		*/
        //------------------ Equality (System.SByte, TSByte) --------------
		/*
        public static bool operator ==(System.SByte x, TSByte y)
        {
            if ((object)y == null)
                return false;
            return y.Equals(x);
        }
        public static bool operator !=(System.SByte x, TSByte y)
        {
            if ((object)y == null)
                return true;
            return !y.Equals(x);
        }
		*/
        		
		    }
    public partial class TInt16: Field<System.Int16>
    {
		public TInt16()
            : base()
        { }
        public TInt16(System.Int16 x)
            : base(x)
        { }
        public static implicit operator TInt16(System.Int16 t)
        {
            return new TInt16(t);
        }
        public static implicit operator System.Int16(TInt16 f)
        {
			if ((object)f == null)
				return default(System.Int16);
			else
				return f.Value;
        }
		public override int CompareTo(object x)
		{
						return Value.CompareTo(x);
					}
		public override int GetHashCode()
        {
						return Value.GetHashCode();
			        }
        public override bool Equals(object x)
        {
					return Value.Equals(x);
		        }
		public bool Equals(TInt16 x)
        {
            if ((object)x == null)
                return false;
            return Value == x.Value;
        }
		public bool Equals(System.Int16 x)
        {
							return Value == x;
			        }
		public override string ToString()
        {
					return Value.ToString();
		        }
				//------------------ Equality (TInt16, TInt16) --------------
        public static bool operator ==(TInt16 x, TInt16 y)
        {
            if ((object)x == null && (object)y == null)
                return true;
            if ((object)x == null)
                return false;
            return x.Equals(y);
        }
        public static bool operator !=(TInt16 x, TInt16 y)
        {
            if ((object)x == null && (object)y == null)
                return false;
            if ((object)x == null)
                return true;
            return !x.Equals(y);
        }
        //------------------ Equality (TInt16, System.Int16) --------------
		/*
        public static bool operator ==(TInt16 x, System.Int16 y)
        {
            if ((object)x == null)
                return false;
            return x.Equals(y);
        }
        public static bool operator !=(TInt16 x, System.Int16 y)
        {
            if ((object)x == null)
                return true;
            return !x.Equals(y);
        }
		*/
        //------------------ Equality (System.Int16, TInt16) --------------
		/*
        public static bool operator ==(System.Int16 x, TInt16 y)
        {
            if ((object)y == null)
                return false;
            return y.Equals(x);
        }
        public static bool operator !=(System.Int16 x, TInt16 y)
        {
            if ((object)y == null)
                return true;
            return !y.Equals(x);
        }
		*/
        		
		    }
    public partial class TInt32: Field<System.Int32>
    {
		public TInt32()
            : base()
        { }
        public TInt32(System.Int32 x)
            : base(x)
        { }
        public static implicit operator TInt32(System.Int32 t)
        {
            return new TInt32(t);
        }
        public static implicit operator System.Int32(TInt32 f)
        {
			if ((object)f == null)
				return default(System.Int32);
			else
				return f.Value;
        }
		public override int CompareTo(object x)
		{
						return Value.CompareTo(x);
					}
		public override int GetHashCode()
        {
						return Value.GetHashCode();
			        }
        public override bool Equals(object x)
        {
					return Value.Equals(x);
		        }
		public bool Equals(TInt32 x)
        {
            if ((object)x == null)
                return false;
            return Value == x.Value;
        }
		public bool Equals(System.Int32 x)
        {
							return Value == x;
			        }
		public override string ToString()
        {
					return Value.ToString();
		        }
				//------------------ Equality (TInt32, TInt32) --------------
        public static bool operator ==(TInt32 x, TInt32 y)
        {
            if ((object)x == null && (object)y == null)
                return true;
            if ((object)x == null)
                return false;
            return x.Equals(y);
        }
        public static bool operator !=(TInt32 x, TInt32 y)
        {
            if ((object)x == null && (object)y == null)
                return false;
            if ((object)x == null)
                return true;
            return !x.Equals(y);
        }
        //------------------ Equality (TInt32, System.Int32) --------------
		/*
        public static bool operator ==(TInt32 x, System.Int32 y)
        {
            if ((object)x == null)
                return false;
            return x.Equals(y);
        }
        public static bool operator !=(TInt32 x, System.Int32 y)
        {
            if ((object)x == null)
                return true;
            return !x.Equals(y);
        }
		*/
        //------------------ Equality (System.Int32, TInt32) --------------
		/*
        public static bool operator ==(System.Int32 x, TInt32 y)
        {
            if ((object)y == null)
                return false;
            return y.Equals(x);
        }
        public static bool operator !=(System.Int32 x, TInt32 y)
        {
            if ((object)y == null)
                return true;
            return !y.Equals(x);
        }
		*/
        		
		    }
    public partial class TInt64: Field<System.Int64>
    {
		public TInt64()
            : base()
        { }
        public TInt64(System.Int64 x)
            : base(x)
        { }
        public static implicit operator TInt64(System.Int64 t)
        {
            return new TInt64(t);
        }
        public static implicit operator System.Int64(TInt64 f)
        {
			if ((object)f == null)
				return default(System.Int64);
			else
				return f.Value;
        }
		public override int CompareTo(object x)
		{
						return Value.CompareTo(x);
					}
		public override int GetHashCode()
        {
						return Value.GetHashCode();
			        }
        public override bool Equals(object x)
        {
					return Value.Equals(x);
		        }
		public bool Equals(TInt64 x)
        {
            if ((object)x == null)
                return false;
            return Value == x.Value;
        }
		public bool Equals(System.Int64 x)
        {
							return Value == x;
			        }
		public override string ToString()
        {
					return Value.ToString();
		        }
				//------------------ Equality (TInt64, TInt64) --------------
        public static bool operator ==(TInt64 x, TInt64 y)
        {
            if ((object)x == null && (object)y == null)
                return true;
            if ((object)x == null)
                return false;
            return x.Equals(y);
        }
        public static bool operator !=(TInt64 x, TInt64 y)
        {
            if ((object)x == null && (object)y == null)
                return false;
            if ((object)x == null)
                return true;
            return !x.Equals(y);
        }
        //------------------ Equality (TInt64, System.Int64) --------------
		/*
        public static bool operator ==(TInt64 x, System.Int64 y)
        {
            if ((object)x == null)
                return false;
            return x.Equals(y);
        }
        public static bool operator !=(TInt64 x, System.Int64 y)
        {
            if ((object)x == null)
                return true;
            return !x.Equals(y);
        }
		*/
        //------------------ Equality (System.Int64, TInt64) --------------
		/*
        public static bool operator ==(System.Int64 x, TInt64 y)
        {
            if ((object)y == null)
                return false;
            return y.Equals(x);
        }
        public static bool operator !=(System.Int64 x, TInt64 y)
        {
            if ((object)y == null)
                return true;
            return !y.Equals(x);
        }
		*/
        		
		    }
    public partial class TUInt16: Field<System.UInt16>
    {
		public TUInt16()
            : base()
        { }
        public TUInt16(System.UInt16 x)
            : base(x)
        { }
        public static implicit operator TUInt16(System.UInt16 t)
        {
            return new TUInt16(t);
        }
        public static implicit operator System.UInt16(TUInt16 f)
        {
			if ((object)f == null)
				return default(System.UInt16);
			else
				return f.Value;
        }
		public override int CompareTo(object x)
		{
						return Value.CompareTo(x);
					}
		public override int GetHashCode()
        {
						return Value.GetHashCode();
			        }
        public override bool Equals(object x)
        {
					return Value.Equals(x);
		        }
		public bool Equals(TUInt16 x)
        {
            if ((object)x == null)
                return false;
            return Value == x.Value;
        }
		public bool Equals(System.UInt16 x)
        {
							return Value == x;
			        }
		public override string ToString()
        {
					return Value.ToString();
		        }
				//------------------ Equality (TUInt16, TUInt16) --------------
        public static bool operator ==(TUInt16 x, TUInt16 y)
        {
            if ((object)x == null && (object)y == null)
                return true;
            if ((object)x == null)
                return false;
            return x.Equals(y);
        }
        public static bool operator !=(TUInt16 x, TUInt16 y)
        {
            if ((object)x == null && (object)y == null)
                return false;
            if ((object)x == null)
                return true;
            return !x.Equals(y);
        }
        //------------------ Equality (TUInt16, System.UInt16) --------------
		/*
        public static bool operator ==(TUInt16 x, System.UInt16 y)
        {
            if ((object)x == null)
                return false;
            return x.Equals(y);
        }
        public static bool operator !=(TUInt16 x, System.UInt16 y)
        {
            if ((object)x == null)
                return true;
            return !x.Equals(y);
        }
		*/
        //------------------ Equality (System.UInt16, TUInt16) --------------
		/*
        public static bool operator ==(System.UInt16 x, TUInt16 y)
        {
            if ((object)y == null)
                return false;
            return y.Equals(x);
        }
        public static bool operator !=(System.UInt16 x, TUInt16 y)
        {
            if ((object)y == null)
                return true;
            return !y.Equals(x);
        }
		*/
        		
		    }
    public partial class TUInt32: Field<System.UInt32>
    {
		public TUInt32()
            : base()
        { }
        public TUInt32(System.UInt32 x)
            : base(x)
        { }
        public static implicit operator TUInt32(System.UInt32 t)
        {
            return new TUInt32(t);
        }
        public static implicit operator System.UInt32(TUInt32 f)
        {
			if ((object)f == null)
				return default(System.UInt32);
			else
				return f.Value;
        }
		public override int CompareTo(object x)
		{
						return Value.CompareTo(x);
					}
		public override int GetHashCode()
        {
						return Value.GetHashCode();
			        }
        public override bool Equals(object x)
        {
					return Value.Equals(x);
		        }
		public bool Equals(TUInt32 x)
        {
            if ((object)x == null)
                return false;
            return Value == x.Value;
        }
		public bool Equals(System.UInt32 x)
        {
							return Value == x;
			        }
		public override string ToString()
        {
					return Value.ToString();
		        }
				//------------------ Equality (TUInt32, TUInt32) --------------
        public static bool operator ==(TUInt32 x, TUInt32 y)
        {
            if ((object)x == null && (object)y == null)
                return true;
            if ((object)x == null)
                return false;
            return x.Equals(y);
        }
        public static bool operator !=(TUInt32 x, TUInt32 y)
        {
            if ((object)x == null && (object)y == null)
                return false;
            if ((object)x == null)
                return true;
            return !x.Equals(y);
        }
        //------------------ Equality (TUInt32, System.UInt32) --------------
		/*
        public static bool operator ==(TUInt32 x, System.UInt32 y)
        {
            if ((object)x == null)
                return false;
            return x.Equals(y);
        }
        public static bool operator !=(TUInt32 x, System.UInt32 y)
        {
            if ((object)x == null)
                return true;
            return !x.Equals(y);
        }
		*/
        //------------------ Equality (System.UInt32, TUInt32) --------------
		/*
        public static bool operator ==(System.UInt32 x, TUInt32 y)
        {
            if ((object)y == null)
                return false;
            return y.Equals(x);
        }
        public static bool operator !=(System.UInt32 x, TUInt32 y)
        {
            if ((object)y == null)
                return true;
            return !y.Equals(x);
        }
		*/
        		
		    }
    public partial class TUInt64: Field<System.UInt64>
    {
		public TUInt64()
            : base()
        { }
        public TUInt64(System.UInt64 x)
            : base(x)
        { }
        public static implicit operator TUInt64(System.UInt64 t)
        {
            return new TUInt64(t);
        }
        public static implicit operator System.UInt64(TUInt64 f)
        {
			if ((object)f == null)
				return default(System.UInt64);
			else
				return f.Value;
        }
		public override int CompareTo(object x)
		{
						return Value.CompareTo(x);
					}
		public override int GetHashCode()
        {
						return Value.GetHashCode();
			        }
        public override bool Equals(object x)
        {
					return Value.Equals(x);
		        }
		public bool Equals(TUInt64 x)
        {
            if ((object)x == null)
                return false;
            return Value == x.Value;
        }
		public bool Equals(System.UInt64 x)
        {
							return Value == x;
			        }
		public override string ToString()
        {
					return Value.ToString();
		        }
				//------------------ Equality (TUInt64, TUInt64) --------------
        public static bool operator ==(TUInt64 x, TUInt64 y)
        {
            if ((object)x == null && (object)y == null)
                return true;
            if ((object)x == null)
                return false;
            return x.Equals(y);
        }
        public static bool operator !=(TUInt64 x, TUInt64 y)
        {
            if ((object)x == null && (object)y == null)
                return false;
            if ((object)x == null)
                return true;
            return !x.Equals(y);
        }
        //------------------ Equality (TUInt64, System.UInt64) --------------
		/*
        public static bool operator ==(TUInt64 x, System.UInt64 y)
        {
            if ((object)x == null)
                return false;
            return x.Equals(y);
        }
        public static bool operator !=(TUInt64 x, System.UInt64 y)
        {
            if ((object)x == null)
                return true;
            return !x.Equals(y);
        }
		*/
        //------------------ Equality (System.UInt64, TUInt64) --------------
		/*
        public static bool operator ==(System.UInt64 x, TUInt64 y)
        {
            if ((object)y == null)
                return false;
            return y.Equals(x);
        }
        public static bool operator !=(System.UInt64 x, TUInt64 y)
        {
            if ((object)y == null)
                return true;
            return !y.Equals(x);
        }
		*/
        		
		    }
    public partial class TInt: Field<System.Int32>
    {
		public TInt()
            : base()
        { }
        public TInt(System.Int32 x)
            : base(x)
        { }
        public static implicit operator TInt(System.Int32 t)
        {
            return new TInt(t);
        }
        public static implicit operator System.Int32(TInt f)
        {
			if ((object)f == null)
				return default(System.Int32);
			else
				return f.Value;
        }
		public override int CompareTo(object x)
		{
						return Value.CompareTo(x);
					}
		public override int GetHashCode()
        {
						return Value.GetHashCode();
			        }
        public override bool Equals(object x)
        {
					return Value.Equals(x);
		        }
		public bool Equals(TInt x)
        {
            if ((object)x == null)
                return false;
            return Value == x.Value;
        }
		public bool Equals(System.Int32 x)
        {
							return Value == x;
			        }
		public override string ToString()
        {
					return Value.ToString();
		        }
				//------------------ Equality (TInt, TInt) --------------
        public static bool operator ==(TInt x, TInt y)
        {
            if ((object)x == null && (object)y == null)
                return true;
            if ((object)x == null)
                return false;
            return x.Equals(y);
        }
        public static bool operator !=(TInt x, TInt y)
        {
            if ((object)x == null && (object)y == null)
                return false;
            if ((object)x == null)
                return true;
            return !x.Equals(y);
        }
        //------------------ Equality (TInt, System.Int32) --------------
		/*
        public static bool operator ==(TInt x, System.Int32 y)
        {
            if ((object)x == null)
                return false;
            return x.Equals(y);
        }
        public static bool operator !=(TInt x, System.Int32 y)
        {
            if ((object)x == null)
                return true;
            return !x.Equals(y);
        }
		*/
        //------------------ Equality (System.Int32, TInt) --------------
		/*
        public static bool operator ==(System.Int32 x, TInt y)
        {
            if ((object)y == null)
                return false;
            return y.Equals(x);
        }
        public static bool operator !=(System.Int32 x, TInt y)
        {
            if ((object)y == null)
                return true;
            return !y.Equals(x);
        }
		*/
        		
		    }
    public partial class TLong: Field<System.Int64>
    {
		public TLong()
            : base()
        { }
        public TLong(System.Int64 x)
            : base(x)
        { }
        public static implicit operator TLong(System.Int64 t)
        {
            return new TLong(t);
        }
        public static implicit operator System.Int64(TLong f)
        {
			if ((object)f == null)
				return default(System.Int64);
			else
				return f.Value;
        }
		public override int CompareTo(object x)
		{
						return Value.CompareTo(x);
					}
		public override int GetHashCode()
        {
						return Value.GetHashCode();
			        }
        public override bool Equals(object x)
        {
					return Value.Equals(x);
		        }
		public bool Equals(TLong x)
        {
            if ((object)x == null)
                return false;
            return Value == x.Value;
        }
		public bool Equals(System.Int64 x)
        {
							return Value == x;
			        }
		public override string ToString()
        {
					return Value.ToString();
		        }
				//------------------ Equality (TLong, TLong) --------------
        public static bool operator ==(TLong x, TLong y)
        {
            if ((object)x == null && (object)y == null)
                return true;
            if ((object)x == null)
                return false;
            return x.Equals(y);
        }
        public static bool operator !=(TLong x, TLong y)
        {
            if ((object)x == null && (object)y == null)
                return false;
            if ((object)x == null)
                return true;
            return !x.Equals(y);
        }
        //------------------ Equality (TLong, System.Int64) --------------
		/*
        public static bool operator ==(TLong x, System.Int64 y)
        {
            if ((object)x == null)
                return false;
            return x.Equals(y);
        }
        public static bool operator !=(TLong x, System.Int64 y)
        {
            if ((object)x == null)
                return true;
            return !x.Equals(y);
        }
		*/
        //------------------ Equality (System.Int64, TLong) --------------
		/*
        public static bool operator ==(System.Int64 x, TLong y)
        {
            if ((object)y == null)
                return false;
            return y.Equals(x);
        }
        public static bool operator !=(System.Int64 x, TLong y)
        {
            if ((object)y == null)
                return true;
            return !y.Equals(x);
        }
		*/
        		
		    }
    public partial class TShort: Field<System.Int16>
    {
		public TShort()
            : base()
        { }
        public TShort(System.Int16 x)
            : base(x)
        { }
        public static implicit operator TShort(System.Int16 t)
        {
            return new TShort(t);
        }
        public static implicit operator System.Int16(TShort f)
        {
			if ((object)f == null)
				return default(System.Int16);
			else
				return f.Value;
        }
		public override int CompareTo(object x)
		{
						return Value.CompareTo(x);
					}
		public override int GetHashCode()
        {
						return Value.GetHashCode();
			        }
        public override bool Equals(object x)
        {
					return Value.Equals(x);
		        }
		public bool Equals(TShort x)
        {
            if ((object)x == null)
                return false;
            return Value == x.Value;
        }
		public bool Equals(System.Int16 x)
        {
							return Value == x;
			        }
		public override string ToString()
        {
					return Value.ToString();
		        }
				//------------------ Equality (TShort, TShort) --------------
        public static bool operator ==(TShort x, TShort y)
        {
            if ((object)x == null && (object)y == null)
                return true;
            if ((object)x == null)
                return false;
            return x.Equals(y);
        }
        public static bool operator !=(TShort x, TShort y)
        {
            if ((object)x == null && (object)y == null)
                return false;
            if ((object)x == null)
                return true;
            return !x.Equals(y);
        }
        //------------------ Equality (TShort, System.Int16) --------------
		/*
        public static bool operator ==(TShort x, System.Int16 y)
        {
            if ((object)x == null)
                return false;
            return x.Equals(y);
        }
        public static bool operator !=(TShort x, System.Int16 y)
        {
            if ((object)x == null)
                return true;
            return !x.Equals(y);
        }
		*/
        //------------------ Equality (System.Int16, TShort) --------------
		/*
        public static bool operator ==(System.Int16 x, TShort y)
        {
            if ((object)y == null)
                return false;
            return y.Equals(x);
        }
        public static bool operator !=(System.Int16 x, TShort y)
        {
            if ((object)y == null)
                return true;
            return !y.Equals(x);
        }
		*/
        		
		    }
    public partial class TUInt: Field<System.UInt32>
    {
		public TUInt()
            : base()
        { }
        public TUInt(System.UInt32 x)
            : base(x)
        { }
        public static implicit operator TUInt(System.UInt32 t)
        {
            return new TUInt(t);
        }
        public static implicit operator System.UInt32(TUInt f)
        {
			if ((object)f == null)
				return default(System.UInt32);
			else
				return f.Value;
        }
		public override int CompareTo(object x)
		{
						return Value.CompareTo(x);
					}
		public override int GetHashCode()
        {
						return Value.GetHashCode();
			        }
        public override bool Equals(object x)
        {
					return Value.Equals(x);
		        }
		public bool Equals(TUInt x)
        {
            if ((object)x == null)
                return false;
            return Value == x.Value;
        }
		public bool Equals(System.UInt32 x)
        {
							return Value == x;
			        }
		public override string ToString()
        {
					return Value.ToString();
		        }
				//------------------ Equality (TUInt, TUInt) --------------
        public static bool operator ==(TUInt x, TUInt y)
        {
            if ((object)x == null && (object)y == null)
                return true;
            if ((object)x == null)
                return false;
            return x.Equals(y);
        }
        public static bool operator !=(TUInt x, TUInt y)
        {
            if ((object)x == null && (object)y == null)
                return false;
            if ((object)x == null)
                return true;
            return !x.Equals(y);
        }
        //------------------ Equality (TUInt, System.UInt32) --------------
		/*
        public static bool operator ==(TUInt x, System.UInt32 y)
        {
            if ((object)x == null)
                return false;
            return x.Equals(y);
        }
        public static bool operator !=(TUInt x, System.UInt32 y)
        {
            if ((object)x == null)
                return true;
            return !x.Equals(y);
        }
		*/
        //------------------ Equality (System.UInt32, TUInt) --------------
		/*
        public static bool operator ==(System.UInt32 x, TUInt y)
        {
            if ((object)y == null)
                return false;
            return y.Equals(x);
        }
        public static bool operator !=(System.UInt32 x, TUInt y)
        {
            if ((object)y == null)
                return true;
            return !y.Equals(x);
        }
		*/
        		
		    }
    public partial class TULong: Field<System.UInt64>
    {
		public TULong()
            : base()
        { }
        public TULong(System.UInt64 x)
            : base(x)
        { }
        public static implicit operator TULong(System.UInt64 t)
        {
            return new TULong(t);
        }
        public static implicit operator System.UInt64(TULong f)
        {
			if ((object)f == null)
				return default(System.UInt64);
			else
				return f.Value;
        }
		public override int CompareTo(object x)
		{
						return Value.CompareTo(x);
					}
		public override int GetHashCode()
        {
						return Value.GetHashCode();
			        }
        public override bool Equals(object x)
        {
					return Value.Equals(x);
		        }
		public bool Equals(TULong x)
        {
            if ((object)x == null)
                return false;
            return Value == x.Value;
        }
		public bool Equals(System.UInt64 x)
        {
							return Value == x;
			        }
		public override string ToString()
        {
					return Value.ToString();
		        }
				//------------------ Equality (TULong, TULong) --------------
        public static bool operator ==(TULong x, TULong y)
        {
            if ((object)x == null && (object)y == null)
                return true;
            if ((object)x == null)
                return false;
            return x.Equals(y);
        }
        public static bool operator !=(TULong x, TULong y)
        {
            if ((object)x == null && (object)y == null)
                return false;
            if ((object)x == null)
                return true;
            return !x.Equals(y);
        }
        //------------------ Equality (TULong, System.UInt64) --------------
		/*
        public static bool operator ==(TULong x, System.UInt64 y)
        {
            if ((object)x == null)
                return false;
            return x.Equals(y);
        }
        public static bool operator !=(TULong x, System.UInt64 y)
        {
            if ((object)x == null)
                return true;
            return !x.Equals(y);
        }
		*/
        //------------------ Equality (System.UInt64, TULong) --------------
		/*
        public static bool operator ==(System.UInt64 x, TULong y)
        {
            if ((object)y == null)
                return false;
            return y.Equals(x);
        }
        public static bool operator !=(System.UInt64 x, TULong y)
        {
            if ((object)y == null)
                return true;
            return !y.Equals(x);
        }
		*/
        		
		    }
    public partial class TUShort: Field<System.UInt16>
    {
		public TUShort()
            : base()
        { }
        public TUShort(System.UInt16 x)
            : base(x)
        { }
        public static implicit operator TUShort(System.UInt16 t)
        {
            return new TUShort(t);
        }
        public static implicit operator System.UInt16(TUShort f)
        {
			if ((object)f == null)
				return default(System.UInt16);
			else
				return f.Value;
        }
		public override int CompareTo(object x)
		{
						return Value.CompareTo(x);
					}
		public override int GetHashCode()
        {
						return Value.GetHashCode();
			        }
        public override bool Equals(object x)
        {
					return Value.Equals(x);
		        }
		public bool Equals(TUShort x)
        {
            if ((object)x == null)
                return false;
            return Value == x.Value;
        }
		public bool Equals(System.UInt16 x)
        {
							return Value == x;
			        }
		public override string ToString()
        {
					return Value.ToString();
		        }
				//------------------ Equality (TUShort, TUShort) --------------
        public static bool operator ==(TUShort x, TUShort y)
        {
            if ((object)x == null && (object)y == null)
                return true;
            if ((object)x == null)
                return false;
            return x.Equals(y);
        }
        public static bool operator !=(TUShort x, TUShort y)
        {
            if ((object)x == null && (object)y == null)
                return false;
            if ((object)x == null)
                return true;
            return !x.Equals(y);
        }
        //------------------ Equality (TUShort, System.UInt16) --------------
		/*
        public static bool operator ==(TUShort x, System.UInt16 y)
        {
            if ((object)x == null)
                return false;
            return x.Equals(y);
        }
        public static bool operator !=(TUShort x, System.UInt16 y)
        {
            if ((object)x == null)
                return true;
            return !x.Equals(y);
        }
		*/
        //------------------ Equality (System.UInt16, TUShort) --------------
		/*
        public static bool operator ==(System.UInt16 x, TUShort y)
        {
            if ((object)y == null)
                return false;
            return y.Equals(x);
        }
        public static bool operator !=(System.UInt16 x, TUShort y)
        {
            if ((object)y == null)
                return true;
            return !y.Equals(x);
        }
		*/
        		
		    }
    public partial class TSingle: Field<System.Single>
    {
		public TSingle()
            : base()
        { }
        public TSingle(System.Single x)
            : base(x)
        { }
        public static implicit operator TSingle(System.Single t)
        {
            return new TSingle(t);
        }
        public static implicit operator System.Single(TSingle f)
        {
			if ((object)f == null)
				return default(System.Single);
			else
				return f.Value;
        }
		public override int CompareTo(object x)
		{
						return Value.CompareTo(x);
					}
		public override int GetHashCode()
        {
						return Value.GetHashCode();
			        }
        public override bool Equals(object x)
        {
					return Value.Equals(x);
		        }
		public bool Equals(TSingle x)
        {
            if ((object)x == null)
                return false;
            return Value == x.Value;
        }
		public bool Equals(System.Single x)
        {
							return Value == x;
			        }
		public override string ToString()
        {
					return Value.ToString();
		        }
				//------------------ Equality (TSingle, TSingle) --------------
        public static bool operator ==(TSingle x, TSingle y)
        {
            if ((object)x == null && (object)y == null)
                return true;
            if ((object)x == null)
                return false;
            return x.Equals(y);
        }
        public static bool operator !=(TSingle x, TSingle y)
        {
            if ((object)x == null && (object)y == null)
                return false;
            if ((object)x == null)
                return true;
            return !x.Equals(y);
        }
        //------------------ Equality (TSingle, System.Single) --------------
		/*
        public static bool operator ==(TSingle x, System.Single y)
        {
            if ((object)x == null)
                return false;
            return x.Equals(y);
        }
        public static bool operator !=(TSingle x, System.Single y)
        {
            if ((object)x == null)
                return true;
            return !x.Equals(y);
        }
		*/
        //------------------ Equality (System.Single, TSingle) --------------
		/*
        public static bool operator ==(System.Single x, TSingle y)
        {
            if ((object)y == null)
                return false;
            return y.Equals(x);
        }
        public static bool operator !=(System.Single x, TSingle y)
        {
            if ((object)y == null)
                return true;
            return !y.Equals(x);
        }
		*/
        		
		    }
    public partial class TDouble: Field<System.Double>
    {
		public TDouble()
            : base()
        { }
        public TDouble(System.Double x)
            : base(x)
        { }
        public static implicit operator TDouble(System.Double t)
        {
            return new TDouble(t);
        }
        public static implicit operator System.Double(TDouble f)
        {
			if ((object)f == null)
				return default(System.Double);
			else
				return f.Value;
        }
		public override int CompareTo(object x)
		{
						return Value.CompareTo(x);
					}
		public override int GetHashCode()
        {
						return Value.GetHashCode();
			        }
        public override bool Equals(object x)
        {
					return Value.Equals(x);
		        }
		public bool Equals(TDouble x)
        {
            if ((object)x == null)
                return false;
            return Value == x.Value;
        }
		public bool Equals(System.Double x)
        {
							return Value == x;
			        }
		public override string ToString()
        {
					return Value.ToString();
		        }
				//------------------ Equality (TDouble, TDouble) --------------
        public static bool operator ==(TDouble x, TDouble y)
        {
            if ((object)x == null && (object)y == null)
                return true;
            if ((object)x == null)
                return false;
            return x.Equals(y);
        }
        public static bool operator !=(TDouble x, TDouble y)
        {
            if ((object)x == null && (object)y == null)
                return false;
            if ((object)x == null)
                return true;
            return !x.Equals(y);
        }
        //------------------ Equality (TDouble, System.Double) --------------
		/*
        public static bool operator ==(TDouble x, System.Double y)
        {
            if ((object)x == null)
                return false;
            return x.Equals(y);
        }
        public static bool operator !=(TDouble x, System.Double y)
        {
            if ((object)x == null)
                return true;
            return !x.Equals(y);
        }
		*/
        //------------------ Equality (System.Double, TDouble) --------------
		/*
        public static bool operator ==(System.Double x, TDouble y)
        {
            if ((object)y == null)
                return false;
            return y.Equals(x);
        }
        public static bool operator !=(System.Double x, TDouble y)
        {
            if ((object)y == null)
                return true;
            return !y.Equals(x);
        }
		*/
        		
		    }
    public partial class TFloat: Field<System.Single>
    {
		public TFloat()
            : base()
        { }
        public TFloat(System.Single x)
            : base(x)
        { }
        public static implicit operator TFloat(System.Single t)
        {
            return new TFloat(t);
        }
        public static implicit operator System.Single(TFloat f)
        {
			if ((object)f == null)
				return default(System.Single);
			else
				return f.Value;
        }
		public override int CompareTo(object x)
		{
						return Value.CompareTo(x);
					}
		public override int GetHashCode()
        {
						return Value.GetHashCode();
			        }
        public override bool Equals(object x)
        {
					return Value.Equals(x);
		        }
		public bool Equals(TFloat x)
        {
            if ((object)x == null)
                return false;
            return Value == x.Value;
        }
		public bool Equals(System.Single x)
        {
							return Value == x;
			        }
		public override string ToString()
        {
					return Value.ToString();
		        }
				//------------------ Equality (TFloat, TFloat) --------------
        public static bool operator ==(TFloat x, TFloat y)
        {
            if ((object)x == null && (object)y == null)
                return true;
            if ((object)x == null)
                return false;
            return x.Equals(y);
        }
        public static bool operator !=(TFloat x, TFloat y)
        {
            if ((object)x == null && (object)y == null)
                return false;
            if ((object)x == null)
                return true;
            return !x.Equals(y);
        }
        //------------------ Equality (TFloat, System.Single) --------------
		/*
        public static bool operator ==(TFloat x, System.Single y)
        {
            if ((object)x == null)
                return false;
            return x.Equals(y);
        }
        public static bool operator !=(TFloat x, System.Single y)
        {
            if ((object)x == null)
                return true;
            return !x.Equals(y);
        }
		*/
        //------------------ Equality (System.Single, TFloat) --------------
		/*
        public static bool operator ==(System.Single x, TFloat y)
        {
            if ((object)y == null)
                return false;
            return y.Equals(x);
        }
        public static bool operator !=(System.Single x, TFloat y)
        {
            if ((object)y == null)
                return true;
            return !y.Equals(x);
        }
		*/
        		
		    }
    public partial class TDecimal: Field<System.Decimal>
    {
		public TDecimal()
            : base()
        { }
        public TDecimal(System.Decimal x)
            : base(x)
        { }
        public static implicit operator TDecimal(System.Decimal t)
        {
            return new TDecimal(t);
        }
        public static implicit operator System.Decimal(TDecimal f)
        {
			if ((object)f == null)
				return default(System.Decimal);
			else
				return f.Value;
        }
		public override int CompareTo(object x)
		{
						return Value.CompareTo(x);
					}
		public override int GetHashCode()
        {
						return Value.GetHashCode();
			        }
        public override bool Equals(object x)
        {
					return Value.Equals(x);
		        }
		public bool Equals(TDecimal x)
        {
            if ((object)x == null)
                return false;
            return Value == x.Value;
        }
		public bool Equals(System.Decimal x)
        {
							return Value == x;
			        }
		public override string ToString()
        {
					return Value.ToString();
		        }
				//------------------ Equality (TDecimal, TDecimal) --------------
        public static bool operator ==(TDecimal x, TDecimal y)
        {
            if ((object)x == null && (object)y == null)
                return true;
            if ((object)x == null)
                return false;
            return x.Equals(y);
        }
        public static bool operator !=(TDecimal x, TDecimal y)
        {
            if ((object)x == null && (object)y == null)
                return false;
            if ((object)x == null)
                return true;
            return !x.Equals(y);
        }
        //------------------ Equality (TDecimal, System.Decimal) --------------
		/*
        public static bool operator ==(TDecimal x, System.Decimal y)
        {
            if ((object)x == null)
                return false;
            return x.Equals(y);
        }
        public static bool operator !=(TDecimal x, System.Decimal y)
        {
            if ((object)x == null)
                return true;
            return !x.Equals(y);
        }
		*/
        //------------------ Equality (System.Decimal, TDecimal) --------------
		/*
        public static bool operator ==(System.Decimal x, TDecimal y)
        {
            if ((object)y == null)
                return false;
            return y.Equals(x);
        }
        public static bool operator !=(System.Decimal x, TDecimal y)
        {
            if ((object)y == null)
                return true;
            return !y.Equals(x);
        }
		*/
        		
		    }
    public partial class TChar: Field<System.Char>
    {
		public TChar()
            : base()
        { }
        public TChar(System.Char x)
            : base(x)
        { }
        public static implicit operator TChar(System.Char t)
        {
            return new TChar(t);
        }
        public static implicit operator System.Char(TChar f)
        {
			if ((object)f == null)
				return default(System.Char);
			else
				return f.Value;
        }
		public override int CompareTo(object x)
		{
						return Value.CompareTo(x);
					}
		public override int GetHashCode()
        {
						return Value.GetHashCode();
			        }
        public override bool Equals(object x)
        {
					return Value.Equals(x);
		        }
		public bool Equals(TChar x)
        {
            if ((object)x == null)
                return false;
            return Value == x.Value;
        }
		public bool Equals(System.Char x)
        {
							return Value == x;
			        }
		public override string ToString()
        {
					return Value.ToString();
		        }
				//------------------ Equality (TChar, TChar) --------------
        public static bool operator ==(TChar x, TChar y)
        {
            if ((object)x == null && (object)y == null)
                return true;
            if ((object)x == null)
                return false;
            return x.Equals(y);
        }
        public static bool operator !=(TChar x, TChar y)
        {
            if ((object)x == null && (object)y == null)
                return false;
            if ((object)x == null)
                return true;
            return !x.Equals(y);
        }
        //------------------ Equality (TChar, System.Char) --------------
		/*
        public static bool operator ==(TChar x, System.Char y)
        {
            if ((object)x == null)
                return false;
            return x.Equals(y);
        }
        public static bool operator !=(TChar x, System.Char y)
        {
            if ((object)x == null)
                return true;
            return !x.Equals(y);
        }
		*/
        //------------------ Equality (System.Char, TChar) --------------
		/*
        public static bool operator ==(System.Char x, TChar y)
        {
            if ((object)y == null)
                return false;
            return y.Equals(x);
        }
        public static bool operator !=(System.Char x, TChar y)
        {
            if ((object)y == null)
                return true;
            return !y.Equals(x);
        }
		*/
        		
		    }
    public partial class TDateTime: Field<System.DateTime>
    {
		public TDateTime()
            : base()
        { }
        public TDateTime(System.DateTime x)
            : base(x)
        { }
        public static implicit operator TDateTime(System.DateTime t)
        {
            return new TDateTime(t);
        }
        public static implicit operator System.DateTime(TDateTime f)
        {
			if ((object)f == null)
				return default(System.DateTime);
			else
				return f.Value;
        }
		public override int CompareTo(object x)
		{
						return Value.CompareTo(x);
					}
		public override int GetHashCode()
        {
						return Value.GetHashCode();
			        }
        public override bool Equals(object x)
        {
					return Value.Equals(x);
		        }
		public bool Equals(TDateTime x)
        {
            if ((object)x == null)
                return false;
            return Value == x.Value;
        }
		public bool Equals(System.DateTime x)
        {
							return Value == x;
			        }
		public override string ToString()
        {
					return Value.ToString();
		        }
				//------------------ Equality (TDateTime, TDateTime) --------------
        public static bool operator ==(TDateTime x, TDateTime y)
        {
            if ((object)x == null && (object)y == null)
                return true;
            if ((object)x == null)
                return false;
            return x.Equals(y);
        }
        public static bool operator !=(TDateTime x, TDateTime y)
        {
            if ((object)x == null && (object)y == null)
                return false;
            if ((object)x == null)
                return true;
            return !x.Equals(y);
        }
        //------------------ Equality (TDateTime, System.DateTime) --------------
		/*
        public static bool operator ==(TDateTime x, System.DateTime y)
        {
            if ((object)x == null)
                return false;
            return x.Equals(y);
        }
        public static bool operator !=(TDateTime x, System.DateTime y)
        {
            if ((object)x == null)
                return true;
            return !x.Equals(y);
        }
		*/
        //------------------ Equality (System.DateTime, TDateTime) --------------
		/*
        public static bool operator ==(System.DateTime x, TDateTime y)
        {
            if ((object)y == null)
                return false;
            return y.Equals(x);
        }
        public static bool operator !=(System.DateTime x, TDateTime y)
        {
            if ((object)y == null)
                return true;
            return !y.Equals(x);
        }
		*/
        		
		    }
    public partial class TGuid: Field<System.Guid>
    {
		public TGuid()
            : base()
        { }
        public TGuid(System.Guid x)
            : base(x)
        { }
        public static implicit operator TGuid(System.Guid t)
        {
            return new TGuid(t);
        }
        public static implicit operator System.Guid(TGuid f)
        {
			if ((object)f == null)
				return default(System.Guid);
			else
				return f.Value;
        }
		public override int CompareTo(object x)
		{
						return Value.CompareTo(x);
					}
		public override int GetHashCode()
        {
						return Value.GetHashCode();
			        }
        public override bool Equals(object x)
        {
					return Value.Equals(x);
		        }
		public bool Equals(TGuid x)
        {
            if ((object)x == null)
                return false;
            return Value == x.Value;
        }
		public bool Equals(System.Guid x)
        {
						if ((object)x == null)
				return false;
			else
				return Value == x;
			        }
		public override string ToString()
        {
					return ((Value == null)? null: (Value == Guid.Empty)?null:Value.ToString());
		        }
				//------------------ Equality (TGuid, TGuid) --------------
        public static bool operator ==(TGuid x, TGuid y)
        {
            if ((object)x == null && (object)y == null)
                return true;
            if ((object)x == null)
                return false;
            return x.Equals(y);
        }
        public static bool operator !=(TGuid x, TGuid y)
        {
            if ((object)x == null && (object)y == null)
                return false;
            if ((object)x == null)
                return true;
            return !x.Equals(y);
        }
        //------------------ Equality (TGuid, System.Guid) --------------
		/*
        public static bool operator ==(TGuid x, System.Guid y)
        {
            if ((object)x == null)
                return false;
            return x.Equals(y);
        }
        public static bool operator !=(TGuid x, System.Guid y)
        {
            if ((object)x == null)
                return true;
            return !x.Equals(y);
        }
		*/
        //------------------ Equality (System.Guid, TGuid) --------------
		/*
        public static bool operator ==(System.Guid x, TGuid y)
        {
            if ((object)y == null)
                return false;
            return y.Equals(x);
        }
        public static bool operator !=(System.Guid x, TGuid y)
        {
            if ((object)y == null)
                return true;
            return !y.Equals(x);
        }
		*/
        		
		        public static implicit operator TGuid(System.String t)
        {
			Guid g;
			if (Guid.TryParse(t, out g))
				return new TGuid(g);
			else
				return new TGuid(new Guid());
        }
        public static implicit operator System.String(TGuid f)
        {
            return f.Value.ToString();
        }
		    }
    public partial class TBoolean: Field<System.Boolean>
    {
		public TBoolean()
            : base()
        { }
        public TBoolean(System.Boolean x)
            : base(x)
        { }
        public static implicit operator TBoolean(System.Boolean t)
        {
            return new TBoolean(t);
        }
        public static implicit operator System.Boolean(TBoolean f)
        {
			if ((object)f == null)
				return default(System.Boolean);
			else
				return f.Value;
        }
		public override int CompareTo(object x)
		{
						return Value.CompareTo(x);
					}
		public override int GetHashCode()
        {
						return Value.GetHashCode();
			        }
        public override bool Equals(object x)
        {
					return Value.Equals(x);
		        }
		public bool Equals(TBoolean x)
        {
            if ((object)x == null)
                return false;
            return Value == x.Value;
        }
		public bool Equals(System.Boolean x)
        {
							return Value == x;
			        }
		public override string ToString()
        {
					return Value.ToString();
		        }
				//------------------ Equality (TBoolean, TBoolean) --------------
        public static bool operator ==(TBoolean x, TBoolean y)
        {
            if ((object)x == null && (object)y == null)
                return true;
            if ((object)x == null)
                return false;
            return x.Equals(y);
        }
        public static bool operator !=(TBoolean x, TBoolean y)
        {
            if ((object)x == null && (object)y == null)
                return false;
            if ((object)x == null)
                return true;
            return !x.Equals(y);
        }
        //------------------ Equality (TBoolean, System.Boolean) --------------
		/*
        public static bool operator ==(TBoolean x, System.Boolean y)
        {
            if ((object)x == null)
                return false;
            return x.Equals(y);
        }
        public static bool operator !=(TBoolean x, System.Boolean y)
        {
            if ((object)x == null)
                return true;
            return !x.Equals(y);
        }
		*/
        //------------------ Equality (System.Boolean, TBoolean) --------------
		/*
        public static bool operator ==(System.Boolean x, TBoolean y)
        {
            if ((object)y == null)
                return false;
            return y.Equals(x);
        }
        public static bool operator !=(System.Boolean x, TBoolean y)
        {
            if ((object)y == null)
                return true;
            return !y.Equals(x);
        }
		*/
        		
		    }
    public partial class TString: Field<System.String>
    {
		public TString()
            : base()
        { }
        public TString(System.String x)
            : base(x)
        { }
        public static implicit operator TString(System.String t)
        {
            return new TString(t);
        }
        public static implicit operator System.String(TString f)
        {
			if ((object)f == null)
				return default(System.String);
			else
				return f.Value;
        }
		public override int CompareTo(object x)
		{
						if (Value == null && x == null)
				return 0;
			if (Value == null)
				return -1;
			if (x == null)
				return 1;
			return Value.CompareTo(x);
					}
		public override int GetHashCode()
        {
						if (Value == null)
				return 0;
			return Value.GetHashCode();
			        }
        public override bool Equals(object x)
        {
					if (Value == null && x == null)
				return true;
			if (Value == null)
				return false;
            return Value.Equals(x);
		        }
		public bool Equals(TString x)
        {
            if ((object)x == null)
                return false;
            return Value == x.Value;
        }
		public bool Equals(System.String x)
        {
						if ((object)x == null)
				return false;
			else
				return Value == x;
			        }
		public override string ToString()
        {
		            return ((Value == null)? null: Value.ToString());
		        }
				//------------------ Equality (TString, TString) --------------
        public static bool operator ==(TString x, TString y)
        {
            if ((object)x == null && (object)y == null)
                return true;
            if ((object)x == null)
                return false;
            return x.Equals(y);
        }
        public static bool operator !=(TString x, TString y)
        {
            if ((object)x == null && (object)y == null)
                return false;
            if ((object)x == null)
                return true;
            return !x.Equals(y);
        }
        //------------------ Equality (TString, System.String) --------------
		/*
        public static bool operator ==(TString x, System.String y)
        {
            if ((object)x == null)
                return false;
            return x.Equals(y);
        }
        public static bool operator !=(TString x, System.String y)
        {
            if ((object)x == null)
                return true;
            return !x.Equals(y);
        }
		*/
        //------------------ Equality (System.String, TString) --------------
		/*
        public static bool operator ==(System.String x, TString y)
        {
            if ((object)y == null)
                return false;
            return y.Equals(x);
        }
        public static bool operator !=(System.String x, TString y)
        {
            if ((object)y == null)
                return true;
            return !y.Equals(x);
        }
		*/
        		
		    }
	/*
	public class TString : Field<System.String>
    {
        public int Size { get; set; }

        public TString(): base()
        {
            Size = -1;
        }

        public TString(string x): base(x)
        { }
    }
	*/
	public static class TypeHelper
    {
		public static Type TypeOfTByte { get; private set; }
		public static Type TypeOfTSByte { get; private set; }
		public static Type TypeOfTInt16 { get; private set; }
		public static Type TypeOfTInt32 { get; private set; }
		public static Type TypeOfTInt64 { get; private set; }
		public static Type TypeOfTUInt16 { get; private set; }
		public static Type TypeOfTUInt32 { get; private set; }
		public static Type TypeOfTUInt64 { get; private set; }
		public static Type TypeOfTInt { get; private set; }
		public static Type TypeOfTLong { get; private set; }
		public static Type TypeOfTShort { get; private set; }
		public static Type TypeOfTUInt { get; private set; }
		public static Type TypeOfTULong { get; private set; }
		public static Type TypeOfTUShort { get; private set; }
		public static Type TypeOfTSingle { get; private set; }
		public static Type TypeOfTDouble { get; private set; }
		public static Type TypeOfTFloat { get; private set; }
		public static Type TypeOfTDecimal { get; private set; }
		public static Type TypeOfTChar { get; private set; }
		public static Type TypeOfTDateTime { get; private set; }
		public static Type TypeOfTGuid { get; private set; }
		public static Type TypeOfTBoolean { get; private set; }
		public static Type TypeOfTString { get; private set; }
		//public static Type TypeOfTString { get; private set; }
		public static Type TypeOfField { get; private set; }
		static TypeHelper()
        {
			TypeOfTByte = typeof(Field<System.Byte>);
			TypeOfTSByte = typeof(Field<System.SByte>);
			TypeOfTInt16 = typeof(Field<System.Int16>);
			TypeOfTInt32 = typeof(Field<System.Int32>);
			TypeOfTInt64 = typeof(Field<System.Int64>);
			TypeOfTUInt16 = typeof(Field<System.UInt16>);
			TypeOfTUInt32 = typeof(Field<System.UInt32>);
			TypeOfTUInt64 = typeof(Field<System.UInt64>);
			TypeOfTInt = typeof(Field<System.Int32>);
			TypeOfTLong = typeof(Field<System.Int64>);
			TypeOfTShort = typeof(Field<System.Int16>);
			TypeOfTUInt = typeof(Field<System.UInt32>);
			TypeOfTULong = typeof(Field<System.UInt64>);
			TypeOfTUShort = typeof(Field<System.UInt16>);
			TypeOfTSingle = typeof(Field<System.Single>);
			TypeOfTDouble = typeof(Field<System.Double>);
			TypeOfTFloat = typeof(Field<System.Single>);
			TypeOfTDecimal = typeof(Field<System.Decimal>);
			TypeOfTChar = typeof(Field<System.Char>);
			TypeOfTDateTime = typeof(Field<System.DateTime>);
			TypeOfTGuid = typeof(Field<System.Guid>);
			TypeOfTBoolean = typeof(Field<System.Boolean>);
			TypeOfTString = typeof(Field<System.String>);
			//TypeOfTString = typeof(Field<System.String>);
			TypeOfField = typeof(Field<>);
		}
	}
}
