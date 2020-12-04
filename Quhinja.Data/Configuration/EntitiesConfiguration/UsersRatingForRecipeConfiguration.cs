using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quhinja.Data.Entiities.Quhinja.Data.Entiities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quhinja.Data.Configuration.EntitiesConfiguration
{
    public class UsersRatingForDishConfiguration : IEntityTypeConfiguration<UsersRatingForDish>
    {
        public void Configure(EntityTypeBuilder<UsersRatingForDish> builder)
        {

            builder.Property(ing => ing.Rating)
                  .IsRequired(true);
            
        }
    }
}
 
