using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Quhinja.Data;
using Quhinja.Data.Entiities;
using Quhinja.Services.Interfaces;
using Quhinja.Services.Models.InputModels.Recipe;
using Quhinja.Services.Models.OutputModels.Recipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quhinja.Services.Implementations
{
    public class RecipeService : IRecipeService
    {

        private readonly QuhinjaDbContext data;
        private readonly IMapper mapper;


        public RecipeService(QuhinjaDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper;
        }

        public async Task AddImageBytesAsync(int recipeId, byte [] bytes)
        {
            var recipe = await data.Recipes.FindAsync(recipeId);
            recipe.Image =bytes;
            data.SaveChanges();

        }
        public async Task AddImageToRecipeAsync(int recipeId, string path)
        {
            var recipe = await data.Recipes.FindAsync(recipeId);
            recipe.Picture = path;
            data.SaveChanges();
        }

        public async Task<int> AddRecipeAsync(RecipeWithDishInputModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            var recipe = mapper.Map<Recipe>(model);
            await data.Recipes.AddAsync(recipe);
            data.SaveChanges();
            return recipe.Id;
        }

        public async  Task<RecipeBasicOutputModel> GetRecipeById(int id)
        {
            var recipe = await data.Recipes.Include(r=>r.Dish).SingleOrDefaultAsync(d => d.Id == id);
            if (recipe != null)
            {
                return mapper.Map<RecipeBasicOutputModel>(recipe);
            }
            throw new Exception("Not found in db");
        }

        public async Task<ICollection<RecipeBasicOutputModel>> GetRecipesAsync()
        {
            return await data.Recipes.Include(rec=>rec.Ingridients).ThenInclude(rec=>rec.Ingridient)
                                      .Select(r => mapper.Map<RecipeBasicOutputModel>(r))
                                      .ToListAsync();
        }

        public async Task<ICollection<RecipeWithDishOutputModel>> GetRecipesWithDishAsync()
        {
            return await data.Recipes.Include(rec => rec.Dish)
                                    .Select(r => mapper.Map<RecipeWithDishOutputModel>(r))
                                    .ToListAsync();
        }


        public async Task RemoveRecipeAsync(int recipeId)
        {
            var recipeInDb = await data.Recipes
                                    .Include(r => r.Dish)
                                    .SingleOrDefaultAsync(r => r.Id == recipeId);

            if (recipeInDb != null)//Brisanje recepata iz svih jela
            {
                data.Recipes.Remove(recipeInDb);
                data.SaveChanges();
            }
        }
    
    }
}
