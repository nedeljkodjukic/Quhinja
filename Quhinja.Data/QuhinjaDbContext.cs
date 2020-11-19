using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Quhinja.Data.Configuration;
using Quhinja.Data.Entiities;
using Quhinja.Data.Entiities.Quhinja.Data.Entiities;
using Quhinja.Data.Entities;

namespace Quhinja.Data
{
    public class QuhinjaDbContext : IdentityDbContext<User, Role, int>
    {
        public DbSet<Dish> Dishes { get; set; }

        public DbSet<Ingridient> Ingridients { get; set; }

        public DbSet<MenuItem> MenuItems { get; set; }

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<IngridientInRecipe> IngridientInRecipes { get; set; }

        public DbSet<UsersRatingForDish> UsersRatingForDishes { get; set; }

        public DbSet<MissedLunch> MissedLunches { get; set; }

        public QuhinjaDbContext(DbContextOptions<QuhinjaDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder
                .ApplyQuhinjaConfiguration()
                .ApplyIdentityConfiguration<int>();
        }

    }
}