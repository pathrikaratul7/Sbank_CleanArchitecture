using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SbankAPI.Application.Interface;

using SbankAPI.Infrastructur.Repositories;

using SbankAPI.Infrastructure.Data;

namespace SbankAPI.Infrastructur
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddInfrastructureDI(
            this IServiceCollection services, 
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnectionString") ??
                throw new InvalidOperationException("Connection string 'DefaultConnectionString' is not configured");

            services.AddDbContext<APpDbContext>(options =>
            {
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly("SbankAPI.Infrastructur"));
            });

            services.AddScoped<IUserRepository, UserRepositories>();
          //  services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork_>();

            return services;
        }
    }
}
