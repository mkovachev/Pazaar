using System;
using System.Collections.Generic;

namespace Pazaar.Domain.Models.Ads
{
    public class CategoryType
    {
        public Type EntityType => typeof(Category);

        public IReadOnlyCollection<Category> Categories()
            => new HashSet<Category>
            {
                new Category("Real Estate"),
                new Category("Cars"),
                new Category("Electronics"),
                new Category("Sport"),
                new Category("Pets"),
                new Category("Home"),
                new Category("Men Clothing"),
                new Category("Men Shoes"),
                new Category("Men Accessories"),
                new Category("Men Bags"),
                new Category("Women Clothing"),
                new Category("Women Shoes"),
                new Category("Women Accessories"),
                new Category("Women Bags"),
                new Category("Kids Girls Clothing"),
                new Category("Kids Girls Shoes"),
                new Category("Kids Girls Accessories"),
                new Category("Kids Girls Bags"),
                new Category("Kids Boys Clothing"),
                new Category("Kids Boys Shoes"),
                new Category("Kids Boys Accessories"),
                new Category("Kids Boys Bags"),
                new Category("Babies"),
                new Category("Holiday"),
                new Category("Services"),
                new Category("Business"),
                new Category("Jobs")
            };
    }
}
