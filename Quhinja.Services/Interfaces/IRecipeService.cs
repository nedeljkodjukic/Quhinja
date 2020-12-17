using Quhinja.Services.Models.InputModels.Recipe;
using Quhinja.Services.Models.OutputModels.Recipe;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Quhinja.Services.Interfaces
{
   public interface IRecipeService
    {
        Task<RecipeBasicOutputModel> GetRecipeById(int id);
        Task<ICollection<RecipeBasicOutputModel>> GetRecipesAsync();

        Task<ICollection<RecipeWithDishOutputModel>> GetRecipesWithDishAsync();
        Task AddImageBytesAsync(int recipeId, byte[] image);


        Task<int> AddRecipeAsync(RecipeWithDishInputModel model);

        Task RemoveRecipeAsync(int recipeId);
        Task AddImageToRecipeAsync(int recipeId, string path);
    }
}
