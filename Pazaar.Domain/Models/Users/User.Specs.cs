using FluentAssertions;
using Pazaar.Domain.Model.Users;
using System;
using Xunit;

namespace Pazaar.Domain.Models.Users
{
    using static ModelConstants.User;
    public class UserSpecs
    {
        [Fact]
        public void CreateUserWitEmptyName_Should_Throw_ArgumentException()
        {
            // Act
            Action act = () => new User("", "user@mail.com", "+359998877133", "Sofia", "image");

            // Assert
            act.Should().Throw<ArgumentException>().WithMessage("Please add your name");
        }

        [Fact]
        public void CreateUserWitInvalidNameLength_Should_Throw_ArgumentException()
        {
            // Act
            Action act = () => new User("G", "user@mail.com", "+359998877133", "Sofia", "image");

            // Assert
            act.Should().Throw<ArgumentException>()
                .WithMessage($"Name must be between {NameMinLength} and {NameMaxLength} characters");
        }
    }
}
