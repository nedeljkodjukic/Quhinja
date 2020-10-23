using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Quhinja.Data;
using Quhinja.Data.Entiities;
using Quhinja.Services.Interfaces;
using Quhinja.Services.Models.InputModels.DishType;
using Quhinja.Services.Models.OutputModels.DishType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quhinja.Services.Implementations
{
    public class DishTypeService : IDishTypeService
    {

        private readonly QuhinjaDbContext data;
        private readonly IMapper mapper;

        public DishTypeService(QuhinjaDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper;
        }
        
        public async Task<DishTypeBasicOutputModel>GetDishTypeByIdAsync(int id)
        {
            var dishType = await data.DishTypes.Include(d => d.Dishes).SingleOrDefaultAsync(r => r.Id == id);
            if (dishType != null)
            {
                return mapper.Map<DishTypeBasicOutputModel>(dishType);
            }
            throw new Exception("Not found in db");
        }

        public async Task<ICollection<DishTypeBasicOutputModel>> GetDishTypesAsync()
        {
            return await data.DishTypes.Include(d=>d.Dishes)
                .Select(r => mapper.Map<DishTypeBasicOutputModel>(r))
                .ToListAsync();
        }

        public async Task<int> AddDishTypeAsync(DishTypeBasicInputModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var dishType = mapper.Map<DishType>(model);


            await data.DishTypes.AddAsync(dishType);
            data.SaveChanges();

            return dishType.Id;
        }

        public async Task DeleteDishTypeAsync(int dishTypeId)
        {
            var dishTypesInDb = await data.DishTypes
                .Include(dt =>dt.Dishes)
                .SingleOrDefaultAsync(dt => dt.Id == dishTypeId);
            
                data.DishTypes.Remove(dishTypesInDb);
                data.SaveChanges();
            
        }



    }
}
