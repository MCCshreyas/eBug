using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using eBug.Application.Abstractions.Persistence;
using Microsoft.EntityFrameworkCore;

namespace eBug.Persistence.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public virtual async Task<T> GetByIdAsync(Guid id, CancellationToken token)
        {
            return await _context.Set<T>().FindAsync(new object[]{ id }, cancellationToken: token);
        }

        public virtual async Task<List<T>> ListAllAsync(CancellationToken token)
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync(cancellationToken: token);
        }

        public virtual async Task<T> AddAsync(T entity, CancellationToken token)
        {
             await _context.Set<T>().AddAsync(entity, token);
             await _context.SaveChangesAsync(token);
             return entity;
        }

        public virtual async Task UpdateAsync(T entity, CancellationToken token)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync(token);
        }

        public virtual async Task DeleteAsync(T entity, CancellationToken token)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync(token);        
        }

        public virtual async Task<IReadOnlyList<T>> GetPagedResponseAsync(int page, int size, CancellationToken token)
        {
            return await _context.Set<T>().Skip((page - 1) * size).Take(size)
                .AsNoTracking()
                .ToListAsync(token);
        }
    }
}