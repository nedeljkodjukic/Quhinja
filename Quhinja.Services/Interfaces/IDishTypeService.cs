using Quhinja.Services.Models.InputModels.DishType;
using Quhinja.Services.Models.OutputModels.DishType;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quhinja.Services.Interfaces
{
    public interface  IDishTypeService
    {
        Task<DishTypeBasicOutputModel> GetDishTypeByIdAsync(int id);

        Task<ICollection<DishTypeBasicOutputModel>> GetDishTypesAsync();

        Task<int> AddDishTypeAsync(DishTypeBasicInputModel model);

        Task DeleteDishTypeAsync(int dishTypeId);



    }
}
