using System.Reflection;
using eBug.Application.Abstractions.Persistence;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace eBug.Application
{
    public static class ApplicationRegistration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}