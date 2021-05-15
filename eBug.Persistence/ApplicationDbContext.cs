using System;
using System.Threading;
using System.Threading.Tasks;
using eBug.Domain.Common;
using eBug.Domain.Entities;
using eBug.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eBug.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Bug> Bugs { get; set; }
        public DbSet<Project> Projects { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // This base call is important for Identity user 
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<IdentityRole>()
                .HasData(new IdentityRole() { Name = "Admin", NormalizedName = "Admin".ToUpper() }, 
                    new IdentityRole() { Name = "Staff", NormalizedName = "Staff".ToUpper() }, 
                    new IdentityRole() { Name = "Customer", NormalizedName = "Customer".ToUpper() });
            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = "Test";
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = "Test2";
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}