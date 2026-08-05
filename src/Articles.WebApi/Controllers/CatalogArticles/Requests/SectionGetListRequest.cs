namespace Articles.WebApi.Controllers.CatalogArticles.Requests;

/// <summary>
///     Запрос на получение страницы разделов
/// </summary>
/// <param name="PageSize">Размер страницы</param>
/// <param name="PageNumber">Номер страницы</param>
public sealed record SectionGetListRequest(int PageSize,
    int PageNumber);