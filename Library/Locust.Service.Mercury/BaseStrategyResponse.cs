using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Service.Mercury
{
    public class BaseStrategyResponse
    {
        public bool Success { get; set; }
        public Exception Exception { get; set; }
        public string Message { get; set; }
        private Dictionary<string, string> modelErrors;
        public Dictionary<string, string> ModelErrors
        {
            get
            {
                if (modelErrors == null)
                    modelErrors = new Dictionary<string, string>();
                return modelErrors;
            }
            private set
            {
                modelErrors = value;
            }
        }
        public T ConvertTo<T>() where T : BaseStrategyResponse, new()
        {
            return new T
            {
                Success = this.Success,
                Exception = this.Exception,
                Message = this.Message,
                ModelErrors = this.ModelErrors
            };
        }
    }
    public class BaseStrategyResponse<TData> : BaseStrategyResponse
    {
        public TData Data { get; set; }
    }
}
