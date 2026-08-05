using Articles.Infrastructure.Data.Models.Common.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Articles.Infrastructure.Data.Models;

public sealed class SectionDbModel : IHasId
{
    public Guid Id { get; init; }

    [MaxLength(1024)]
    public required string Name { get; init; }

    public ICollection<ArticleDbModel> Articles { get; init; } = [];

    public ICollection<TagDbModel> Tags { get; init; } = [];

    public ICollection<SectionTagDbModel> SectionTags { get; init; } = [];
}