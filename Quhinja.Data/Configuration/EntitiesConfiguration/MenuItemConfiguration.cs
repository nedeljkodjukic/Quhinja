using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quhinja.Data.Entiities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quhinja.Data.Configuration.EntitiesConfiguration
{
    class MenuItemConfiguration : IEntityTypeConfiguration<MenuItem>
    {
        public void Configure(EntityTypeBuilder<MenuItem> builder)
        {

            builder.Property(menu => menu.DateOfDish)
                .IsRequired(true);

            builder.HasMany(m=>m.MissedUsers)
             .WithOne(u => u.MenuItem)
             .HasForeignKey(rat => rat.MenuItemId)
             .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
