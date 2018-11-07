using Locust.Logging;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Service.Mercury
{
    public abstract class BaseUserStrategy<TReq, TRes, TUser, TUserPK> : BaseStrategy<TReq, TRes>
        where TReq : BaseStrategyRequest
        where TRes : BaseStrategyResponse, new()
        where TUser : IUser<TUserPK>
    {
        public BaseUserStrategy(IExceptionLogger logger, IUserService<TUser, TUserPK> service) : base(logger, service)
        {
        }
    }
    public abstract class BaseUserStrategy<TReq, TRes, TUser, TUserPK, TEntity> : BaseUserStrategy<TReq, TRes, TUser, TUserPK>
        where TReq : BaseStrategyRequest<TEntity>
        where TRes : BaseStrategyResponse, new()
        where TUser : IUser<TUserPK>
    {
        public BaseUserStrategy(IExceptionLogger logger, IUserService<TUser, TUserPK> service) : base(logger, service)
        { }
    }
}
