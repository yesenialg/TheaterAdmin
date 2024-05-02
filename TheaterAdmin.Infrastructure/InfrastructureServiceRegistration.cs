using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Reflection;
using TheaterAdmin.Application.Contracts.Persistence;
using TheaterAdmin.Infrastructure.Persistence;
using TheaterAdmin.Infrastructure.Repositories;

namespace TheaterAdmin.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TheaterDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ConnectionString"))
            );

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IScheduleRepository, ScheduleRepository>();
            services.AddScoped<IManagerRepository, ManagerRepository>();
            return services;
        }
    }
}
