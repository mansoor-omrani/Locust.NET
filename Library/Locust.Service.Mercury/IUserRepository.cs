using Locust.Repository;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Service.Mercury
{
    public interface IUserRepository<TUser, TUserPK> : IRepository<TUser, TUserPK> where TUser : IUser<TUserPK>
    {
        TUser GetByUserName(string username);
        Task<TUser> GetByUserNameAsync(string username);
        TUser GetByEmail(string email);
        string CurrentUser { get; }
    }
}
