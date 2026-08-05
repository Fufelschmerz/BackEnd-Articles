namespace Articles.WebApi.Controllers.CatalogArticles.Requests;

/// <summary>
///     Запрос на получение разделов
/// </summary>
/// <param name="TagIds">Список тэгов</param>
public sealed record SectionGetRequest(IReadOnlyList<Guid> TagIds);