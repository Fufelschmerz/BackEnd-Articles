namespace Articles.Domain.Contracts.Repositories.Models.Queries.Sections;

/// <summary>
///     Получить список разделов
/// </summary>
/// <param name="PageSize">Размер страницы</param>
/// <param name="PageNumber">Номер страницы</param>
public sealed record SectionGetListQuery(int PageSize,
    int PageNumber);