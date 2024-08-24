using Domain;

using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class AppDbContext : DbContext//, IAppDbContext
    {
        public DbSet<Employee> Employees { get; set; } = null!;

        public AppDbContext(DbContextOptions<AppDbContext> options)
          : base(options)
        {
            //this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Employee>(e =>
            {
                e.HasKey(e => e.Id);
            });

            base.OnModelCreating(builder);
        }
    }
}
