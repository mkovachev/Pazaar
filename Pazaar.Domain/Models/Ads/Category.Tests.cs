using Bogus;
using FluentAssertions;
using Pazaar.Domain.Exceptions;
using System;
using Xunit;

namespace Pazaar.Domain.Models.Ads
{
    public class CategoryTests
    {
        [Fact]
        public void CreateCategoryWitEmptyName_Should_ThrowException()
        {
            // Act
            Action act = () => new Category("");

            // Assert
            act.Should().Throw<InvalidCategoryException>();
        }

        [Fact]
        public void InvalidCategoryMinNameLength_Should_ThrowException()
        {
            // Act
            Action act = () => new Category("x");

            // Assert
            act.Should().Throw<InvalidCategoryException>();
        }

        [Fact]
        public void InvalidCategoryMaxNameLength_Should_ThrowException()
        {
            // Act
            Action act = () => new Faker<Category>()
                                .CustomInstantiator(f => new Category(f.Random.String(35)))
                                .Generate();

            // Assert
            act.Should().Throw<InvalidCategoryException>();
        }
    }
}
