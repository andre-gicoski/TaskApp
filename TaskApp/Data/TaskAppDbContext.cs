using TaskApp.Models;
using Microsoft.EntityFrameworkCore;

namespace TaskApp.Data;

public class TaskAppDbContext : DbContext
{
    public TaskAppDbContext (DbContextOptions<TaskAppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Taskk> Taskks { get; set; }
    
}