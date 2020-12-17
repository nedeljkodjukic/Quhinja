using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Quhinja.Data;
using Quhinja.Data.Entiities;
using Quhinja.Data.Entiities.Quhinja.Data.Entiities;
using Quhinja.Services.Interfaces;
using Quhinja.Services.Models.InputModels.Dish;
using Quhinja.Services.Models.InputModels.Recipe;
using Quhinja.Services.Models.OutputModels.Dish;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quhinja.Services.Implementations
{
    public class DishService : IDishService
    {

        private readonly QuhinjaDbContext data;
        private readonly IMapper mapper;


        public DishService(QuhinjaDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper;
        }
        public async Task<int> AddDishAsync(DishBasicInputModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            var dish = mapper.Map<Dish>(model);
            await data.Dishes.AddAsync(dish);
            data.SaveChanges();
            return dish.Id;
        }
       
        public async  Task<DishWithRecipesOutputModel> GetDishByIdAsync(int id)
        {
            var dish = await data.Dishes.Include(dishh => dishh.Recipes).ThenInclude(r => r.Ingridients).ThenInclude(ing=>ing.Ingridient).SingleOrDefaultAsync(d => d.Id == id);
            if (dish != null)
            {
                return mapper.Map<DishWithRecipesOutputModel>(dish);
            }
            throw new Exception("Not found in db");
        }



        public  async Task<ICollection<DishBasicOutputModel>> GetDishesAsync()
        {
            return await data.Dishes.Include(ing => ing.Recipes)
                          .Select(r => mapper.Map<DishBasicOutputModel>(r))
                          .ToListAsync();
        }

        public async Task<ICollection<DishWithRecipesOutputModel>> GetDishesWithRecipesAsync()
        {
            return await data.Dishes.Include(ing => ing.Recipes)
                          .Select(r => mapper.Map<DishWithRecipesOutputModel>(r))
                          .ToListAsync();
        }



        public async Task RemoveDishAsync(int dishId)
        {
            var dishInDb = await data.Dishes
                        .Include(ing => ing.Recipes)
                        .SingleOrDefaultAsync(ing => ing.Id == dishId);

            if (dishInDb != null)//Brisanje jela iz svih recepata
            {
                data.Dishes.Remove(dishInDb);
                data.SaveChanges();
            }
        
    }
        public async Task AddImageBytesAsync ( int dishId, byte [] image)
        {
            var dish = await data.Dishes.FindAsync(dishId);
            dish.Image =image;
            data.SaveChanges();

        }

        public async Task AddImageToDishAsync(int dishId, string path)
        {
            var dish = await data.Dishes.FindAsync(dishId);
             dish.Picture = path;
             data.SaveChanges();
        }

        public async Task<ICollection<string>> GetDishTypesAsync()
        {
            return await data.Dishes.Select(x => x.DishType).Distinct().ToListAsync();
        }

        public async Task<float?> RateDishAsync(UsersRatingForDishInputModel model)
        {

            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            var rating = mapper.Map<UsersRatingForDish>(model);

            var RatingFromBase =data.UsersRatingForDishes.Where(x => x.DishId == model.DishId && x.UserId == model.UserId).FirstOrDefault();
            if (RatingFromBase == null)
            {
                await data.UsersRatingForDishes.AddAsync(rating);
                await data.SaveChangesAsync();
            }
            else
            {
                RatingFromBase.Rating = model.Rating;
                data.Update(RatingFromBase);

            }
            var arrayOfRatings = await data.UsersRatingForDishes.Where(x => x.DishId == model.DishId).ToListAsync();
                var dish = await data.Dishes.FindAsync(model.DishId);
                int lenght = arrayOfRatings.Count();
                float sum = 0;
                foreach (var r in arrayOfRatings)
                    sum += r.Rating;
                dish.averageRating = sum / lenght;
            
                    await data.SaveChangesAsync();
                    return dish.averageRating;

        }

        public async Task<ICollection<DishBasicOutputModel>> GetSortedDishesAsync()
        {
            return await data.Dishes.OrderByDescending(x=>x.averageRating).Take(6)
                         .Select(r => mapper.Map<DishBasicOutputModel>(r))
                         .ToListAsync();
        }

        public async Task<int> selectRecipe(DishSelectedRecipeInput dish)
        {
            int dishId = dish.Id;

            var dishFromDb =  await data.Dishes.FirstOrDefaultAsync(x => x.Id == dishId);

            var recipe = await data.Recipes.FirstOrDefaultAsync(x => x.Id == dish.selectedRecipeId);
            dishFromDb.selectedRecipeId = dish.selectedRecipeId;
            dishFromDb.selectedRecipe = recipe;
            await data.SaveChangesAsync();

            return recipe.Id;
        }
    }
}
