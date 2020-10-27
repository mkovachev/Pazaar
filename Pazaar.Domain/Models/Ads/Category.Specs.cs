using FluentAssertions;
using System;
using Xunit;

namespace Pazaar.Domain.Models.Ads
{
    public class CategorySpecs
    {
        [Fact]
        public void CreateCategoryWitEmptyName_Should_Throw_ArgumentException()
        {
            // Act
            Action act = () => new Category("");

            // Assert
            act.Should().Throw<ArgumentException>().WithMessage("Please add a category name");
        }

        [Fact]
        public void InvalidCategoryNameLength_Should_Throw_Exception()
        {
            // Act
            Action act = () => new Category("No");

            // Assert
            act.Should().Throw<ArgumentException>()
                .WithMessage($"Name must be between 5 and 30 characters");
        }
    }
}
