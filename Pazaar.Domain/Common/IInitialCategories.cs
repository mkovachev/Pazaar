using Pazaar.Domain.Models.Ads;
using System.Collections.Generic;

namespace Pazaar.Domain.Common
{
    public interface IInitialCategories
    {
        IReadOnlyCollection<Category> GetInitialCategories();
    }
}
