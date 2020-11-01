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

        Task GetDetails(int id, CancellationToken cancellationToken = default);

        Task<Gallery> GetGallery(
            string gallery,
            CancellationToken cancellationToken = default);

        Task<IEnumerable<Category>> GetAdCategories(CancellationToken cancellationToken = default);

        Task<bool> Delete(int id, CancellationToken cancellationToken = default);

    }
}
