using Microsoft.EntityFrameworkCore;
using Taskflow.Api.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Register EF Core with PostgreSQL
builder.Services.AddDbContext<TaskflowDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();
app.Run();