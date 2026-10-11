using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SbankAPI.Application.Dto;
using SbankAPI.Application.Interface;
using SbankAPI.Application.Services;
using SbankAPI.Application.Validator;

namespace SbankAPI.Application
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddApplicationDI(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IValidator<CreateUserDto>, UserValidator>();
            services.AddValidatorsFromAssemblyContaining<UserValidator>();

            return services;
        }
    }
}
