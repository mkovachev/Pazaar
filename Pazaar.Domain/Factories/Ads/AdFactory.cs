using Pazaar.Domain.Models.Ads;
using System.Collections.Generic;

namespace Pazaar.Domain.Factories.Ads
{
    internal class AdFactory : IAdFactory
    {
        private readonly string title = default!;
        private readonly decimal price = default!;
        private readonly string description = default!;

        private readonly List<Category> categories;
        private readonly List<Image> images;

        public AdFactory()
        {
            this.categories = new List<Category>();
            this.images = new List<Image>(); ;
        }

        public IReadOnlyCollection<Image> Images => this.images.AsReadOnly();
        public IReadOnlyCollection<Category> Categories => this.categories.AsReadOnly();


        public Ad Build() => new Ad(this.title, this.price, this.description);
    }
}
