using Pazaar.Application.Mapping;
using Pazaar.Domain.Models.Ads;

namespace Pazaar.Application.Features.Ads.Queries.Details
{
    public class AdDetailsOutputModel : IMapFrom<Ad>
    {
        public int Id { get; private set; }
        public string Title { get; private set; } = default!;
        public decimal Price { get; private set; } = default!;
        public string Description { get; private set; } = default!;
        public bool IsActive { get; private set; } = true;
    }
}
