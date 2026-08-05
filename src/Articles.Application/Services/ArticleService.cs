using Articles.Application.Common.Data.Transaction;
using Articles.Application.Services.Interfaces;
using Articles.Domain.Common.Exceptions;
using Articles.Domain.Contracts.Repositories;
using Articles.Domain.Entities;
using System.Data;

namespace Articles.Application.Services;

public sealed class ArticleService(ISectionRepository sectionRepository,
    IArticleRepository articleRepository,
    ITransactionManager transactionManager,
    ITagRepository tagRepository) : IArticleService
{
    public async Task<Guid> CreateAsync(string name,
        IReadOnlyList<Guid> tagIds,
        CancellationToken cancellationToken = default)
    {
        using var transaction = await transactionManager.BeginTransactionAsync(IsolationLevel.RepeatableRead);

        try
        {
            var sectionId = await GetOrCreateSectionAsync(tagIds, cancellationToken);

            var article = new Article(name, sectionId);

            var id = await articleRepository.CreateAsync(article, cancellationToken);

            await transaction.CommitAsync();

            return id;
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public async Task UpdateAsync(Guid id,
        string name,
        IReadOnlyList<Guid> tagIds,
        CancellationToken cancellationToken = default)
    {
        using var transaction = await transactionManager.BeginTransactionAsync(IsolationLevel.RepeatableRead);

        try
        {
            var sectionId = await GetOrCreateSectionAsync(tagIds, cancellationToken);

            var articleUpdateCommand = new Article(name, sectionId)
            {
                Id = id
            };

            await articleRepository.UpdateAsync(articleUpdateCommand, cancellationToken);

            await transaction.CommitAsync();
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public Task<int> DeleteAsync(Guid id,
        CancellationToken cancellationToken = default)
    {
        return articleRepository.DeleteAsync(id, cancellationToken);
    }

    public async Task<Article> GetByIdAsync(Guid id,
        CancellationToken cancellationToken = default)
    {
        var article = await articleRepository.GetOrDefaultByIdAsync(id, cancellationToken);

        return article ?? throw new EntityNotFoundException($"Статья с id: {id} не найдена");
    }

    private async Task<Guid> GetOrCreateSectionAsync(IReadOnlyList<Guid> tagIds,
        CancellationToken cancellationToken = default)
    {
        var sectionId = await sectionRepository.GetExistingSectionIdAsync(tagIds, cancellationToken);

        if (sectionId != null)
        {
            return sectionId.Value;
        }

        var tags = await tagRepository.GetListAsync(tagIds, cancellationToken);
        var section = new Section(tags);
        return await sectionRepository.CreateAsync(section, cancellationToken);
    }
}