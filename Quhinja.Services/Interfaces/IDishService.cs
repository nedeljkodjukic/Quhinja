using Quhinja.Services.Models.InputModels.Dish;
using Quhinja.Services.Models.InputModels.Recipe;
using Quhinja.Services.Models.OutputModels.Dish;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Quhinja.Services.Interfaces
{
  public interface IDishService
    {
        Task<DishWithRecipesOutputModel> GetDishByIdAsync(int id);
         Task AddImageBytesAsync(int dishId, byte[] image);

        Task<ICollection<string>> GetDishTypesAsync();
        Task<ICollection<DishBasicOutputModel>> GetDishesAsync();

        Task<int> selectRecipe(DishSelectedRecipeInput dish);
        Task<ICollection<DishWithRecipesOutputModel>> GetDishesWithRecipesAsync();

        Task<int> AddDishAsync(DishBasicInputModel model);


        Task<float?> RateDishAsync(UsersRatingForDishInputModel model);

        Task<ICollection<DishBasicOutputModel>> GetSortedDishesAsync();
        Task RemoveDishAsync(int dishId);
        Task AddImageToDishAsync(int dishId, string path);
    }
}
