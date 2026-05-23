using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestProject.Models;


namespace TestProject.Configurations;

public class RegisterConfiguration : IEntityTypeConfiguration<RegisterEntity>
{
    public void Configure(EntityTypeBuilder<RegisterEntity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Device).WithMany(x => x.Registers);
        builder.HasMany(x => x.Values).WithOne(x => x.Register).HasForeignKey(x => x.RegisterId);
    }
}
