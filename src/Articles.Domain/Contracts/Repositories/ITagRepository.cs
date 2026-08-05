using Articles.Domain.Contracts.Repositories.Models.Queries.Tags;
using Articles.Domain.Entities;

namespace Articles.Domain.Contracts.Repositories;

public interface ITagRepository
{
    Task<Guid> CreateAsync(Tag tag,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyList<Tag>> GetListAsync(IEnumerable<Guid> ids,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyList<Tag>> GetListAsync(TagGetListQuery criteria,
        CancellationToken cancellationToken = default);
}