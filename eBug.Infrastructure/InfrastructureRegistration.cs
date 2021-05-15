using eBug.Application.Abstractions.Persistence;
using eBug.Infrastructure.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace eBug.Infrastructure
{
    public static class InfrastructureRegistration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IIdentityService, IdentityService>();
            return services;
        }
    }
}