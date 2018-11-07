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
    public abstract class BaseRecoverByPKStrategyEF<TReq, TRes, TUser, TUserPK, TEntity, TEntityPK, TUserFK> :
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
        public BaseRecoverByPKStrategyEF(IExceptionLogger logger, IUserService<TUser, TUserPK> service) : base(logger, service)
        {
        }
        protected abstract TUserPK GetUserPK(TUserFK fk);
        protected abstract TEntity GetEntityByPK(TEntityPK pk);
        protected override void InvokeInternal(TReq request, TRes response)
        {
            if (DoRecoverByPK(request, response))
            {
                var entity = GetEntityByPK(request.Data);

                entity.CreatedBy = UserService.Users.Find(GetUserPK(entity.CreatedById));
                entity.ModifiedBy = UserService.Users.GetByUserName(UserService.Users.CurrentUser);
                entity.ModifiedDate = DateTime.Now;

                Service.SaveChanges();

                response.Success = true;
            }
        }
        protected virtual bool DoRecoverByPK(TReq request, TRes response)
        {
            DoRecoverByPK(request.Data);

            return true;
        }
        protected virtual void DoRecoverByPK(TEntityPK pk)
        { }
    }
}
