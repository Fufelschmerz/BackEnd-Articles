using Articles.Core.Common.Exceptions;
using Articles.Core.Models;
using System.Text;

namespace Articles.Core.Services.Sections;

public static class SectionHelper
{
    public static string BuildName(IReadOnlyList<TagModel> tags)
    {
        var sb = new StringBuilder();

        for (int i = 0; i < tags.Count; i++)
        {
            var tagName = tags[i].Name;

            var nextLength = sb.Length + tagName.Length;

            if (nextLength > SectionModel.MaxLengthName)
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

        var result = sb.ToString();

        if (string.IsNullOrWhiteSpace(result))
        {
            throw new ValidationException("Не удалось сгенерировать название раздела");
        }

        return result;
    }
}