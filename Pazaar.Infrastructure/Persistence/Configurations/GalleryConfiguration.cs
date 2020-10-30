using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pazaar.Domain.Models.Ads;

namespace Pazaar.Infrastructure.Persistence.Configurations
{
    internal class GalleryConfiguration : IEntityTypeConfiguration<Gallery>
    {
        public void Configure(EntityTypeBuilder<Gallery> builder)
        {
            builder
                .HasMany(g => g.Images)
                .WithOne()
                .Metadata
                .PrincipalToDependent
                .SetField("images");
        }
    }
}