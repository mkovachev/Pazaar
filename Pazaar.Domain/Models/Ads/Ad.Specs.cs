using FakeItEasy;
using FluentAssertions;
using System;
using Xunit;

namespace Pazaar.Domain.Models.Ads
{
    public class AdSpecs
    {
        [Fact]
        public void CreateCategoryWitEmptyTitle_Should_Throw_ArgumentException()
        {
            // Act
            Action act = () => new Ad("", new Gallery(), 1000.00M);

            // Assert
            act.Should().Throw<ArgumentException>().WithMessage("Please add a category name");
        }

        [Fact]
        public void CreateCategoryWithInvalidTitleLength_Should_Throw_ArgumentException()
        {
            // Act
            Action act = () => new Ad("Invalid", new Gallery(), 1000.00M);

            // Assert
            act.Should().Throw<ArgumentException>().WithMessage("Title must be between 10 and 70 characters");
        }

        [Fact]
        public void CreateCategoryWithInvalidPriceFormat_Should_Throw_ArgumentException()
        {
            // Act
            Action act = () => new Ad("Selling my Audi", new Gallery(), 1);

            // Assert
            act.Should().Throw<ArgumentException>().WithMessage("Price must have exact 2-digits after the decimal point");
        }

        [Fact]
        public void CreateCategoryWithInvalidPrice_Should_Throw_ArgumentException()
        {
            // Act
            Action act = () => new Ad("Selling my Audi", new Gallery(), -100);

            // Assert
            act.Should().Throw<ArgumentException>().WithMessage("Price must be between 0.1M and 500000000.00M");
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
            ad.UpdateDescription("invalid description");

            // Assert
            ad.Description.Should().BeEmpty();
        }

        [Fact]
        public void UpdateDescription_Should_UpdateDescription()
        {
            // Arrange
            var ad = A.Dummy<Ad>();

            // Act
            ad.UpdateDescription("my updated description");

            // Assert
            ad.Description.Should().Be("my updated description");
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
        public void AddCategory_Should_Add_Category_In_Ad_CategoryList()
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
        public void DeleteCategory_Should_Remove_Category_From_Ad_CategoryList()
        {
            // Arrange
            var ad = A.Dummy<Ad>();

            var category = new Category("Pets");

            // Act
            ad.DeleteCategory(new Category("Pets"));

            // Assert
            ad.Categories.Should().BeEmpty();
        }

    }
}
