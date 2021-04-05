using eBug.Domain.Entities;

namespace eBug.Application.Abstractions.Persistence
{
    public interface IBugRepository : IAsyncRepository<Bug>
    {
    }
}