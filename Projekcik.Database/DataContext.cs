using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Projekcik.Database.Models;

namespace Projekcik.Database
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Candidate> Candidates { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }

        #region ICreatedAt SaveChanges update

        private void UpdateTimestamps()
        {
            foreach (var entity in ChangeTracker.Entries().Where(p => p.State == EntityState.Added))
                if (entity.Entity is ICreatedAt created)
                    created.CreatedAt = DateTime.Now;

            foreach (var entity in ChangeTracker.Entries().Where(p => p.State == EntityState.Modified))
                if (entity.Entity is IModifiedAt updated)
                    updated.ModifiedAt = DateTime.Now;
        }

        public override int SaveChanges()
        {
            UpdateTimestamps();
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            UpdateTimestamps();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = new())
        {
            UpdateTimestamps();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            UpdateTimestamps();
            return base.SaveChangesAsync(cancellationToken);
        }

        #endregion
    }
}