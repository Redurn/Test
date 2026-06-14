using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestProject.Models;


namespace TestProject.Configurations;

public class InterfaceConfiguration : IEntityTypeConfiguration<InterfaceEntity>
{
    public void Configure(EntityTypeBuilder<InterfaceEntity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.Devices).WithOne(x => x.Interface).HasForeignKey(x => x.InterfaceId);
    }
}
