using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace eBug.Application.Abstractions.Persistence
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id, CancellationToken token);
        Task<List<T>> ListAllAsync(CancellationToken token);
        Task<T> AddAsync(T entity, CancellationToken token);
        Task UpdateAsync(T entity, CancellationToken token);
        Task DeleteAsync(T entity, CancellationToken token);
        Task<IReadOnlyList<T>> GetPagedResponseAsync(int page, int size, CancellationToken token);
    }
}