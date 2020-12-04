using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quhinja.Data.Entities;

namespace Quhinja.Data.Configuration.IdentityConfiguration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {

            builder.Property(r => r.RoleDescription)
                .IsRequired()
                .HasMaxLength(30);

        }
    }
}
