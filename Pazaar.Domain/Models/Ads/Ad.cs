using Pazaar.Domain.Common;
using Pazaar.Domain.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace Pazaar.Domain.Models.Ads
{
    using static ModelConstants.Ad;

    public class Ad : AuditableEntity, IAggregateRoot
    {
        private readonly HashSet<Category> categories;
        private readonly HashSet<Image> images;

        internal Ad(string title, decimal price, string description)
        {
            ValidateTitle(title);
            ValidatePrice(price);
            ValidateDescription(description);

            this.Title = title;
            this.Price = price;
            this.Description = description;
            this.categories = new HashSet<Category>();
            this.images = new HashSet<Image>(); ;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public decimal Price { get; private set; }
        public string Description { get; private set; }
        public bool IsActive { get; private set; } = true;
        public IReadOnlyCollection<Image> Images => this.images.ToList().AsReadOnly();
        public IReadOnlyCollection<Category> Categories => this.categories.ToList().AsReadOnly();

        public void AddImage(Image image)
        {
            if (!this.images.Any(i => i.Url == image.Url))
            {
                this.images.Add(image);
            }
        }

        public void DeleteImage(string imageUrl)
        {
            var image = this.images.FirstOrDefault(i => i.Url == imageUrl);

            if (image != null)
            {
                this.images.Remove(image);
            }
        }

        public void AddCategory(Category category)
        {
            if (!this.categories.Any(c => c.Name == category.Name))
            {
                this.categories.Add(category);
            }
        }

        public void DeleteCategory(string categoryName)
        {
            var category = this.categories.FirstOrDefault(c => c.Name == categoryName);

            if (category != null)
            {
                this.categories.Remove(category);
            }
        }

        public Ad UpdateTitle(string title)
        {
            ValidateTitle(title);
            this.Title = title;

            return this;
        }

        public Ad UpdateDescription(string description)
        {
            ValidateDescription(description);
            this.Description = description;

            return this;
        }

        public Ad UpdatePrice(decimal price)
        {
            ValidatePrice(price);
            this.Price = price;

            return this;
        }

        public Ad ChangeIsActive()
        {
            this.IsActive = !this.IsActive;

            return this;
        }


        // Validations
        private void ValidateTitle(string title)
        {
            Guard.ForStringLength<InvalidAdException>(title, TitleMinLength, TitleMaxLength);
        }

        private void ValidatePrice(decimal price)
        {
            Guard.AgainstDecimalOutOfRange<InvalidAdException>(price, MinPrice, MaxPrice);
        }

        private void ValidateDescription(string description)
        {
            Guard.ForStringLength<InvalidAdException>(description, DescriptionMinLength, DescriptionMaxLength);
        }
    }
}
