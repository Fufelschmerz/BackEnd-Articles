using Articles.Application.Services.Interfaces;
using Articles.Domain.Contracts.Repositories;
using Articles.Domain.Contracts.Repositories.Models.Queries.Sections;
using Articles.Domain.Entities;

namespace Articles.Application.Services;

internal sealed class SectionService(ISectionRepository sectionRepository) : ISectionService
{
    public Task<SectionGetListQueryResult> GetListAsync(int pageSize,
        int pageNumber,
        CancellationToken cancellationToken = default)
    {
        var criteria = new SectionGetListQuery(pageSize, pageNumber);

        return sectionRepository.GetListAsync(criteria, cancellationToken);
    }

    public Task<Section?> GetOrDefaultByTagsAsync(IReadOnlyList<Guid> tagIds,
        CancellationToken cancellationToken = default)
    {
        return sectionRepository.GetOrDefaultByTagsAsync(tagIds, cancellationToken);
    }
}