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
    }
}