using Articles.Domain.Common.Interfaces;

namespace Articles.Domain.Entities;

/// <summary>
///     Тэг
/// </summary>
public sealed class Tag : IEntity
{
    public Guid Id { get; init; }

    public required string Name { get; init; }

    public string NormalizedName => Name.ToLowerInvariant()
        .Replace(" ", string.Empty, StringComparison.InvariantCulture)
        .Trim();
}