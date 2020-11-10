using AutoMapper;
using Quhinja.Data.Entiities;
using Quhinja.Data.Entiities.Quhinja.Data.Entiities;
using Quhinja.Services.Models.OutputModels.Dish;
using Quhinja.Services.Models.OutputModels.Recipe;

namespace Quhinja.Services.Mappings.OutputMappings
{
    public class DishOutputModels : Profile
    {
        public DishOutputModels()
        {
            CreateMap<Dish, DishWithRecipesOutputModel>();

            CreateMap<Dish,DishBasicOutputModel>();

            CreateMap<UsersRatingForDish, UsersRatingsForDishOutputModel>();
        }
    }
}
