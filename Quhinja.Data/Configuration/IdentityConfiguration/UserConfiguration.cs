﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quhinja.Data.Entities;

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
                Id = 5,
                Name = "Srdjan",
                Surname = "Arsic",
                UserName = "srki",
                Email = "srdjan.arsic@quadrixsoft.com"

            });

        }
    }
}
