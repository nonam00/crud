using Domain;

using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    // Shouldn't be on this layer

    public class AppDbContext : DbContext//, IAppDbContext
    {
        public DbSet<Employee> Employees { get; set; } = null!;

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
