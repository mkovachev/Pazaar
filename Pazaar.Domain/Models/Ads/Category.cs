﻿using Pazaar.Domain.Common;

namespace Pazaar.Domain.Models.Ads
{
    public class Category : Entity
    {
        internal Category(string name)
        {
            this.Name = name;
        }

        public string Name { get; }
    }
}
