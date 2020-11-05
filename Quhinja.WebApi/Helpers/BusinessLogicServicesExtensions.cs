using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quhinja.Services.Implementations;
using Quhinja.Services.Interfaces;
using Quhinja.WebApi.Options;

namespace Quhinja.WebApi.Helpers
{
    public static class  BusinessLogicServicesExtensions
    {

        public static IServiceCollection AddBusinessLogicServices(this IServiceCollection services, IConfiguration configuration)
        {
            var sendGridOptions = new SendGridOptions();

            configuration.GetSection(nameof(SendGridOptions)).Bind(sendGridOptions);

            return services.AddScoped<IIngridientService, IngridientService>()
                   .AddScoped<IDishService, DishService>()
                   .AddScoped<IRecipeService, RecipeService>()
                   .AddScoped<IMenuItemService, MenuItemService>()
                   .AddScoped<IUserService, UserService>()
                   .AddScoped<IIdentityService, IdentityService>()
                    .AddScoped<IEmailSender>(x =>
                    new SendGridEmailSender(sendGridOptions.ApiKey, sendGridOptions.From, sendGridOptions.FromName));


            ;
        }
        }
}
