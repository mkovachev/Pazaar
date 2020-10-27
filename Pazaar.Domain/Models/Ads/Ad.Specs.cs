using FakeItEasy;
using FluentAssertions;
using Xunit;

namespace Pazaar.Domain.Models.Ads
{
    public class AdSpecs
    {
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
        public void UpdateDescription_Should_UpdateDescription()
        {
            // Arrange
            var ad = A.Dummy<Ad>();

            // Act
            ad.UpdateDescription("updated Description");

            // Assert
            ad.Description.Should().Be("updated Description");
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

            // Assert
            ad.Categories.Should().OnlyHaveUniqueItems("Pets");
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
