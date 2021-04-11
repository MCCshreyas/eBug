using System.Threading;
using System.Threading.Tasks;
using eBug.Domain.Common;
using eBug.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace eBug.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Bug> Bugs { get; set; }
        public DbSet<Project> Projects { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        /*
                        entry.Entity.CreatedBy = _currentUserService.UserId;
                        entry.Entity.Created = _dateTime.Now;
                        */
                        break;

                    case EntityState.Modified:
                        /*
                        entry.Entity.LastModifiedBy = _currentUserService.UserId;
                        entry.Entity.LastModified = _dateTime.Now;
                        */
                        break;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}