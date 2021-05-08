using System.Threading;
using System.Threading.Tasks;
using eBug.Application.Abstractions.Persistence;
using eBug.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace eBug.Persistence.Repositories
{
    public class BugRepository : BaseRepository<Bug>, IBugRepository
    {
        private readonly ApplicationDbContext _context;

        public BugRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> IsBugExists(int bugId, CancellationToken token)
        {
            return await _context.Projects.AnyAsync(x => x.Id == bugId, token);
        }
    }
}