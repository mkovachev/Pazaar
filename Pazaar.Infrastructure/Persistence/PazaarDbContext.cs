using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pazaar.Domain.Common;
using Pazaar.Domain.Models.Ads;
using Pazaar.Infrastructure.Identity;
using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Pazaar.Infrastructure.Persistence
{
    internal class PazaarDbContext : IdentityDbContext<User>
    {
        public PazaarDbContext(DbContextOptions<PazaarDbContext> options) : base(options)
        {
        }

        public DbSet<Ad> Ads { get; set; } = default!;
        public DbSet<Category> Categories { get; set; } = default!;
        public DbSet<Gallery> Galleries { get; set; } = default!;
        public DbSet<Image> Images { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

        public override Task<int> SaveChangesAsync(bool hasSuccess, CancellationToken cancellationToken = default)
        {
            var filtered = ChangeTracker
                .Entries()
                .Where(e => e.Entity is Entity && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified)
                        || e.State == EntityState.Deleted);

            foreach (var entry in filtered)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        ((Entity)entry.Entity).CreatedOn = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        ((Entity)entry.Entity).ModifiedOn = DateTime.Now;
                        break;
                    case EntityState.Deleted:
                        ((Entity)entry.Entity).DeletedOn = DateTime.Now;
                        ((Entity)entry.Entity).IsDeleted = true;
                        break;
                }
            }

            return base.SaveChangesAsync(hasSuccess, cancellationToken);
        }
    }
}
