using Microsoft.EntityFrameworkCore;
using RunnerApi.Domain.Entities;

namespace RunnerApi.Domain.Database;

public class DatabaseContext : DbContext
{
    public DbSet<RunnerEntity> Runners { get; set; }
    public DbSet<ActivityEntity> Activities { get; set; }
    public string DbPath { get; }
    public DatabaseContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "running.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}