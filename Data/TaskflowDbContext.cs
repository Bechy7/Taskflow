using Microsoft.EntityFrameworkCore;
using Taskflow.Api.Models;

namespace Taskflow.Api.Data;

public class TaskflowDbContext : DbContext
{
    public TaskflowDbContext(DbContextOptions<TaskflowDbContext> options)
        : base(options) { }

    public DbSet<TaskItem> Tasks { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaskItem>(entity =>
        {
            entity.HasKey(t => t.Id);
            entity.Property(t => t.Title).IsRequired().HasMaxLength(200);
            entity.Property(t => t.CreatedAt).HasDefaultValueSql("NOW()");
        });
    }
}

