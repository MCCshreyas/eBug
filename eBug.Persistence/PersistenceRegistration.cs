using eBug.Application.Abstractions.Persistence;
using eBug.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eBug.Persistence
{
    public static class PersistenceRegistration
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(option =>
            {
                option.UseSqlServer(configuration["DatabaseConnection"]);
            });
            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IBugRepository, BugRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            return services;
        }
    }
}