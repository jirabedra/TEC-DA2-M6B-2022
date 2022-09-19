using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WorldCupOrganization.DataAccess.Context;
using WorldCupOrganization.DataAccess.Interfaces.Contracts;
using WorldCupOrganization.DataAccess.Repositories;
using WorldCupOrganization.Interfaces.Contracts;
using WorldCupOrganization.Logic.Logics;

namespace WorldCupOrganization.ServiceFactory.Factory
{
    public static class ServiceExtension
    {
        public static void AddServices(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IPlayerLogic, PlayerLogic>();
            services.AddScoped<ICoachLogic, CoachLogic>();
            services.AddScoped<ICoachRepository, CoachRepository>();
            services.AddDbContext<DbContext, WorldCupOrganizationContext>(o => o.UseSqlServer(connectionString));
        }
    }
}
