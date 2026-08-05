using Articles.Domain.Common.Interfaces;

namespace Articles.Domain.Entities;

/// <summary>
///     Статья
/// </summary>
public sealed class Article : IEntity,
    IHasCreatedAt,
    IHasModifyAt
{
    public Article(string name,
        Guid sectionId)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException(nameof(name));
        }

        Name = name;
        SectionId = sectionId;
    }

    public Guid Id { get; init; }

    public DateTime CreatedAt { get; init; }

    public DateTime? ModifyAt { get; init; }

    public Section? Section { get; init; }

    public string Name { get; private set; }

    public Guid SectionId { get; private set; }
}