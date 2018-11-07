
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Locust.AspNet.Identity.Models;

namespace Locust.AspNet.Identity.Service
{
  
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim> 
    {
        public ApplicationDbContext(): base("ConStr")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
		
		            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<ApplicationUser>().ToTable("UserTbl");
            modelBuilder.Entity<ApplicationRole>().ToTable("RoleTbl");
            modelBuilder.Entity<ApplicationUserClaim>().ToTable("UserClaimTbl");
            modelBuilder.Entity<ApplicationUserLogin>().ToTable("UserLoginTbl");
            modelBuilder.Entity<ApplicationUserRole>().ToTable("UserRoleTbl");
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}