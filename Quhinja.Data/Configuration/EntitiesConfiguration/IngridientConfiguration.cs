using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quhinja.Data.Entiities;
using System;
using System.Collections.Generic;
using System.Text;


namespace Quhinja.Data.Configuration.EntitiesConfiguration
{
    class IngridientConfiguration : IEntityTypeConfiguration<Ingridient>
    {
        public void Configure(EntityTypeBuilder<Ingridient> builder)
        {
            builder.Property(ing => ing.Name)
                  .IsRequired()
                  .HasMaxLength(50);

            builder.HasMany(ing => ing.Recipes)
               .WithOne(
                recipe
                => recipe.Ingridient)
               .HasForeignKey(recipe => recipe.IngridientId)
               .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
