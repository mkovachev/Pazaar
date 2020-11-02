using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Pazaar.Application.Features.Ads;
using Pazaar.Application.Features.Ads.Queries;
using Pazaar.Application.Interfaces;
using Pazaar.Domain.Models.Ads;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Pazaar.Infrastructure.Persistence.Repositories
{
    internal class AdRepository : IAdRepository, IRepository<Ad>
    {
        private readonly IMapper mapper;
        private readonly PazaarDbContext db;

        public AdRepository(IMapper mapper, PazaarDbContext db)
        {
            this.mapper = mapper;
            this.db = db;
        }

        public async Task<Ad> Find(int id, CancellationToken cancellationToken = default)
            => await this.db.Ads.FirstOrDefaultAsync(ad => ad.Id == id, cancellationToken: cancellationToken);

        public async Task<AdDetailsOutputModel> GetDetails(int id, CancellationToken cancellationToken = default)
            => await this.db.Ads
                    .Where(ad => ad.Id == id)
                    .ProjectTo<AdDetailsOutputModel>(this.mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(cancellationToken);

        public async Task<IEnumerable<Category>> GetCategories(int id, CancellationToken cancellationToken = default)
             => await this.db.Ads
                        .Where(ad => ad.Id == id)
                        .SelectMany(ad => ad.Categories)
                        .ToListAsync(cancellationToken);

        public async Task Save(Ad entity, CancellationToken cancellationToken = default)
        {
            this.db.Update(entity);

            await this.db.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken = default)
        {
            var ad = await this.db.Ads.FindAsync(id, cancellationToken);

            if (ad == null)
            {
                return false;
            }

            this.db.Remove(ad);

            await this.db.SaveChangesAsync(cancellationToken);

            return true;
        }

    }
}
