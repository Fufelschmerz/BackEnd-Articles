namespace Articles.Core.Models;

/// <summary>
///     Тэг
/// </summary>
/// <param name="Id">Идентификатор</param>
/// <param name="Name">Название</param>
public sealed record TagModel(Guid Id,
    string Name);