using Microsoft.EntityFrameworkCore;
using TaskManager.Api.Models;

namespace TaskManager.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Esta es la tabla que se creará en la base de datos
        public DbSet<TaskItem> Tasks => Set<TaskItem>();
    }
}