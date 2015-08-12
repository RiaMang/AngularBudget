using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.Data.Entity;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AngularBudget.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Household> Households { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<BudgetItem> BudgetItems { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Invitation> Invitations { get; set; }

        public DbSet<CategoryType> CategoryTypes { get; set; }

        public async Task<List<BudgetItem>> GetBudgetItems(int HId)
        {
            var HIdParam = new SqlParameter("@HId", HId);
            return await this.Database
                .SqlQuery<BudgetItem>("getBudgetItems @HId", HIdParam).ToListAsync();
        }

        public async Task<List<Household>> GetGroup(int HId)
        {
            var HIdParam = new SqlParameter("@HId", HId);
            return await this.Database
                .SqlQuery<Household>("getGroup @HId", HIdParam).ToListAsync();
        }

        public async Task<List<ApplicationUser>> GetUsers(int HId)
        {
            var HIdParam = new SqlParameter("@HId", HId);
            return await this.Database
                .SqlQuery<ApplicationUser>("getUsers @HId", HIdParam).ToListAsync();
        }

        public async Task<List<Account>> GetAccounts(int HId)
        {
            var HIdParam = new SqlParameter("@HId", HId);
            return await this.Database
                .SqlQuery<Account>("getAccounts @HId", HIdParam).ToListAsync();
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}