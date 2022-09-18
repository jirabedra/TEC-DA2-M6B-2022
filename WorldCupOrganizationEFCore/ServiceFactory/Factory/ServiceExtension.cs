using Microsoft.Extensions.DependencyInjection;
using WorldCupLogic.Logics;
using WorldCupLogicInterface.Interfaces;

namespace ServiceFactory.Factory
{
    public static class ServiceExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IPlayerLogic, PlayerLogic>();
        }
    }
}
