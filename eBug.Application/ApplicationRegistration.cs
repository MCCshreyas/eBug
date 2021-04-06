using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

public static class ApplicationRegistration
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        return services;
    }
}