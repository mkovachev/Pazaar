using FluentAssertions;
using System;
using Xunit;

namespace Pazaar.Domain.Models.Ads
{
    public class CategorySpecs
    {
        [Fact]
        public void CategoryWithoutName_Should_Throw_ArgumentNullException()
        {
            // Act
            Action act = () => new Category("");

            // Assert
            act.Should().Throw<ArgumentNullException>().WithMessage("Please add category name");
        }

        [Fact]
        public void InvalidCategoryNameLenght_Should_Throw_Exception()
        {
            // Act
            Action act = () => new Category("");

            // Assert
            act.Should().Throw<ArgumentException>()
                .WithMessage($"Name must be between 5 and 30 characters");
        }
    }
}
