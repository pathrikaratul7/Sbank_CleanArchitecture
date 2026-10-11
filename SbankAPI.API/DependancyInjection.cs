using System.Data.SqlTypes;
using SbankAPI.Domain;
using SbankAPI.Infrastructur;
using SbankAPI.Application;

namespace SbankAPI.API
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddAPIDI(
            this IServiceCollection services, 
            IConfiguration configuration)
        {
            services
                .AddInfrastructureDI(configuration)
                .AddDomianDI()
                .AddApplicationDI();

            return services;
        }
    }
}
