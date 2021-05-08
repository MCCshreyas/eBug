using System.Threading;
using System.Threading.Tasks;
using eBug.Application.Abstractions.Persistence;
using eBug.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace eBug.Persistence.Repositories
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        private readonly ApplicationDbContext _context;

        public ProjectRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public Task<bool> IsProjectExists(int projectId, CancellationToken token)
        {
            return _context.Projects.AnyAsync(x => x.Id == projectId, token);
        }

        public Task<bool> UniqueProjectName(string projectName, CancellationToken token)
        {
            return _context.Projects.AnyAsync(x => x.Name == projectName, token);
        }
    }
}