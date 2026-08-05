using Articles.Infrastructure.Data.Models.Common.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Articles.Infrastructure.Data.Models;

public sealed class ArticleDbModel : IHasId,
    IHasCreatedAt,
    IHasModifyAt,
    IHasName
{
    public Guid Id { get; set; }

    [MaxLength(256)]
    public required string Name { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? ModifyAt { get; set; }

    public Guid SectionId { get; set; }

    public SectionDbModel? Section { get; set; }
}