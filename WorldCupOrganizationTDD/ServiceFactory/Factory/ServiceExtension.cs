using Microsoft.Extensions.DependencyInjection;
using WorldCupLogic.Logics;
using WorldCupLogicInterface.Interfaces;

namespace ServiceFactory.Factory
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IPlayerLogic, PlayerLogic>();
            return services;
        }
    }
}
