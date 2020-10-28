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

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is Entity && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            foreach (var entity in entries)
            {
                ((Entity)entity.Entity).ModifiedOn = DateTime.Now;

                if (entity.State == EntityState.Added)
                {
                    ((Entity)entity.Entity).CreatedOn = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
