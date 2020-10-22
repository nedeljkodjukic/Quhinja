using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Quhinja.Data.Configuration;
using Quhinja.Data.Entiities;
using Quhinja.Data.Entities;

namespace Quhinja.Data
{
    public class QuhinjaDbContext : IdentityDbContext<User, Role, int>
    {
        public DbSet<Dish> Dishes { get; set; }

        public DbSet<Ingridient> Indgridients { get; set; }

        public DbSet<MenuItem> MenuItems { get; set; }

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<DishType> dishTypes { get; set; }

        //public DbSet<Role> Roles { get; set; }

        //public DbSet<User> Users { get; set; }

        public QuhinjaDbContext(DbContextOptions<QuhinjaDbContext> options)
            :base(options)
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