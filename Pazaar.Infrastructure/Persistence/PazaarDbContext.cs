using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pazaar.Application.Interfaces;
using Pazaar.Domain.Common;
using Pazaar.Domain.Model.Customer;
using Pazaar.Domain.Models.Ads;
using Pazaar.Infrastructure.Identity;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Pazaar.Infrastructure.Persistence
{
    public class PazaarDbContext : IdentityDbContext<User>, IPazaarDbContext
    {
        private readonly ICurrentUser userService;
        private readonly IDateTime dateTime;
        public PazaarDbContext(DbContextOptions<PazaarDbContext> options,
            IDateTime dateTime, ICurrentUser userService)
            : base(options)
        {
            this.dateTime = dateTime;
            this.userService = userService;
        }

        public DbSet<Ad> Ads { get; set; } = default!;
        public DbSet<Category> Categories { get; set; } = default!;
        public DbSet<Gallery> Galleries { get; set; } = default!;
        public DbSet<Image> Images { get; set; } = default!;
        public DbSet<Customer> Customers { get; set; } = default!;

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var filtered =
                ChangeTracker
                .Entries<AuditableEntity>()
                .Where(e => e.Entity is AuditableEntity && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified)
                        || e.State == EntityState.Deleted);

            foreach (var entry in filtered)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = userService.UserId;
                        entry.Entity.CreatedOn = dateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = userService.UserId;
                        entry.Entity.ModifiedOn = dateTime.Now;
                        break;
                    case EntityState.Deleted:
                        entry.Entity.DeleteBy = userService.UserId;
                        entry.Entity.DeletedOn = dateTime.Now;
                        entry.Entity.IsDeleted = true;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
