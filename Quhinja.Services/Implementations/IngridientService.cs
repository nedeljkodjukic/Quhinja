using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Quhinja.Data;
using Quhinja.Data.Entiities;
using Quhinja.Services.Interfaces;
using Quhinja.Services.Models.InputModels.Ingridient;
using Quhinja.Services.Models.OutputModels.Ingridient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quhinja.Services.Implementations
{
    public class IngridientService : IIngridientService
    {

        private readonly QuhinjaDbContext data;
        private readonly IMapper mapper;

        public IngridientService(QuhinjaDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper;
        }

        public async Task<int> AddIngridientAsync(IngridientBasicInputModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            var ing = mapper.Map<Ingridient>(model);
            await data.Ingridients.AddAsync(ing);
            data.SaveChanges();
            return ing.Id;
        }

        public async Task<IngridientBasicOutputModel> GetIngridientByIdAsync(int id)
        {
            var ing = await data.Ingridients.Include(ing => ing.Recipes).ThenInclude(r => r.Recipe).SingleOrDefaultAsync(ing => ing.Id == id);
            if (ing != null)
            {
                return mapper.Map<IngridientBasicOutputModel>(ing);
            }
            throw new Exception("Not found in db");
        }

        public async Task<ICollection<IngridientBasicOutputModel>> GetIngridientsAsync()
        {
            return  await data.Ingridients.Include(ing => ing.Recipes).ThenInclude(r => r.Recipe)
               .Select(r => mapper.Map<IngridientBasicOutputModel>(r))
               .ToListAsync();
        }
    }
}
