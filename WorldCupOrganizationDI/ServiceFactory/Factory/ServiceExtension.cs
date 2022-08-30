using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
