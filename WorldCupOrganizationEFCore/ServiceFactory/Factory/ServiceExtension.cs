using Microsoft.Extensions.DependencyInjection;
using WorldCupOrganization.Interfaces.Contracts;
using WorldCupOrganization.Logics;

namespace WorldCupOrganization.ServiceFactory.Factory
{
    public static class ServiceExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IPlayerLogic, PlayerLogic>();
        }
    }
}
