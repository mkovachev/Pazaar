using Pazaar.Domain.Common;
using System.Collections.Generic;
using System.Linq;

namespace Pazaar.Domain.Models.Ads
{
    public class Gallery : AuditableEntity
    {
        private readonly HashSet<Image> images;

        public Gallery()
        {
            this.images = new HashSet<Image>();
        }

        public int Id { get; private set; }
        public IReadOnlyCollection<Image> Images => this.Images.ToList().AsReadOnly();

        public void AddImage(Image image)
        {
            var imageName = image.Name;

            if (this.images.Any(i => i.Name == imageName))
            {
                return;
            }

            this.images.Add(image);
        }

        public void DeleteImage(Image image)
        {
            var imageName = image.Name;

            if (this.images.Any(i => i.Name == imageName))
            {
                this.images.Remove(image);
            }
        }
    }
}
