using Quhinja.Services.Models.OutputModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Quhinja.Services.Interfaces
{
   public interface  IDishTypeService
    {
        Task<DishTypeBasicOutputModel> GetDishTypeByIdAsync(int id);

        Task<ICollection<DishTypeBasicOutputModel>> GetDishTypesAsync();

    }
}
