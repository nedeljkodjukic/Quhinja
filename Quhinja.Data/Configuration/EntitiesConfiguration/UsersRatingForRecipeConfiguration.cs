using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quhinja.Data.Entiities.Quhinja.Data.Entiities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quhinja.Data.Configuration.EntitiesConfiguration
{
    public class UsersRatingForRecipeConfiguration : IEntityTypeConfiguration<UsersRatingForRecipe>
    {
        public void Configure(EntityTypeBuilder<UsersRatingForRecipe> builder)
        {
            builder.Property(ing => ing.Rating)
                  .IsRequired(true);
                  

        }

    }
}
 
