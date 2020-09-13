using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PersonalAccountant.Entities;

namespace PersonalAccountant.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<TransactionEntity> Transactions { get; set; }
        public DbSet<TypeEntity> Types { get; set; }
    }
}
