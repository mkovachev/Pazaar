using Pazaar.Domain.Models.Ads;

namespace Pazaar.Domain.Factories.Ads
{
    public interface IAdFactory : IFactory<Ad>
    {
        IAdFactory WithTitle(string title);
        IAdFactory WithPrice(decimal price);
        IAdFactory WithDescription(string description);
    }
}
