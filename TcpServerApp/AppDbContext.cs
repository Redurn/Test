using Microsoft.EntityFrameworkCore;
using TestProject.Configurations;
using TestProject.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TcpServerApp;

public class AppDbContext : DbContext
{
    public DbSet<InterfaceEntity> Interfaces { get; set; }
    public DbSet<DeviceEntity> Devices { get; set; }
    public DbSet<RegisterEntity> Registers { get; set; }
    public DbSet<RegisterValueEntity> RegisterValues { get; set; }
    public DbSet<LogEntity> Logs { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
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
