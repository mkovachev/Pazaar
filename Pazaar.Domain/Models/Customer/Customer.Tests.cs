using FakeItEasy;
using FluentAssertions;
using Pazaar.Domain.Model.Customer;
using System;
using Xunit;

namespace Pazaar.Domain.Models.Users
{
    using static ModelConstants.Customer;
    public class CustomerTests
    {
        [Fact]
        public void CreateUserWitEmptyName_Should_Throw_ArgumentException()
        {
            // Act
            Action act = () => new Customer("", "john@mail.com");

            // Assert
            act.Should().Throw<ArgumentException>().WithMessage("Please add your name");
        }

        [Fact]
        public void CreateUserWitInvalidNameLength_Should_Throw_ArgumentException()
        {
            // Act
            Action act = () => new Customer("x", "john@mail.com");

            // Assert
            act.Should().Throw<ArgumentException>()
                .WithMessage($"Name must be between {NameMinLength} and {NameMaxLength} characters");
        }

        [Fact]
        public void CreateUserWitInvalidEmail_Should_Throw_ArgumentException()
        {
            // Act
            Action act = () => new Customer("John", "invalid mail");

            // Assert
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void CreateUserWitInvalidPhoneNumber_Should_Throw_ArgumentException()
        {
            // Act
            Action act = () => new Customer("John", "john@mail.com", "invalid phone", "Sofia", "image");

            // Assert
            act.Should().Throw<ArgumentException>()
                .WithMessage("Phone number must start with '+' sign, followed by digits only.");
        }

        [Fact]
        public void CreateUserWitInvalidCity_Should_Throw_ArgumentException()
        {
            // Act
            Action act = () => new Customer("John", "john@mail.com", "+3591234567", "xxx", "image");

            // Assert
            act.Should().Throw<ArgumentException>()
                .WithMessage($"City must be between {CityMinLength} and {CityMaxLength} characters");
        }

        [Fact]
        public void UpdateName_Should_UpdateName()
        {
            // Arrange
            var user = A.Dummy<Customer>();

            // Act
            user.UpdateName("Joe");

            // Assert
            user.Name.Should().Be("Joe");
        }

        [Fact]
        public void UpdateEmail_Should_UpdateEmail()
        {
            // Arrange
            var user = A.Dummy<Customer>();

            // Act
            user.UpdateEmail("test@test.com");

            // Assert
            user.Email.Should().Be("test@test.com");
        }

        [Fact]
        public void UpdatePhoneNumber_Should_UpdatePhoneNumber()
        {
            // Arrange
            var user = A.Dummy<Customer>();

            // Act
            user.UpdatePhoneNumber("+359111");

            // Assert
            user.PhoneNumber.Should().Be("+359111");
        }

        [Fact]
        public void UpdateCity_Should_UpdateCity()
        {
            // Arrange
            var user = A.Dummy<Customer>();

            // Act
            user.UpdateCity("Burgas");

            // Assert
            user.City.Should().Be("Burgas");
        }

        [Fact]
        public void UpdateProfileImage_Should_UpdateProfileImage()
        {
            // Arrange
            var user = A.Dummy<Customer>();

            // Act
            user.UpdateProfileImage("testImage");

            // Assert
            user.ProfileImage.Should().Be("testImage");
        }
    }
}
