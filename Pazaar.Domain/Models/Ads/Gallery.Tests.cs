using FakeItEasy;
using FluentAssertions;
using Xunit;

namespace Pazaar.Domain.Models.Ads
{
    public class GalleryTests
    {
        [Fact]
        public void AddImage_Should_Add_Image_Into_Gallery()
        {
            // Arrange
            var gallery = A.Dummy<Gallery>();

            // Act
            gallery.AddImage(new Image("Image1", "url"));
            gallery.AddImage(new Image("Image2", "url"));

            // Assert
            gallery.Images.Should().OnlyHaveUniqueItems("Image1", "Image2");
        }

        [Fact]
        public void DeleteImage_Should_Remove_Image_From_Gallery()
        {
            // Arrange
            var gallery = A.Dummy<Gallery>();
            gallery.AddImage(new Image("Image1", "url"));

            // Act
            gallery.DeleteImage(new Image("Image1", "url"));

            // Assert
            gallery.Images.Should().BeEmpty();
        }
    }
}
