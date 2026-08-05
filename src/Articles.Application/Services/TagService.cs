using Articles.Application.Services.Interfaces;
using Articles.Domain.Contracts.Repositories;
using Articles.Domain.Contracts.Repositories.Models.Queries.Tags;
using Articles.Domain.Entities;

namespace Articles.Application.Services;

internal sealed class TagService(ITagRepository tagRepository) : ITagService
{
    public Task<Guid> CreateAsync(string name,
        CancellationToken cancellationToken = default)
    {
        var tag = new Tag
        {
            Name = name
        };

        return tagRepository.CreateAsync(tag, cancellationToken);
    }

    public Task<IReadOnlyList<Tag>> GetListAsync(string name,
        int count,
        CancellationToken cancellationToken = default)
    {
        var query = new TagGetListQuery(name,
            count);

        return tagRepository.GetListAsync(query, cancellationToken);
    }
}