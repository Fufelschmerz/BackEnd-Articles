namespace Articles.WebApi.Controllers.Articles.Requests;

/// <summary>
///     Запрос для создания статьи
/// </summary>
public sealed record ArticleCreateRequest
{
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