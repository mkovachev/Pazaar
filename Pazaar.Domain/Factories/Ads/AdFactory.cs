using Pazaar.Domain.Models.Ads;
using System.Collections.Generic;

namespace Pazaar.Domain.Factories.Ads
{
    internal class AdFactory : IAdFactory
    {
        private string title = default!;
        private decimal price = default!;
        private string description = default!;
        private Gallery gallery = default!;

        private IReadOnlyCollection<Category> categories = new List<Category>().AsReadOnly();

        public Ad Build() => new Ad(this.title, this.gallery, this.price, this.description);

        public IAdFactory WithCategories(IReadOnlyCollection<Category> categories)
        {
            this.categories = categories;
            return this;
        }

        public IAdFactory WithDescription(string description)
        {
            this.description = description;
            return this;
        }

        public IAdFactory WithGallery(Gallery gallery)
        {
            this.gallery = gallery;
            return this;
        }

        public IAdFactory WithPrice(decimal price)
        {
            this.price = price;
            return this;
        }

        public IAdFactory WithTitle(string title)
        {
            this.title = title;
            return this;
        }
    }
}
