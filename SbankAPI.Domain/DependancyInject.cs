using Microsoft.Extensions.DependencyInjection;

namespace SbankAPI.Domain
{
    public static class DependancyInject
    {
        public static IServiceCollection AddDomianDI(this IServiceCollection service)
        {
            return service;
        }
    }
}
