using Pazaar.Domain.Models.Ads;
using System.Collections.Generic;

namespace Pazaar.Domain.Factories.Ads
{
    public interface IAdFactory : IFactory<Ad>
    {
        IAdFactory WithTitle(string title);

        IAdFactory WithGallery(Gallery gallery);

        IAdFactory WithPrice(decimal price);

        IAdFactory WithDescription(string description);

        IAdFactory WithIsActive(bool isActive);

        IAdFactory WithCategories(IReadOnlyCollection<Category> categories);
    }
}
