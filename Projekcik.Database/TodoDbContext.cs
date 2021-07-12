using Microsoft.EntityFrameworkCore;
using Projekcik.Database.Models;

namespace Projekcik.Database
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options)
        : base(options)
        {

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