using System.ComponentModel.DataAnnotations;

namespace Articles.WebApi.Controllers.Tags.Requests;

/// <summary>
///     Запрос для создания тэга
/// </summary>
public sealed record TagCreateRequest
{
    /// <summary>
    ///     Название тэга
    /// </summary>
    [Required]
    [MaxLength(256)]
    public required string Name { get; init; }
}