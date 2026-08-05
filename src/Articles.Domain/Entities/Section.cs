using Articles.Domain.Common.Interfaces;
using System.Text;

namespace Articles.Domain.Entities;

/// <summary>
///     Раздел
/// </summary>
public sealed class Section : IEntity
{
    public const int MAX_LENGTH_NAME = 1024;

    public Section(IReadOnlyList<Tag> tags)
    {
        Name = BuildName(tags);
        Tags = tags;
    }

    public Guid Id { get; init; }

    public IReadOnlyList<Tag> Tags { get; init; }

    public IReadOnlyList<Article> Articles { get; init; } = [];

    public string Name { get; private set; }

    private static string BuildName(IReadOnlyList<Tag> tags)
    {
        if (tags.Count == 0)
        {
            throw new ArgumentException("Collection is empty", nameof(tags));
        }

        var sb = new StringBuilder();

        for (int i = 0; i < tags.Count; i++)
        {
            var tagName = tags[i].Name;

            var nextLength = sb.Length + tagName.Length;

            if (nextLength > MAX_LENGTH_NAME)
            {
                if (sb.Length > 0 && sb[^1] == ',')
                {
                    sb.Length--;
                }

                break;
            }

            sb.Append(tagName);

            if (i < tags.Count - 1)
            {
                sb.Append(',');
            }
        }

        return sb.ToString();
    }
}