﻿using FakeItEasy;
using Pazaar.Domain.Model.Users;
using System;

namespace Pazaar.Domain.Models.Users
{
    public class UserFakes
    {
        public class CategoryDummyFactory : IDummyFactory
        {
            public bool CanCreate(Type type) => type == typeof(DomainUser);

            public object? Create(Type type) => new DomainUser("John", "john@mail.com", "+3591234567", "Sofia", "image");

            public Priority Priority => Priority.Default;
        }
    }
}
