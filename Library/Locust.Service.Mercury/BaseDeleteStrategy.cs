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
    public abstract class BaseDeleteStrategyEF<TReq, TRes, TUser, TUserPK, TEntity, TEntityPK, TUserFK> : BaseUserStrategy<TReq, TRes, TUser, TUserPK, TEntity>
        where TReq : BaseStrategyRequest<TEntity>
        where TRes : BaseStrategyResponse, new()
        where TEntity : EntityBase<TEntityPK, TUser, TUserFK>
        where TUser : IUser<TUserPK>
    {
        public IUserService<TUser, TUserPK> UserService
        {
            get { return Service as IUserService<TUser, TUserPK>; }
        }
        public BaseDeleteStrategyEF(IExceptionLogger logger, IUserService<TUser, TUserPK> service) : base(logger, service)
        {
        }
        protected override void InvokeInternal(TReq request, TRes response)
        {
            if (DoDelete(request, response))
            {
                Service.SaveChanges();

                response.Success = true;
            }
        }
        protected virtual bool DoDelete(TReq request, TRes response)
        {
            DoDelete(request.Data);

            return true;
        }
        protected virtual void DoDelete(TEntity data)
        { }
    }
}
