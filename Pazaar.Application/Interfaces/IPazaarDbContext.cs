using Microsoft.EntityFrameworkCore;
using Pazaar.Domain.Models.Ads;
using System.Threading;
using System.Threading.Tasks;

namespace Pazaar.Application.Interfaces
{
    public interface IPazaarDbContext
    {
        public DbSet<Ad> Ads { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<Image> Images { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
