using CasinoHeyGIA.Application.Command;
using CasinoHeyGIA.Application.Interfaces;
using CasinoHeyGIA.Infraestructure.Redis;

namespace CasinoHeyGIA
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAplication(this IServiceCollection services, IConfiguration configuration) 
        {
            var prueba = configuration.GetSection("Redis")["ConnectionString"];
            services.AddMemoryCache();
            services.AddTransient<ICacheService, MemoryCacheServiceRepository>();
            services.AddMediatR(reg =>
            {
                reg.RegisterServicesFromAssemblyContaining<CrearRuletaCommand>();
            });
            return services;
        
        }
    }
}
