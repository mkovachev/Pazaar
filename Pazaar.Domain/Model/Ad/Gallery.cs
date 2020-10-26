using Pazaar.Domain.Common;
using System.Collections.Generic;

namespace Pazaar.Domain.Model.Ad
{
    public class Gallery : AuditEntity
    {
        public IReadOnlyCollection<Image> Images { get; set; } = new List<Image>();

    }
}
