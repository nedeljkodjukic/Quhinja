using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Quhinja.Data;
using Quhinja.Data.Entiities;
using Quhinja.Services.Interfaces;
using Quhinja.Services.Models.InputModels.Dish;
using Quhinja.Services.Models.OutputModels.Dish;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quhinja.Services.Implementations
{
    public class DishService : IDishService
    {

        private readonly QuhinjaDbContext data;
        private readonly IMapper mapper;


        public DishService(QuhinjaDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper;
        }
        public async Task<int> AddDishAsync(DishBasicInputModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            var dish = mapper.Map<Dish>(model);
            await data.Dishes.AddAsync(dish);
            data.SaveChanges();
            return dish.Id;
        }

        public async  Task<DishBasicOutputModel> GetDishByIdAsync(int id)
        {
            var dish = await data.Dishes.Include(dishh => dishh.Recipes).ThenInclude(r => r.Ingridients).SingleOrDefaultAsync(d => d.Id == id);
            if (dish != null)
            {
                return mapper.Map<DishBasicOutputModel>(dish);
            }
            throw new Exception("Not found in db");
        }



        public  async Task<ICollection<DishBasicOutputModel>> GetDishesAsync()
        {
            return await data.Dishes.Include(ing => ing.Recipes)
                          .Select(r => mapper.Map<DishBasicOutputModel>(r))
                          .ToListAsync();
        }

        public async Task<ICollection<DishWithRecipesOutputModel>> GetDishesWithRecipesAsync()
        {
            return await data.Dishes.Include(ing => ing.Recipes)
                          .Select(r => mapper.Map<DishWithRecipesOutputModel>(r))
                          .ToListAsync();
        }



        public async Task RemoveDishAsync(int dishId)
        {
            var dishInDb = await data.Dishes
                        .Include(ing => ing.Recipes)
                        .SingleOrDefaultAsync(ing => ing.Id == dishId);

            if (dishInDb != null)//Brisanje jela iz svih recepata
            {
                data.Dishes.Remove(dishInDb);
                data.SaveChanges();
            }
        
    }
        public async Task AddImageToDishAsync(int dishId, string path)
        {
            var dish = data.Dishes.Find(dishId);
             dish.Picture = path;
            data.SaveChanges();
        }

        public async Task<ICollection<string>> GetDishTypesAsync()
        {
            return await data.Dishes.Select(x => x.DishType).Distinct().ToListAsync();
        }
    }
}
