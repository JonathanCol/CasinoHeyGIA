using CasinoHeyGIA.Application.Command;
using CasinoHeyGIA.Application.Interfaces;
using CasinoHeyGIA.Domain.Interfaces;
using CasinoHeyGIA.Infraestructure.Dapper;
using CasinoHeyGIA.Infraestructure.Redis;

namespace CasinoHeyGIA
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAplication(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddMemoryCache();
            services.AddTransient<ICacheService, MemoryCacheServiceRepository>();
            services.AddScoped<IUserRepository, UsersServiceRepository>();
            services.AddMediatR(reg =>
            {
                reg.RegisterServicesFromAssemblyContaining<RuletaCrearCommand>();
                reg.RegisterServicesFromAssemblyContaining<RuletaAperturaCommand>();
                reg.RegisterServicesFromAssemblyContaining<RuletaCierreCommand>();
            });
            return services;
        
        }
    }
}
