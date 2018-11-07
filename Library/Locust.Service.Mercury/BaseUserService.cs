using Locust.Logging;
using Locust.Repository.EF;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Service.Mercury
{
    public class BaseUserService<TUser, TUserPK> : BaseAbstractServiceEF, IUserService<TUser, TUserPK>
        where TUser : IUser<TUserPK>
    {
        public IUserRepository<TUser, TUserPK> Users { get; set; }
        public BaseUserService(IExceptionLogger logger, DbContext context, IUserRepository<TUser, TUserPK> userRepo) : base(logger, context)
        {
            Users = userRepo;

            (Users as BaseRepositoryEF).Context = Context;
        }
        protected override void SetContext(DbContext value)
        {
            base.SetContext(value);

            (Users as BaseRepositoryEF).Context = value;
        }
    }
}
