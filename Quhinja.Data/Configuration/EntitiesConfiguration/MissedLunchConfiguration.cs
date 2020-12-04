using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quhinja.Data.Entiities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quhinja.Data.Configuration.EntitiesConfiguration
{
    public class MissedLunchConfiguration  : IEntityTypeConfiguration<MissedLunch>
    {
        public void Configure(EntityTypeBuilder<MissedLunch> builder)
        {
           
        }
    
    }
}
