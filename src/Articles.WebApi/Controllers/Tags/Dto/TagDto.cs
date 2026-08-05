namespace Articles.WebApi.Controllers.Tags.Dto;

/// <summary>
///     Тэг
/// </summary>
/// <param name="Id">Id тэга</param>
/// <param name="Name">Название тэга</param>
public sealed record TagDto(Guid Id,
    string Name);