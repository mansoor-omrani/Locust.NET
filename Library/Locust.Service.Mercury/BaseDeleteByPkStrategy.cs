using Locust.Logging;
using Locust.Repository.EF;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Service.Mercury
{
    public abstract class BaseDeleteByPKStrategyEF<TReq, TRes, TUser, TUserPK, TEntity, TEntityPK, TUserFK> :
        BaseUserStrategy<TReq, TRes, TUser, TUserPK, TEntityPK>
        where TReq : BaseStrategyRequest<TEntityPK>
        where TRes : BaseStrategyResponse, new()
        where TEntity : EntityBase<TEntityPK, TUser, TUserFK>
        where TUser : IUser<TUserPK>
    {
        public IUserService<TUser, TUserPK> UserService
        {
            get { return Service as IUserService<TUser, TUserPK>; }
        }
        public BaseDeleteByPKStrategyEF(IExceptionLogger logger, IUserService<TUser, TUserPK> service) : base(logger, service)
        {
        }
        protected override void InvokeInternal(TReq request, TRes response)
        {
            if (DoDeleteByPK(request, response))
            {
                Service.SaveChanges();

                response.Success = true;
            }
        }
        protected virtual bool DoDeleteByPK(TReq request, TRes response)
        {
            DoDeleteByPK(request.Data);

            return true;
        }
        protected virtual void DoDeleteByPK(TEntityPK pk)
        { }
    }
}
