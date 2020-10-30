using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pazaar.Domain.Models;
using Pazaar.Domain.Models.Ads;

namespace Pazaar.Infrastructure.Persistence.Configurations
{
    using static ModelConstants.Category;
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
              .Property(a => a.Name)
              .IsRequired()
              .HasMaxLength(NameMaxLength);
        }
    }
}
