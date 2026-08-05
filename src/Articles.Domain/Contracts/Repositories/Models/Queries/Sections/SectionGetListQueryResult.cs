using Articles.Domain.Entities;

namespace Articles.Domain.Contracts.Repositories.Models.Queries.Sections;

/// <summary>
///     Страница разделов
/// </summary>
/// <param name="Number">Номер страницы</param>
/// <param name="Size">Размер страницы</param>
/// <param name="Total">Общее количество элементов</param>
/// <param name="Items">Элементы страницы</param>
public sealed record SectionGetListQueryResult(int Number,
    int Size,
    long Total,
    IReadOnlyList<Section> Items);