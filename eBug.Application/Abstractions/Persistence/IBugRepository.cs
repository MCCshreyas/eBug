using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using eBug.Domain.Entities;

namespace eBug.Application.Abstractions.Persistence
{
    public interface IBugRepository : IAsyncRepository<Bug>
    {
        Task<bool> IsBugExistsAsync(Guid bugId, CancellationToken token);
        Task<List<Bug>> GetAllBugsByProjectIdAsync(Guid projectId, CancellationToken token);
    }
}