using Pazaar.Domain.Common;
using System.Collections.Generic;

namespace Pazaar.Domain.Model.Ad
{
    public class Gallery : EntityAudit
    {
        internal Gallery(IReadOnlyCollection<Image> images)
        {
            this.Images = images;
        }

        public IReadOnlyCollection<Image> Images { get; set; } = new List<Image>();

    }
}
