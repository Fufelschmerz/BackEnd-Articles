namespace Articles.WebApi.Controllers.Articles.Requests;

/// <summary>
///     Запрос для обновления статьи
/// </summary>
public sealed record ArticleUpdateRequest
{
    /// <summary>
    ///     Идентификатор статьи
    /// </summary>
    public required Guid Id { get; init; }

    /// <summary>
    ///     Название статьи
    /// </summary>
    public required string Name { get; init; }

    //TODO: валидация что список тэгов не пустой

    /// <summary>
    ///     Идентификаторы тэгов
    /// </summary>
    public required IReadOnlyList<Guid> TagIds { get; init; }
}