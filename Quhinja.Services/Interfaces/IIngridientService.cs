using Quhinja.Services.Models.InputModels.Ingridient;
using Quhinja.Services.Models.OutputModels.Ingridient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Quhinja.Services.Interfaces
{
    public interface IIngridientService
    {

        Task<IngridientBasicOutputModel> GetIngridientByIdAsync(int id);
        Task<ICollection<IngridientBasicOutputModel>> GetIngridientsAsync();

        Task<int> AddIngridientAsync(IngridientBasicInputModel model);

        Task<int> AddIngridientToRecipeAsync(IngridientsInRecipeBasicInputModel model);

        Task RemoveIngridientAsync(int ingridientId);



    }
}
