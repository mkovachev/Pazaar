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
              .Property(ad => ad.Title)
              .HasMaxLength(TitleMaxLength)
              .IsRequired();

            builder
              .HasOne(ad => ad.Gallery)
              .WithMany()
              .HasForeignKey("GalleryId")
              .OnDelete(DeleteBehavior.Restrict);

            builder
             .Property(ad => ad.Price)
             .HasMaxLength((int)MaxPrice)
             .HasColumnType("decimal(18,2)")
             .IsRequired();

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
