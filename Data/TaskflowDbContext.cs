using Microsoft.EntityFrameworkCore;
using Taskflow.Models;

namespace Taskflow.Data;

public class TaskflowDbContext : DbContext
{
    public TaskflowDbContext(DbContextOptions<TaskflowDbContext> options)
        : base(options) { }

    public DbSet<TaskItem> Tasks { get; set; } = null!;
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaskItem>(entity =>
        {
            entity.HasKey(t => t.Id);
            entity.Property(t => t.Title).IsRequired().HasMaxLength(200);
            entity.Property(t => t.CreatedAt).HasDefaultValueSql("NOW()");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(u => u.Id);
            entity.HasIndex(u => u.Username).IsUnique();
            entity.Property(u => u.Username).IsRequired().HasMaxLength(100);
        });
    }
}

