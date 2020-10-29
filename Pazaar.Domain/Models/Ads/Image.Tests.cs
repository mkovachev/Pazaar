using FluentAssertions;
using System;
using Xunit;

namespace Pazaar.Domain.Models.Ads
{
    using static ModelConstants.Image;
    public class ImageTests
    {
        [Fact]
        public void CreateImageWitEmptyTitle_Should_ThrowException()
        {
            // Act
            Action act = () => new Image("", "url");

            // Assert
            act.Should().Throw<ArgumentException>().WithMessage("Please add a image name");
        }

        [Fact]
        public void CreateImageWithInvalidNameLength_Should_ThrowException()
        {
            // Act
            Action act = () => new Image("xx", "url");

            // Assert
            act.Should().Throw<ArgumentException>()
                .WithMessage($"Name must be between {ImageUrlMinLength} and {ImageUrlMaxLength} characters");
        }
    }
}
