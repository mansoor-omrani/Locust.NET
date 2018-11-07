using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Locust.AspNet.Identity.Service;

namespace Locust.AspNet.Identity.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser<int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim> 
    {
			 public virtual bool IsLegalUser { get; set; } 
                		 public virtual ICollection<Person> Person { get; set; }
                		   public virtual ICollection<Company> Company { get; set; }
                		public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser, int> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
	public class ApplicationUserRole : IdentityUserRole<int>
	{
			public virtual string Title { get; set; }
					} 
	public class ApplicationUserClaim : IdentityUserClaim<int> { } 
	public class ApplicationUserLogin : IdentityUserLogin<int> { } 

	public class ApplicationRole : IdentityRole<int, ApplicationUserRole> 
	{ 
		public ApplicationRole() { } 
		public ApplicationRole(string name) { Name = name; } 
	} 

	public class ApplicationUserStore : UserStore<ApplicationUser, ApplicationRole, int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim> 
	{ 
		public ApplicationUserStore(ApplicationDbContext context): base(context) 
		{ } 
	} 

	public class ApplicationRoleStore : RoleStore<ApplicationRole, int, ApplicationUserRole> 
	{ 
		public ApplicationRoleStore(ApplicationDbContext context) : base(context) 
		{ } 
	} 
}
