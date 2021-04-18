using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eBug.Application.Abstractions.Persistence;
using eBug.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace eBug.Persistence.Repositories
{
    public class BugRepository : BaseRepository<Bug>, IBugRepository
    {
        public BugRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
    
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public virtual async Task<List<T>> ListAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public virtual async Task<T> AddAsync(T entity)
        {
             await _context.Set<T>().AddAsync(entity);
             await _context.SaveChangesAsync();
             return entity;
        }

        public virtual async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();        
        }

        public virtual async Task<IReadOnlyList<T>> GetPagedResponseAsync(int page, int size)
        {
            return await _context.Set<T>().Skip((page - 1) * size).Take(size)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}