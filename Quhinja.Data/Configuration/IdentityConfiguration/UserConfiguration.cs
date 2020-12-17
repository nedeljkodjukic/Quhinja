using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quhinja.Data.Entities;
using System;
using System.Collections.Generic;

namespace Quhinja.Data.Configuration.IdentityConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(u => u.Surname)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(u => u.Gender)
                .IsRequired(false);

            builder.Property(u => u.DateOfBirth)
                .IsRequired(true);

            builder.Property(u => u.ProfilePictureUrl)
                .IsRequired(false);

            builder.Property(u => u.Image)
               .IsRequired(false);

            builder.Property(u => u.DateOfEmployment)
                .IsRequired(true);

            builder.Property(u => u.Position)
                .IsRequired(false);

            builder.HasMany(u => u.UserRoles)
                .WithOne()
                .HasForeignKey(ur => ur.UserId);

            builder.HasMany(u => u.RatingsInDishes)
                .WithOne(rat => rat.User)
                .HasForeignKey(rat => rat.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(u => u.MissedDates)
             .WithOne(mis => mis.User)
             .HasForeignKey(mis => mis.UserId)
             .OnDelete(DeleteBehavior.NoAction);


            builder.HasData(new User
            {
                Id = 1,
                Name = "Srdjan",
                Surname = "Arsic",
                UserName = "adm",
                NormalizedUserName = "ADM",
                Email = "srdjan.arsic@quadrixsoft.com",
                NormalizedEmail = "SRDJAN.ARSIC@QUADRIXSOFT.COM",
                EmailConfirmed = false,
                Gender = Entiities.Enums.Gender.Male,
                DateOfBirth = DateTime.Now,
                DateOfEmployment = DateTime.Now,
                AccessFailedCount = 0,
                LockoutEnabled = true,
                TwoFactorEnabled = false,
                PhoneNumberConfirmed = false,
                SecurityStamp= "5TBB7CACI3F2JOD25JGXSNQASZ2NWHRK",
                PasswordHash ="AQAAAAEAACcQAAAAELVcpiFzbc+pNTWWEBIXRKHvCaoWR65ihDzBGmGTwqAWU5kcy7KVDHLS+YSPTycg7w=="
            });

        }
    }
}
