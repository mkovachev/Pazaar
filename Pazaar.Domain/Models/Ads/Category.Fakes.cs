using FakeItEasy;
using System;

namespace Pazaar.Domain.Models.Ads
{
    public class CategoryFakes
    {
        public const string ValidCategoryName = "Cars";

        public class CategoryDummyFactory : IDummyFactory
        {
            public bool CanCreate(Type type) => type == typeof(Category);

            public object? Create(Type type) => new Category(ValidCategoryName);

            public Priority Priority => Priority.Default;
        }
    }
}
