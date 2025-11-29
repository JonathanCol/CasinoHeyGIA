using CasinoHeyGIA.Application.Command;
using CasinoHeyGIA.Application.Interfaces;
using CasinoHeyGIA.Infraestructure.Redis;

namespace CasinoHeyGIA
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAplication(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddMemoryCache();
            services.AddTransient<ICacheService, MemoryCacheServiceRepository>();
            services.AddMediatR(reg =>
            {
                reg.RegisterServicesFromAssemblyContaining<CrearRuletaCommand>();
                reg.RegisterServicesFromAssemblyContaining<AperturaRuletaCommand>();

            });
            return services;
        
        }
    }
}
