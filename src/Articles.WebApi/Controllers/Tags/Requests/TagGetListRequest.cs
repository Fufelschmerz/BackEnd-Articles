using System.ComponentModel.DataAnnotations;

namespace Articles.WebApi.Controllers.Tags.Requests;

/// <summary>
///     Запрос для поиска тэгов
/// </summary>
public sealed record TagGetListRequest
{
    /// <summary>
    ///     Название искомого тэга
    /// </summary>
    [Required]
    [MaxLength(256)]
    public required string Name { get; init; }

    /// <summary>
    ///     Количество тэгов
    /// </summary>
    [Range(1, 1000)]
    public int Count { get; init; }
}