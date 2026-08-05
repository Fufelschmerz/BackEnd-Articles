using Articles.WebApi.Controllers.CatalogArticles.Dto;

namespace Articles.WebApi.Controllers.CatalogArticles.Responses;

/// <summary>
///     Ответ на получение страницы разделов
/// </summary>
/// <param name="Number">Номер страницы</param>
/// <param name="Size">Размер страницы</param>
/// <param name="Total">Общее количество элементов</param>
/// <param name="Items">Элементы страницы</param>
public sealed record SectionGetListResponse(int Number,
    int Size,
    long Total,
    IEnumerable<SectionListItemDto> Items);