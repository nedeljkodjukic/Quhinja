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
            builder.HasData(new Role
            {
                Id = 1,
                Name = "admin",
                NormalizedName = "ADMIN",
                RoleDescription = "admin"
            },
             new Role
             {
                 Id = 2,
                 Name = "user",
                 NormalizedName = "USER",
                 RoleDescription = "user"
             }
             );
        }
    }
}
