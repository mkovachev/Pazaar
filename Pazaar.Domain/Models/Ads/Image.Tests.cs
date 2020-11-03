using Bogus;
using FluentAssertions;
using Pazaar.Domain.Exceptions;
using System;
using Xunit;

namespace Pazaar.Domain.Models.Ads
{
    public class ImageTests
    {
        [Fact]
        public void CreateImageWitEmptyUrl_Should_ThrowException()
        {
            // Act
            Action act = () => new Image("");

            // Assert
            act.Should().Throw<InvalidImageException>();
        }

        [Fact]
        public void CreateImageWithInvalidMinUrlLength_Should_ThrowException()
        {
            // Act
            Action act = () => new Image("x");

            // Assert
            act.Should().Throw<InvalidImageException>();
        }

        [Fact]
        public void CreateImageWithInvalidMaxUrlLength_Should_ThrowException()
        {
            // Act
            Action act = () => new Faker<Image>()
                                .CustomInstantiator(f => new Image(f.Random.String(2050)))
                                .Generate();

            // Assert
            act.Should().Throw<InvalidImageException>();
        }
    }
}
