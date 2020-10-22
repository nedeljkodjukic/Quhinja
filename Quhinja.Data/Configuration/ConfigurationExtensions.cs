using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Quhinja.Data.Configuration.EntitiesConfiguration;
using Quhinja.Data.Configuration.IdentityConfiguration;
using Quhinja.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quhinja.Data.Configuration
{


    public static class ConfigurationExtensions
    {
        public static ModelBuilder ApplyIdentityConfiguration<TKey>(this ModelBuilder modelBuilder)
            where TKey : IEquatable<TKey>
        {
            return modelBuilder
                .ApplyConfiguration(new RoleConfiguration())
                .ApplyConfiguration(new UserConfiguration())
                .Entity<User>(action => action.ToTable("Users"))
                .Entity<Role>(action => action.ToTable("Roles"))
                .Entity<IdentityRoleClaim<TKey>>(action => action.ToTable("RoleClaims"))
                .Entity<IdentityUserLogin<TKey>>(action => action.ToTable("UserLogins"))
                .Entity<IdentityUserClaim<TKey>>(action => action.ToTable("UserClaims"))
                .Entity<IdentityUserToken<TKey>>(action => action.ToTable("UserTokens"))
                .Entity<IdentityUserRole<TKey>>(action => action.ToTable("UserRoles"));
        }
        public static ModelBuilder ApplyQuhinjaConfiguration(this ModelBuilder modelBuilder)
        {
            return modelBuilder
            .ApplyConfiguration(new DishConfiguration())
              .ApplyConfiguration(new DishTypeConfiguration())
              .ApplyConfiguration(new IngridientConfiguration())
              .ApplyConfiguration(new MenuItemConfiguration())
              .ApplyConfiguration(new RecipeConfiguration());
              }
    }
}

