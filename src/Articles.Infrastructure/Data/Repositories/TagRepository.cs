using Articles.Domain.Contracts.Repositories;
using Articles.Domain.Contracts.Repositories.Models.Queries.Tags;
using Articles.Domain.Entities;
using Articles.Infrastructure.Data.Mappings;
using Articles.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Articles.Infrastructure.Data.Repositories;

internal sealed class TagRepository(AppDbContext dbContext) : ITagRepository
{
    public async Task<Guid> CreateAsync(Tag tag,
        CancellationToken cancellationToken = default)
    {
        var model = new TagDbModel
        {
            Name = tag.Name,
            NormalizedName = tag.NormalizedName
        };

        dbContext.Tags.Add(model);

        await dbContext.SaveChangesAsync(cancellationToken);

        return model.Id;
    }

    public async Task<IReadOnlyList<Tag>> GetListAsync(IEnumerable<Guid> ids,
        CancellationToken cancellationToken = default)
    {
        var models = await dbContext.Tags
            .AsNoTracking()
            .Where(t => ids.Contains(t.Id))
            .ToArrayAsync(cancellationToken);

        return models.Select(m => m.ToEntity()).ToArray();
    }

    public async Task<IReadOnlyList<Tag>> GetListAsync(TagGetListQuery criteria,
        CancellationToken cancellationToken = default)
    {
        var query = dbContext.Tags
            .AsNoTracking()
            .Where(t => EF.Functions.ToTsVector("russian", t.Name)
                .Matches(EF.Functions.PhraseToTsQuery("russian", criteria.Name)));

        var models = await query.Take(criteria.Count).ToArrayAsync(cancellationToken);
        return models.Select(m => m.ToEntity()).ToArray();
    }
}