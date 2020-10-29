using Pazaar.Domain.Common;
using System.Collections.Generic;
using System.Linq;

namespace Pazaar.Domain.Models.Ads
{
    public class Gallery : AuditableEntity
    {
        public int Id { get; }
        public IList<Image> Images { get; } = new List<Image>().AsReadOnly();

        public void AddImage(Image image)
        {
            var imageName = image.Name;

            if (this.Images.Any(i => i.Name == imageName))
            {
                return;
            }

            this.Images.Add(image);
        }

        public void DeleteImage(Image image)
        {
            var imageName = image.Name;

            if (this.Images.Any(i => i.Name == imageName))
            {
                this.Images.Remove(image);
            }
        }
    }
}
