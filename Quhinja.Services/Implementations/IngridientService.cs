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

        public async Task<int> AddIngridientToRecipeAsync(IngridientsInRecipeBasicInputModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            var ing = mapper.Map<IngridientInRecipe>(model);
            Ingridient IngId =await data.Ingridients.Include(i=>i.Recipes).SingleOrDefaultAsync(inggr => inggr.Name == model.Ingridient.Name);
            Recipe Recipe1 = await data.Recipes.Include(r=>r.Ingridients).SingleOrDefaultAsync(r => r.Id == model.RecipeId);
            if (IngId != null)
            {
                ing.RecipeId = model.RecipeId;
                ing.IngridientId = IngId.Id;
                ing.Quantity = model.Quantity;
                ing.Unit = model.Unit;
                ing.Recipe = Recipe1;
                ing.Ingridient = IngId;
            }
            else
            {
                Ingridient ingForBase = new Ingridient();
                ingForBase.Name = model.Ingridient.Name;

                data.Ingridients.Add(ingForBase);

                await data.SaveChangesAsync();
                ing.RecipeId = model.RecipeId;
                ing.IngridientId = ingForBase.Id;
                ing.Quantity = model.Quantity;
                ing.Unit = model.Unit;
                ing.Recipe = Recipe1;
                ing.Ingridient = ingForBase;
            }
            await data.IngridientInRecipes.AddAsync(ing);


            data.SaveChanges();
            return ing.Id;
        }

        public async Task<IngridientBasicOutputModel> GetIngridientByIdAsync(int id)
        {
            var ing = await data.Ingridients.Include(ingridient => ingridient.Recipes).ThenInclude(r => r.Recipe).SingleOrDefaultAsync(inggr => inggr.Id == id);
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

        public async Task RemoveIngridientAsync(int ingridientId)
        {
            var ingridientInDb = await data.Ingridients
             .Include(ing => ing.Recipes)
             .SingleOrDefaultAsync(ing => ing.Id == ingridientId);

            if (ingridientInDb != null)//Brisanje sastojaka iz svih recepata
            {
                data.Ingridients.Remove(ingridientInDb);
                data.SaveChanges();
            }
        }
    }
}
