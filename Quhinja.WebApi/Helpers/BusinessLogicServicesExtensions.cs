using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quhinja.Services.Implementations;
using Quhinja.Services.Interfaces;

namespace Quhinja.WebApi.Helpers
{
    public static class  BusinessLogicServicesExtensions
    {

        public static IServiceCollection AddBusinessLogicServices(this IServiceCollection services, IConfiguration configuration)
        {


            return services.AddScoped<IIngridientService, IngridientService>();
;
        }
        }
}
