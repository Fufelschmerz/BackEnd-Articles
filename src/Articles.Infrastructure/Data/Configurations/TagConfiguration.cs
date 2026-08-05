using Articles.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Articles.Infrastructure.Data.Configurations;

internal sealed class TagConfiguration : IEntityTypeConfiguration<TagDbModel>
{
    public void Configure(EntityTypeBuilder<TagDbModel> builder)
    {
        builder.HasIndex(t => t.NormalizedName).IsUnique();

        builder.HasIndex(t => t.Name)
            .HasMethod("GIN")
            .IsTsVectorExpressionIndex("russian");
    }
}