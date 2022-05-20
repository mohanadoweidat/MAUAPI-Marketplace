using MAUAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MAUAPI.Data
{
    public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        //The DbSet property will tell ef core that we have a table that needs to be created if doesnt exist
        public virtual DbSet<UserAccount> UserAccounts { get; set; }
        public virtual DbSet<UserProducts> UserProducts { get; set; }
         public virtual DbSet<UserOrders> UserOrders { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}
