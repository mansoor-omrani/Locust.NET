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
    public abstract class BaseEditStrategyEF<TReq, TRes, TUser, TUserPK, TEntity, TEntityPK, TUserFK> : BaseUserStrategy<TReq, TRes, TUser, TUserPK, TEntity>
        where TReq : BaseStrategyRequest<TEntity>
        where TRes : BaseStrategyResponse, new()
        where TEntity : EntityBase<TEntityPK, TUser, TUserFK>
        where TUser : IUser<TUserPK>
    {
        public IUserService<TUser, TUserPK> UserService
        {
            get { return Service as IUserService<TUser, TUserPK>; }
        }
        public BaseEditStrategyEF(IExceptionLogger logger, IUserService<TUser, TUserPK> service) : base(logger, service)
        {
        }
        protected virtual TUserPK GetUserPK(TUserFK fk)
        {
            try
            {
                return (TUserPK)System.Convert.ChangeType(fk, typeof(TUserPK));
            }
            catch
            {
                return default(TUserPK);
            }
        }
        protected override void InvokeInternal(TReq request, TRes response)
        {
            if (DoEdit(request, response))
            {
                request.Data.CreatedBy = UserService.Users.Find(GetUserPK(request.Data.CreatedById));
                request.Data.ModifiedBy = UserService.Users.GetByUserName(UserService.Users.CurrentUser);
                request.Data.ModifiedDate = DateTime.Now;

                Service.SaveChanges();

                response.Success = true;
            }
        }
        protected virtual bool DoEdit(TReq request, TRes response)
        {
            DoEdit(request.Data);

            return true;
        }
        protected virtual void DoEdit(TEntity data)
        { }
    }
}
