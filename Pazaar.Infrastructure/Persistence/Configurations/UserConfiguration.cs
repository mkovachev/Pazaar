using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pazaar.Infrastructure.Identity;

namespace Pazaar.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasOne(u => u.Customer)
                .WithOne()
                .HasForeignKey<User>("CustomerId")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
