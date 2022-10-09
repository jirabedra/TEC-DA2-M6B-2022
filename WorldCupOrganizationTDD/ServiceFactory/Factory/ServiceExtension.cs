using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WorldCupLogic.Logics;
using WorldCupLogicInterface.Interfaces;

namespace ServiceFactory.Factory
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services, string conectionString)
        {
            services.AddScoped<IPlayerLogic, PlayerLogic>();
            return services;
        }
    }
}
