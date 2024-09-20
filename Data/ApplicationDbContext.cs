using CanamRegister.Entity;
using Microsoft.EntityFrameworkCore;

namespace CanamRegister.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Define DbSets for your entities
        public DbSet<Customer> Customer { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

       
    }
}
