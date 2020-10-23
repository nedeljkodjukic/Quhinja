using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Quhinja.Data;
using Quhinja.Services.Interfaces;
using Quhinja.Services.Models.OutputModels;
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
            var dishType = await data.DishTypes.SingleOrDefaultAsync(r => r.Id == id);
            if (dishType != null)
            {
                return mapper.Map<DishTypeBasicOutputModel>(dishType);
            }
            throw new Exception("Not found in db");
        }

        public async Task<ICollection<DishTypeBasicOutputModel>> GetDishTypesAsync()
        {
            return await data.DishTypes
                .Select(r => mapper.Map<DishTypeBasicOutputModel>(r))
                .ToListAsync();
        }

    }
}
