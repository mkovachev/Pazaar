using Bogus;
using FakeItEasy;
using FluentAssertions;
using Pazaar.Domain.Exceptions;
using System;
using Xunit;

namespace Pazaar.Domain.Models.Ads
{
    public class AdTests
    {
        [Fact]
        public void CreateAdWitEmptyTitle_Should_ThrowException()
        {
            // Act
            Action act = () => new Ad("", 1000.00M, "some valid description");

            // Assert
            act.Should().Throw<InvalidAdException>();
        }

        [Fact]
        public void CreateAdWithInvalidTitleMinLength_Should_ThrowException()
        {
            // Act
            Action act = () => new Ad("Invalid", 1000.00M, "some valid description");

            // Assert
            act.Should().Throw<InvalidAdException>();
        }

        [Fact]
        public void CreateAdWithInvalidTitleMaxLength_Should_ThrowException()
        {
            // Act
            Action act = () => new Ad("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx", 1000.00M, "some valid description");

            // Assert
            act.Should().Throw<InvalidAdException>();
        }

        [Fact]
        public void CreateAdWithInvalidPriceFormat_Should_ThrowException()
        {
            // Act
            Action act = () => new Ad("Selling my Audi", 1, "some valid description");

            // Assert
            act.Should().Throw<InvalidAdException>();
        }

        [Fact]
        public void CreateAdWithInvalidPrice_Should_ThrowException()
        {
            // Act
            Action act = () => new Ad("Selling my Audi", -100, "some valid description");

            // Assert
            act.Should().Throw<InvalidAdException>();
        }

        [Fact]
        public void CreateAdWitEmptyDescription_Should_ThrowException()
        {
            // Act
            Action act = () => new Ad("Selling my Audi", 1000.00M, "");

            // Assert
            act.Should().Throw<InvalidAdException>();
        }

        [Fact]
        public void CreateAdWithInvalidDescriptionMinLength_Should_ThrowException()
        {
            // Act
            Action act = () => new Ad("Selling my Audi", 1000.00M, "invalid description");

            // Assert
            act.Should().Throw<InvalidAdException>();
        }

        [Fact]
        public void CreateAdWithInvalidDescriptionMaxLength_Should_ThrowException()
        {
            // Act
            Action act = () => new Faker<Ad>()
                            .CustomInstantiator(f => new Ad(
                                f.Random.String(10),
                                f.Random.Number(1, 100),
                                f.Random.String(300)))
                            .Generate();

            // Assert
            act.Should().Throw<InvalidAdException>();
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
        public void UpdateDescriptionWithInvalidMinLength_Should_ThrowException()
        {
            // Arrange
            var ad = A.Dummy<Ad>();

            // Act
            Action act = () => ad.UpdateDescription("tooshort");

            // Assert
            act.Should().Throw<InvalidAdException>();
        }

        [Fact]
        public void UpdateDescriptionWithInvalidMaxLength_Should_ThrowException()
        {
            // Arrange
            var ad = A.Dummy<Ad>();

            // Act
            Action act = () => ad.UpdateDescription("too long xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");

            // Assert
            act.Should().Throw<InvalidAdException>();
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
        public void AddCategory_Should_Add_Category()
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
        public void DeleteCategory_Should_Remove_Category()
        {
            // Arrange
            var ad = A.Dummy<Ad>();
            ad.AddCategory(new Category("Pets"));

            // Act
            ad.DeleteCategory("Pets");

            // Assert
            ad.Categories.Should().BeEmpty();
        }

        [Fact]
        public void AddImage_Should_Add_Image()
        {
            // Arrange
            var ad = A.Dummy<Ad>();
            ad.AddImage(new Image("imageUrl1"));
            ad.AddImage(new Image("imageUrl2"));

            // Assert
            ad.Images.Should().OnlyHaveUniqueItems("imageUrl1", "imageUrl2");
        }


        [Fact]
        public void DeleteImage_Should_Remove_Image()
        {
            // Arrange
            var ad = A.Dummy<Ad>();
            ad.AddImage(new Image("imageUrl"));

            // Act
            ad.DeleteImage("imageUrl");

            // Assert
            ad.Images.Should().BeEmpty();
        }

    }
}
