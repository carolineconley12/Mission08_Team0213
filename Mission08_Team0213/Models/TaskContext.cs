using Microsoft.EntityFrameworkCore;

namespace Mission08_Team0213.Models
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options) 
        { 
        }

        public DbSet<TaskTemplate> Tasks { get; set;}
    }
}
