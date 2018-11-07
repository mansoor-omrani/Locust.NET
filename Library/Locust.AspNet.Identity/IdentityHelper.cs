
using Microsoft.AspNet.Identity;
using Locust.AspNet.Identity.Models;
using Locust.AspNet.Identity.Service;

namespace Locust.AspNet.Identity
{
	public static class IdentityHelper
	{
		public static UserManager<ApplicationUser, int> GetUserManager()
		{
			return new ApplicationUserManager(new ApplicationUserStore(new ApplicationDbContext()));
		}
	}
}