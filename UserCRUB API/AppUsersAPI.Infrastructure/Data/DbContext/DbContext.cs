using Microsoft.EntityFrameworkCore;
using System.Reflection;
using AppUsersAPI.Infrastructure.Models;

namespace AppUsersAPI.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<UsersModel> Users { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        
    }
}