namespace Articles.Domain.Contracts.Repositories.Models.Queries.Tags;

/// <summary>
///     Запрос для поиска тэгов
/// </summary>
/// <param name="Name">Название тэга</param>
/// <param name="Count">Количество элементов</param>
public sealed record TagGetListQuery(string Name,
    int Count);