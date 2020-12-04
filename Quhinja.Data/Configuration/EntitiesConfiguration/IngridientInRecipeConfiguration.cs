using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quhinja.Data.Entiities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quhinja.Data.Configuration.EntitiesConfiguration
{
    class IngridientInRecipeConfiguration : IEntityTypeConfiguration<IngridientInRecipe>
    {
        public void Configure(EntityTypeBuilder<IngridientInRecipe> builder)
        {

            builder.Property(ing => ing.Quantity)
                  .IsRequired(true);

            builder.Property(ing => ing.Unit)
                .IsRequired();      

        }       
    }
}
