using Pazaar.Domain.Common;
using System.Collections.Generic;
using System.Linq;

namespace Pazaar.Domain.Models.Ads
{
    public class Ad : AuditableEntity, IAggregateRoot
    {
        private readonly HashSet<Category> categories;
        internal Ad(string title, Gallery gallery, decimal price)
        {
            this.Title = title;
            this.Gallery = gallery;
            this.Price = price;
            this.categories = new HashSet<Category>();
        }

        internal Ad(string title, Gallery gallery, decimal price, string description)
        {
            this.Title = title;
            this.Gallery = gallery;
            this.Price = price;
            this.Description = description;
            this.categories = new HashSet<Category>();
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public Gallery Gallery { get; private set; }
        public decimal Price { get; private set; }
        public string Description { get; private set; } = default!;
        public bool IsActive { get; private set; } = true;
        public IReadOnlyCollection<Category> Categories => this.categories.ToList().AsReadOnly();

        public Ad UpdateTitle(string title)
        {
            this.Title = title;

            return this;
        }

        public Ad UpdateDescription(string description)
        {
            this.Description = description;

            return this;
        }

        public Ad UpdatePrice(decimal price)
        {
            this.Price = price;

            return this;
        }

        public Ad ChangeIsActive()
        {
            this.IsActive = !this.IsActive;

            return this;
        }

        public void AddCategory(Category category)
        {
            var categoryName = category.Name;

            if (this.categories.Any(c => c.Name == categoryName))
            {
                return;
            }

            this.categories.Add(category);
        }

        public void DeleteCategory(Category category)
        {
            var categoryName = category.Name;

            if (this.categories.Any(c => c.Name == categoryName))
            {
                this.categories.Remove(category);
            }
        }
    }
}
