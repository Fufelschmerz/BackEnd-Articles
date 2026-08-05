using Articles.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Articles.Infrastructure.Data.Configurations;

internal sealed class SectionConfiguration : IEntityTypeConfiguration<SectionDbModel>
{
    public void Configure(EntityTypeBuilder<SectionDbModel> builder)
    {
        builder.HasMany(e => e.Tags)
            .WithMany(e => e.Sections)
            .UsingEntity<SectionTagDbModel>();
    }
}