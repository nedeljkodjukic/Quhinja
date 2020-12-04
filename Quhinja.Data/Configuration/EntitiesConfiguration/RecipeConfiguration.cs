using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quhinja.Data.Entiities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quhinja.Data.Configuration.EntitiesConfiguration
{
    class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {

            builder.Property(rec =>rec.Name)
                  .IsRequired(true);

            builder.Property(rec => rec.PreparationTime)
                .IsRequired(false);

            builder.Property(rec => rec.Preview)
                .IsRequired(false);

            builder.HasMany(recipe
                => recipe.Ingridients)
                .WithOne(ing => ing.Recipe)
                .HasForeignKey(ing => ing.RecipeId)
                .OnDelete(DeleteBehavior.NoAction);
                
        }
    }
}
