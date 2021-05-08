using System.Threading;
using System.Threading.Tasks;
using eBug.Domain.Entities;

namespace eBug.Application.Abstractions.Persistence
{
    public interface IBugRepository : IAsyncRepository<Bug>
    {
        Task<bool> IsBugExists(int bugId, CancellationToken token);
    }
}