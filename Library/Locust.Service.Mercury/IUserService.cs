using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Service.Mercury
{
    public interface IUserService<TUser, TUserPK> : IService
        where TUser : IUser<TUserPK>
    {
        IUserRepository<TUser, TUserPK> Users { get; set; }
    }
}
