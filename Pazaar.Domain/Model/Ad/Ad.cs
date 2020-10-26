using Pazaar.Domain.Common;
using System.Collections.Generic;

namespace Pazaar.Domain.Model.Ad
{
    public class Ad : AuditEntity
    {
        internal Ad(IReadOnlyCollection<Category> categories, string titel, Gallery gallery, string description, decimal price, bool isActive)
        {
            this.Categories = categories;
            this.Titel = titel;
            this.Gallery = gallery;
            this.Description = description;
            this.Price = price;
            this.IsActive = isActive;
        }
        public string Titel { get; private set; }
        public IReadOnlyCollection<Category> Categories { get; private set; } = new List<Category>();
        public Gallery Gallery { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public bool IsActive { get; private set; }



    }
}
