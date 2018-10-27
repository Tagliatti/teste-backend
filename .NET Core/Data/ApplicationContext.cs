using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TesteBackend.Models;

namespace TesteBackend.Data
{
    public partial class ApplicationContext : DbContext
    {
        public DbSet<Veiculo> Veiculos { get; set; }

        public ApplicationContext()
        {
        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var entities = ChangeTracker
                .Entries()
                .Where(x => (x.State == EntityState.Added || x.State == EntityState.Modified));

            var now = DateTime.Now;

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added) 
                {
                    entity.Property("Created").CurrentValue = now;
                }

                entity.Property("Updated").CurrentValue = now;
            }

            return await base.SaveChangesAsync();
        }
    }
}
