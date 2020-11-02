using FakeItEasy;
using FluentAssertions;
using System;
using Xunit;

namespace Pazaar.Domain.Models.Ads
{
    using static ModelConstants.Ad;
    public class AdTests
    {
        [Fact]
        public void CreateCategoryWitEmptyTitle_Should_ThrowException()
        {
            // Act
            Action act = () => new Ad("", 1000.00M, "some valid description");

            // Assert
            act.Should().Throw<ArgumentException>().WithMessage("Please add a title");
        }

        [Fact]
        public void CreateCategoryWithInvalidTitleLength_Should_ThrowException()
        {
            // Act
            Action act = () => new Ad("Invalid", 1000.00M, "some valid description");

            // Assert
            act.Should().Throw<ArgumentException>()
                .WithMessage($"Title must be between {TitleMinLength} and {TitleMaxLength} characters");
        }

        [Fact]
        public void CreateCategoryWithInvalidPriceFormat_Should_ThrowException()
        {
            // Act
            Action act = () => new Ad("Selling my Audi", 1, "some valid description");

            // Assert
            act.Should().Throw<ArgumentException>().WithMessage("Price must have exact 2-digits after the decimal point");
        }

        [Fact]
        public void CreateCategoryWithInvalidPrice_Should_ThrowException()
        {
            // Act
            Action act = () => new Ad("Selling my Audi", -100, "some valid description");

            // Assert
            act.Should().Throw<ArgumentException>()
                .WithMessage($"Price must be between {MinPrice} and {MaxPrice}");
        }

        [Fact]
        public void UpdateTitle_Should_UpdateTitle()
        {
            // Arrange
            var ad = A.Dummy<Ad>();

            // Act
            ad.UpdateTitle("updated Title");

            // Assert
            ad.Title.Should().Be("updated Title");
        }

        [Fact]
        public void UpdateDescriptionWithInvalidLength_Should_ThrowException()
        {
            // Arrange
            var ad = A.Dummy<Ad>();

            // Act
            Action act = () => ad.UpdateDescription("invalid description");

            // Assert
            act.Should().Throw<ArgumentException>().WithMessage($"Description must be between {DescriptionMinLength} and {DescriptionMaxLength} characters");
        }

        [Fact]
        public void UpdateDescription_Should_UpdateDescription()
        {
            // Arrange
            var ad = A.Dummy<Ad>();

            // Act
            ad.UpdateDescription("some valid description");

            // Assert
            ad.Description.Should().Be("some valid description");
        }

        [Fact]
        public void UpdatePrice_Should_UpdatePrice()
        {
            // Arrange
            var ad = A.Dummy<Ad>();

            // Act
            ad.UpdatePrice(2000.00M);

            // Assert
            ad.Price.Should().Be(2000.00M);
        }

        [Fact]
        public void ChangeIsActive_Should_Change_IsActive()
        {
            // Arrange
            var ad = A.Dummy<Ad>();

            // Act
            ad.ChangeIsActive();

            // Assert
            ad.IsActive.Should().BeFalse();
        }

        [Fact]
        public void AddCategory_Should_Add_Category_Into_Categories()
        {
            // Arrange
            var ad = A.Dummy<Ad>();

            // Act
            ad.AddCategory(new Category("Pets"));
            ad.AddCategory(new Category("Cars"));

            // Assert
            ad.Categories.Should().OnlyHaveUniqueItems("Pets", "Cars");
        }

        [Fact]
        public void DeleteCategory_Should_Remove_Category_From_Categories()
        {
            // Arrange
            var ad = A.Dummy<Ad>();
            ad.AddCategory(new Category("Pets"));

            // Act
            ad.DeleteCategory(new Category("Pets"));

            // Assert
            ad.Categories.Should().BeEmpty();
        }

    }
}
