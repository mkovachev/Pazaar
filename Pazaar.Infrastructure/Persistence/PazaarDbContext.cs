using Microsoft.EntityFrameworkCore;
using Pazaar.Domain.Model.Users;
using Pazaar.Domain.Models.Ads;
using System.Reflection;

namespace Pazaar.Infrastructure.Persistence
{
    internal class PazaarDbContext : DbContext
    {
        public PazaarDbContext(DbContextOptions<PazaarDbContext> options) : base(options)
        {
        }

        public DbSet<Ad> Ads { get; set; } = default!;
        public DbSet<Category> Categories { get; set; } = default!;
        public DbSet<Gallery> Galerries { get; set; } = default!;
        public DbSet<Image> Images { get; set; } = default!;
        public DbSet<User> Users { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
