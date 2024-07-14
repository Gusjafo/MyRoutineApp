using Application.Interfaces;
using Application.Services;
using Domain.Interfaces;
using Infrastructure.Data.Repositories;
using Infrastructure.Data.UnitOfWork;

namespace Presentation
{
    public static class Dependency
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ISessionService, SessionService>();
            services.AddScoped<IPeriodService, PeriodService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ISessionRepository, SessionRepository>();
            services.AddScoped<IPeriodRepository, PeriodRepository>();

            return services;
        }
    }
}
