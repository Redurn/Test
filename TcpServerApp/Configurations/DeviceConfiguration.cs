using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestProject.Models;

namespace TestProject.Configurations;

internal class DeviceConfiguration : IEntityTypeConfiguration<DeviceEntity>
{
    public void Configure(EntityTypeBuilder<DeviceEntity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.Registers).WithOne(x => x.Device).HasForeignKey(x => x.DeviceId).OnDelete(DeleteBehavior.Cascade);
    }
}
