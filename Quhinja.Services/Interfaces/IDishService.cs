using Quhinja.Services.Models.InputModels.Dish;
using Quhinja.Services.Models.OutputModels.Dish;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Quhinja.Services.Interfaces
{
  public interface IDishService
    {
        Task<DishBasicOutputModel> GetDishByIdAsync(int id);
        Task<ICollection<DishBasicOutputModel>> GetDishesAsync();

        Task<int> AddDishAsync(DishBasicInputModel model);

        Task RemoveDishAsync(int dishId);
        Task AddImageToDishAsync(int dishId, string path);
    }
}
