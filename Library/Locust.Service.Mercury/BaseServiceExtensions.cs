using Locust.Repository;
using Locust.Repository.EF;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Service.Mercury
{
    public static class BaseServiceExtensions
    {
        public static BaseStrategyResponse Invoke<TReq, TRes, TModel>(this BaseStrategy<TReq, TRes> strategy, TModel model)
            where TReq : BaseStrategyRequest<TModel>, new()
            where TRes : BaseStrategyResponse, new()
        {
            var request = new TReq();

            request.Data = model;

            return strategy.Invoke(request);
        }
    }
}
