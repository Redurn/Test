using Microsoft.EntityFrameworkCore;
using TestProject.Configurations;
using TestProject.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TestProject;

public class AppDbContext : DbContext
{
    public DbSet<InterfaceEntity> Interfaces { get; set; }
    public DbSet<DeviceEntity> Devices { get; set; }
    public DbSet<RegisterEntity> Registers { get; set; }
    public DbSet<RegisterValueEntity> RegisterValues { get; set; }
    public DbSet<LogEntity> Logs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestProject.db");

        optionsBuilder.UseSqlite($"Data Source={path}");
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new InterfaceConfiguration());
        modelBuilder.ApplyConfiguration(new DeviceConfiguration());
        modelBuilder.ApplyConfiguration(new RegisterConfiguration());
        modelBuilder.ApplyConfiguration(new RegisterValueConfiguration());
        modelBuilder.ApplyConfiguration(new LogConfiguration());
        base.OnModelCreating(modelBuilder); 
    }
}
