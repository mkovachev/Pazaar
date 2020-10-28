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
                .HasKey(a => a.Id);

            builder
              .Property(a => a.Title)
              .IsRequired()
              .HasMaxLength(TitleMaxLength);

            builder
              .Property(a => a.Gallery)
              .IsRequired();

            builder
             .Property(a => a.Price)
             .IsRequired()
             .HasMaxLength((int)MaxPrice);

            builder
             .Property(a => a.Description)
             .IsRequired()
             .HasMaxLength(DescriptionMaxLength);

        }
    }
}
