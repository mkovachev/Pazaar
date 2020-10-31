using Pazaar.Domain.Models.Ads;
using System.Collections.Generic;

namespace Pazaar.Domain.Common
{
    public interface IInitialAds
    {
        IReadOnlyCollection<Ad> GetInitialAds();
    }
}
