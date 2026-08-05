using Articles.Domain.Contracts.Repositories;
using Articles.Domain.Contracts.Repositories.Models.Queries.Sections;
using Articles.Domain.Entities;
using Articles.Infrastructure.Data.Mappings;
using Articles.Infrastructure.Data.Models;
using Articles.Infrastructure.Data.Pagination.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Articles.Infrastructure.Data.Repositories;

internal sealed class SectionRepository(AppDbContext dbContext) : ISectionRepository
{
    public async Task<Guid> CreateAsync(Section section,
        CancellationToken cancellationToken = default)
    {
        var model = new SectionDbModel
        {
            Name = section.Name,
        };

        dbContext.Sections.Add(model);

        var sectionTags = section.Tags.Select((t,
            i) => new SectionTagDbModel
        {
            SectionId = model.Id,
            TagId = t.Id,
            SortNumber = i
        });

        dbContext.SectionTags.AddRange(sectionTags);
        await dbContext.SaveChangesAsync(cancellationToken);

        return model.Id;
    }

    public async Task<SectionGetListQueryResult> GetListAsync(SectionGetListQuery criteria,
        CancellationToken cancellationToken = default)
    {
        var query = dbContext.Sections
            .AsNoTracking()
            .Include(s => s.Articles)
            .Include(s => s.Tags)
            .Select(s => new
            {
                Section = s,
                ArticleCount = s.Articles.Count
            })
            .OrderByDescending(x => x.ArticleCount);

        var page = await query.ToPageAsync(criteria.PageSize,
            criteria.PageNumber,
            cancellationToken);

        var sections = page.Items.Select(m => m.Section.ToEntity()).ToArray();
        return new SectionGetListQueryResult(page.Number, page.Size, page.Total, sections);
    }

    public async Task<Section?> GetOrDefaultByTagsAsync(IReadOnlyList<Guid> tagIds,
        CancellationToken cancellationToken = default)
    {
        var models = await dbContext.Sections
            .AsNoTracking()
            .Include(s => s.Tags)
            .Include(s => s.Articles.OrderByDescending(a => a.ModifyAt ?? a.CreatedAt))
            .FirstOrDefaultAsync(s => s.Tags.Count == tagIds.Count &&
                                      s.Tags.Any(t => tagIds.Contains(t.Id)),
                cancellationToken);

        return models?.ToEntity();
    }

    public async Task<Guid?> GetExistingSectionIdAsync(IReadOnlyList<Guid> tagIds,
        CancellationToken cancellationToken = default)
    {
        var section = await dbContext.Sections
            .AsNoTracking()
            .Where(s => s.Tags.Count == tagIds.Count &&
                        s.Tags.All(t => tagIds.Contains(t.Id)))
            .FirstOrDefaultAsync(cancellationToken);

        return section?.Id;
    }
}