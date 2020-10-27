using Bogus;
using FakeItEasy;
using System;

namespace Pazaar.Domain.Models.Ads
{
    public class AdFakes
    {
        public class AdDummyFactory : IDummyFactory
        {
            public bool CanCreate(Type type) => type == typeof(Ad);

            public object? Create(Type type) => new Ad("Selling my Audi", new Gallery(), 1000.00M);

            public Priority Priority => Priority.Default;
        }

        public static Ad GetAd()
               => new Faker<Ad>()
                   .CustomInstantiator(f => new Ad(
                       f.Random.String(5),
                       A.Dummy<Gallery>(),
                       f.Random.Number(1, 100)))
                   .Generate();
    }
}
