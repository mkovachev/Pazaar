using Pazaar.Domain.Common;
using System.Collections.Generic;
using System.Linq;

namespace Pazaar.Domain.Models.Ads
{
    public class Gallery : AuditEntity
    {
        public IReadOnlyCollection<Image> Images => this.Images.ToList().AsReadOnly();

    }
}
