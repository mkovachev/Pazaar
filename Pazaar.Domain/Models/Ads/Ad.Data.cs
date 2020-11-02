using Pazaar.Domain.Common;
using System.Collections.Generic;

namespace Pazaar.Domain.Models.Ads
{
    internal class AdData : IInitialAds
    {
        public IReadOnlyCollection<Ad> GetInitialAds()
            => new List<Ad>
            {
                 new Ad("Selling my Audi", 10000.00M, "the best audi is for sale"),
                 new Ad("Selling my BWM", 10000.00M, "the best bmw is for sale"),
                 new Ad("Selling my Bentley", 1000000.00M, "the best bentley is for sale")
            };
    }
}
