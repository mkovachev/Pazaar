using FakeItEasy;
using FluentAssertions;
using Pazaar.Domain.Exceptions;
using Pazaar.Domain.Model.Customer;
using System;
using Xunit;

namespace Pazaar.Domain.Models.Customers
{
    public class CustomerTests
    {
        [Fact]
        public void CreateUserWitEmptyName_Should_Throw_ArgumentException()
        {
            // Act
            Action act = () => new Customer("");

            // Assert
            act.Should().Throw<InvalidCustomerException>();
        }

        [Fact]
        public void CreateUserWitInvalidMinNameLength_Should_Throw_ArgumentException()
        {
            // Act
            Action act = () => new Customer("x");

            // Assert
            act.Should().Throw<InvalidCustomerException>();
        }

        [Fact]
        public void CreateUserWitInvalidMaxNameLength_Should_Throw_ArgumentException()
        {
            // Act
            Action act = () => new Customer("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");

            // Assert
            act.Should().Throw<InvalidCustomerException>();
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
            user.UpdateCity("New City");

            // Assert
            user.City.Should().Be("New City");
        }

        [Fact]
        public void UpdateProfileImageWithInvalidImage_Should_UpdateProfileImage()
        {
            // Arrange
            var user = A.Dummy<Customer>();

            // Act
            Action act = () => user.UpdateProfileImage("invalid Image url");

            // Assert
            act.Should().Throw<InvalidCustomerException>();
        }

        [Fact]
        public void UpdateProfileImage_Should_UpdateProfileImage()
        {
            // Arrange
            var user = A.Dummy<Customer>();

            // Act
            user.UpdateProfileImage("data:image/jpeg;base64,/someimage");

            // Assert
            user.ProfileImage.Should().Be("data:image/jpeg;base64,/someimage");
        }
    }
}
