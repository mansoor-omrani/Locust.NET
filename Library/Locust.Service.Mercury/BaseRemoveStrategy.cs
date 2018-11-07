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
    public abstract class BaseRemoveStrategyEF<TReq, TRes, TUser, TUserPK, TEntity, TEntityPK, TUserFK> : BaseUserStrategy<TReq, TRes, TUser, TUserPK, TEntity>
        where TReq : BaseStrategyRequest<TEntity>
        where TRes : BaseStrategyResponse, new()
        where TEntity : EntityBase<TEntityPK, TUser, TUserFK>
        where TUser : IUser<TUserPK>
    {
        public IUserService<TUser, TUserPK> UserService
        {
            get { return Service as IUserService<TUser, TUserPK>; }
        }
        public BaseRemoveStrategyEF(IExceptionLogger logger, IUserService<TUser, TUserPK> service) : base(logger, service)
        {
        }
        protected abstract TUserPK GetUserPK(TUserFK fk);
        protected override void InvokeInternal(TReq request, TRes response)
        {
            if (DoRemove(request, response))
            {
                request.Data.CreatedBy = UserService.Users.Find(GetUserPK(request.Data.CreatedById));
                request.Data.ModifiedBy = UserService.Users.GetByUserName(UserService.Users.CurrentUser);
                request.Data.ModifiedDate = DateTime.Now;

                Service.SaveChanges();

                response.Success = true;
            }
        }
        protected virtual bool DoRemove(TReq request, TRes response)
        {
            DoRemove(request.Data);

            return true;
        }
        protected virtual void DoRemove(TEntity data)
        { }
    }
}
