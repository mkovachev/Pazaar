using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pazaar.Domain.Models;
using Pazaar.Domain.Models.Ads;

namespace Pazaar.Infrastructure.Persistence.Configurations
{
    using static ModelConstants.Ad;
    internal class AdConfiguration : IEntityTypeConfiguration<Ad>
    {
        public void Configure(EntityTypeBuilder<Ad> builder)
        {
            builder
                .HasKey(ad => ad.Id);

            builder
              .Property(ad => ad.Title)
              .IsRequired()
              .HasMaxLength(TitleMaxLength);

            builder
              .Property(ad => ad.Gallery)
              .IsRequired();

            builder
             .Property(ad => ad.Price)
             .IsRequired()
             .HasMaxLength((int)MaxPrice);

            builder
             .Property(ad => ad.Description)
             .IsRequired()
             .HasMaxLength(DescriptionMaxLength);

            builder
             .Property(ad => ad.IsActive);

            builder
                .HasMany(ad => ad.Categories)
                .WithOne()
                .Metadata
                .PrincipalToDependent
                .SetField("Categories");
        }
    }
}
