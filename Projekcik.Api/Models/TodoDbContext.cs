using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace Projekcik.Api.Models
{
    public class TodoDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Constants.DbConnectionString);
            options.EnableSensitiveDataLogging(true);
            options.LogTo((s) => Debug.WriteLine(s));
        }

        public DbSet<Todo> Todos { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var user = modelBuilder.Entity<User>();
            user.HasIndex(x => x.Login).IsUnique();
            user.Property(x => x.Login).IsRequired();
            user.Property(x => x.Password).IsRequired();

            var todo = modelBuilder.Entity<Todo>();
            todo.HasOne(x => x.User).WithMany(x => x.Todos).IsRequired();
            todo.HasOne(x => x.Category).WithMany(x => x.Todos).IsRequired(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}