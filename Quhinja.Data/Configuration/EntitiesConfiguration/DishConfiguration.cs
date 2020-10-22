using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quhinja.Data.Entiities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quhinja.Data.Configuration.EntitiesConfiguration
{
    public class DishConfiguration : IEntityTypeConfiguration<Dish>
    {
        public void Configure(EntityTypeBuilder<Dish> builder)
        {
            builder.Property(dish => dish.Name)
                  .IsRequired()
                  .HasMaxLength(50);

            builder.Property(dish => dish.Picture)
                .IsRequired(false);

            builder.Property(dish => dish.Description)
                .IsRequired(false);

            //builder.HasIndex(reg => reg.Name)
            //        .IsUnique();


            builder.HasMany(dish => dish.Recipes)
                .WithOne(recipe => recipe.Dish)
                .HasForeignKey(recipe => recipe.DishId)
                .OnDelete(DeleteBehavior.NoAction);

        }

    }
}
