using Pazaar.Application.Features.Ads.Queries;
using Pazaar.Application.Interfaces;
using Pazaar.Domain.Models.Ads;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Pazaar.Application.Features.Ads
{
    public interface IAdRepository : IRepository<Ad>
    {
        Task<Ad> Find(int id, CancellationToken cancellationToken = default);

        Task<AdDetailsOutputModel> GetDetails(int id, CancellationToken cancellationToken = default);

        Task<IEnumerable<Category>> GetCategories(int id, CancellationToken cancellationToken = default);

        Task<bool> Delete(int id, CancellationToken cancellationToken = default);

    }
}
