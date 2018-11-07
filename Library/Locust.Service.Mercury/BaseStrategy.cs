using Locust.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Service.Mercury
{
    public abstract class BaseStrategy<TReq, TRes>
        where TReq : BaseStrategyRequest
        where TRes : BaseStrategyResponse, new()
    {
        public IExceptionLogger Logger { get; set; }
        public virtual TRes Invoke(TReq request)
        {
            var result = new TRes();

            try
            {
                InvokeInternal(request, result);
            }
            catch (Exception e)
            {
                Logger.LogException(e, this.ToString());
                result.Exception = e;
            }

            return result;
        }
        protected virtual void InvokeInternal(TReq request, TRes response) { }
        public IService Service { get; private set; }
        public BaseStrategy(IExceptionLogger logger, IService service)
        {
            Logger = logger;
            Service = service;
        }
    }
}
