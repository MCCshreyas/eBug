using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<bool> IsBugExistsAsync(Guid bugId, CancellationToken token)
        {
            var result = await _context.Projects.AnyAsync(x => x.Id == bugId, token);
            return result;
        }

        public async Task<List<Bug>> GetAllBugsByProjectIdAsync(Guid projectId, CancellationToken token)
        {
            var bugsListByProjectId = await _context.Bugs.Where(x => x.ProjectId == projectId)
                                    .ToListAsync(token);

            return bugsListByProjectId;
        }
    }
}