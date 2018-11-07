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
    public abstract class BaseCreateStrategyEF<TReq, TRes, TUser, TUserPK, TEntity, TEntityPK, TUserFK> : BaseUserStrategy<TReq, TRes, TUser, TUserPK, TEntity>
        where TReq : BaseStrategyRequest<TEntity>
        where TRes : BaseStrategyResponse, new()
        where TEntity : EntityBase<TEntityPK, TUser, TUserFK>
        where TUser : IUser<TUserPK>
    {
        public IUserService<TUser, TUserPK> UserService
        {
            get { return Service as IUserService<TUser, TUserPK>; }
        }
        public BaseCreateStrategyEF(IExceptionLogger logger, IUserService<TUser, TUserPK> service) : base(logger, service)
        {
        }
        protected override void InvokeInternal(TReq request, TRes response)
        {
            if (DoCreate(request, response))
            {
                request.Data.CreatedBy = UserService.Users.GetByUserName(UserService.Users.CurrentUser);

                Service.SaveChanges();

                response.Success = true;
            }
        }
        protected virtual bool DoCreate(TReq request, TRes response)
        {
            DoCreate(request.Data);

            return true;
        }
        protected virtual void DoCreate(TEntity data)
        { }
    }
}
