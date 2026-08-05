using Articles.Infrastructure.Data.Models.Common.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Articles.Infrastructure.Data.Models;

public sealed class TagDbModel : IHasId
{
    public Guid Id { get; init; }

    [MaxLength(256)]
    public required string Name { get; init; }

    [MaxLength(256)]
    public required string NormalizedName { get; init; }

    public ICollection<SectionDbModel> Sections { get; init; } = [];

    public ICollection<SectionTagDbModel> SectionTags { get; init; } = [];
}