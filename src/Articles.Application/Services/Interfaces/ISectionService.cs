using Articles.Domain.Contracts.Repositories.Models.Queries.Sections;
using Articles.Domain.Entities;

namespace Articles.Application.Services.Interfaces;

/// <summary>
///     Сервис для работы с разделами
/// </summary>
public interface ISectionService
{
    /// <summary>
    ///     Получить список разделов
    /// </summary>
    /// <param name="pageSize">Размер страницы</param>
    /// <param name="pageNumber">Номер страницы</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Страница разделов</returns>
    Task<SectionGetListQueryResult> GetListAsync(int pageSize,
        int pageNumber,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Получить раздел по набору тэгов
    /// </summary>
    /// <param name="tagIds">Список тэгов</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Тэг</returns>
    Task<Section?> GetOrDefaultByTagsAsync(IReadOnlyList<Guid> tagIds,
        CancellationToken cancellationToken = default);
}