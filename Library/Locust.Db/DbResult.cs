using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Locust.Db
{
    public enum DbMessageType
    {
        SingleSuccess,
        MultipleSuccess,
        SingleNotFound,
        MultipleNotFound,
        SingleError,
        MultipleError,
        None,
        Error,
        Success
    }

    public class DbResult
    {
        public bool Success { get; set; }
        public Exception Exception { get; set; }
        public DbMessageType MessageType { get; set; }
        public int Count { get; set; }
        public string Info { get; set; }
        public DbResult()
        { }
        public DbResult<T> Copy<T>()
        {
            var result = new DbResult<T>
            {
                Success = this.Success,
                Exception = this.Exception,
                Count = this.Count,
                Info = this.Info,
                MessageType = this.MessageType
            };

            return result;
        }
        public static DbResult<U> From<T, U>(DbResult<T> dbr, U data = default(U))
        {
            var result = new DbResult<U>
            {
                Success = dbr.Success,
                Exception = dbr.Exception,
                Count = dbr.Count,
                Info = dbr.Info,
                MessageType = dbr.MessageType,
                Data = data
            };

            return result;
        }
    }
    public class DbResult<T> : DbResult
    {
        public T Data { get; set; }
        public DbResult()
        { }

        public DbResult(DbResult r)
        {
            this.Count = r.Count;
            this.Exception = r.Exception;
            this.Success = r.Success;
            this.MessageType = r.MessageType;
            this.Info = r.Info;
        }
        public DbResult(DbResult r, T data): this(r)
        {
            this.Data = data;
        }
        public DbResult<U> To<U>()
        {
            var result = new DbResult<U>();

            result.Data = (U)Convert.ChangeType(Data, typeof (U));

            return result;
        }
        public DbResult Copy()
        {
            var result = new DbResult
            {
                Success = this.Success,
                Exception = this.Exception,
                Count = this.Count,
                Info = this.Info,
                MessageType = this.MessageType
            };

            return result;
        }
        public DbResult<TR> Copy<TR>(TR data)
        {
            var result = new DbResult<TR>
            {
                Success = this.Success,
                Exception = this.Exception,
                Count = this.Count,
                Info = this.Info,
                MessageType = this.MessageType,
                Data = data
            };

            return result;
        }
    }
}
