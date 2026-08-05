using Articles.Domain.Contracts.Repositories.Models.Queries.Sections;
using Articles.Domain.Entities;

namespace Articles.Domain.Contracts.Repositories;

/// <summary>
///     Репозиторий для работы с разделами
/// </summary>
public interface ISectionRepository
{
    Task<Guid> CreateAsync(Section section,
        CancellationToken cancellationToken = default);

    Task<SectionGetListQueryResult> GetListAsync(SectionGetListQuery criteria,
        CancellationToken cancellationToken = default);

    Task<Section?> GetOrDefaultByTagsAsync(IReadOnlyList<Guid> tagIds,
        CancellationToken cancellationToken = default);

    Task<Guid?> GetExistingSectionIdAsync(IReadOnlyList<Guid> tagIds,
        CancellationToken cancellationToken = default);
}