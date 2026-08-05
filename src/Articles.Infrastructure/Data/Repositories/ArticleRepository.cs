using Articles.Domain.Common.Exceptions;
using Articles.Domain.Contracts.Repositories;
using Articles.Domain.Entities;
using Articles.Infrastructure.Data.Mappings;
using Articles.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Articles.Infrastructure.Data.Repositories;

internal sealed class ArticleRepository(AppDbContext dbContext) : IArticleRepository
{
    public async Task<Guid> CreateAsync(Article article,
        CancellationToken cancellationToken = default)
    {
        var model = new ArticleDbModel
        {
            Name = article.Name,
            SectionId = article.SectionId,
            CreatedAt = DateTime.UtcNow,
        };

        dbContext.Articles.Add(model);
        await dbContext.SaveChangesAsync(cancellationToken);
        return model.Id;
    }

    public async Task UpdateAsync(Article article,
        CancellationToken cancellationToken = default)
    {
        var updatedRows = await dbContext.Articles
            .Where(m => m.Id == article.Id)
            .ExecuteUpdateAsync(x =>
                    x.SetProperty(m => m.Name, m => article.Name)
                        .SetProperty(m => m.SectionId, m => article.SectionId)
                        .SetProperty(m => m.ModifyAt, m => DateTime.UtcNow),
                cancellationToken);

        if (updatedRows == 0)
        {
            throw new EntityNotFoundException($"Статья с id: {article.Id} не найдена");
        }
    }

    public Task<int> DeleteAsync(Guid id,
        CancellationToken cancellationToken = default)
    {
        return dbContext.Articles
            .Where(e => e.Id == id)
            .ExecuteDeleteAsync(cancellationToken);
    }

    public async Task<Article?> GetOrDefaultByIdAsync(Guid id,
        CancellationToken cancellationToken = default)
    {
        var model = await dbContext.Articles
            .AsNoTracking()
            .Include(a => a.Section)
            .ThenInclude(s => s!.SectionTags.OrderBy(x => x.SortNumber))
            .ThenInclude(s => s.Tag)
            .SingleOrDefaultAsync(a => a.Id == id, cancellationToken);

        return model?.ToEntity();
    }
}