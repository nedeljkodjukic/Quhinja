using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quhinja.Data.Entiities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quhinja.Data.Configuration.EntitiesConfiguration
{
    class DishTypeConfiguration : IEntityTypeConfiguration<DishType>
    {
        public void Configure(EntityTypeBuilder<DishType> builder)
        {
            builder.Property(dish => dish.Name)
                  .IsRequired(true)
                  .HasMaxLength(50);

        }
    }
 }
