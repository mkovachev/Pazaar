using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pazaar.Domain.Model.Customer;
using Pazaar.Domain.Models;

namespace Pazaar.Infrastructure.Persistence.Configurations
{
    using static ModelConstants.Customer;

    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
              .Property(c => c.Name)
              .HasMaxLength(NameMaxLength)
              .IsRequired();

            builder
             .Property(c => c.Email)
             .IsRequired();

            builder
              .Property(c => c.PhoneNumber)
              .HasMaxLength(PhoneNumberMaxLength);

            builder
             .Property(c => c.City)
             .HasMaxLength(CityMaxLength);

            builder
            .Property(c => c.ProfileImage)
            .HasMaxLength(ProfileImageUrlMaxLength);

            builder.HasMany(c => c.Ads)
                .WithOne()
                .Metadata
                .PrincipalToDependent
                .SetField("ads");
        }
    }
}
