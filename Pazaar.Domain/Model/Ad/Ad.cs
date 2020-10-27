using Pazaar.Domain.Common;
using System.Collections.Generic;
using System.Linq;

namespace Pazaar.Domain.Model.Ad
{
    public class Ad : AuditEntity
    {
        public Ad(IReadOnlyCollection<Category> categories, string title, Gallery gallery, string description, decimal price, bool isActive)
        {
            this.Categories = categories;
            this.Title = title;
            this.Gallery = gallery;
            this.Description = description;
            this.Price = price;
            this.IsActive = isActive;
        }
        public string Title { get; private set; }
        public IReadOnlyCollection<Category> Categories => this.Categories.ToList().AsReadOnly();
        public Gallery Gallery { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public bool IsActive { get; private set; }

        private Ad UpdateTitle(string title)
        {
            this.Title = title;

            return this;
        }

        private Ad UpdateDescription(string description)
        {
            this.Description = description;

            return this;
        }

        private Ad UpdatePrice(decimal price)
        {
            this.Price = price;

            return this;
        }

        private Ad ChangeIsActive()
        {
            this.IsActive = !this.IsActive;

            return this;
        }

    }
}
