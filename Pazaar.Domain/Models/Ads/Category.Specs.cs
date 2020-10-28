using FluentAssertions;
using System;
using Xunit;

namespace Pazaar.Domain.Models.Ads
{
    using static ModelConstants.Category;
    public class CategorySpecs
    {
        [Fact]
        public void CreateCategoryWitEmptyName_Should_ThrowException()
        {
            // Act
            Action act = () => new Category("");

            // Assert
            act.Should().Throw<ArgumentException>().WithMessage("Please add a category name");
        }

        [Fact]
        public void InvalidCategoryNameLength_Should_ThrowException()
        {
            // Act
            Action act = () => new Category("No");

            // Assert
            act.Should().Throw<ArgumentException>()
                .WithMessage($"Name must be between {TitleMinLength} and {TitleMaxLength} characters");
        }
    }
}
