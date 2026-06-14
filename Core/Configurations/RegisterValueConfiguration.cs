using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestProject.Models;


namespace TestProject.Configurations;

public class RegisterValueConfiguration : IEntityTypeConfiguration<RegisterValueEntity>
{
    public void Configure(EntityTypeBuilder<RegisterValueEntity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Register).WithMany(x => x.Values);
    }
}
