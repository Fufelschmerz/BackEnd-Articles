using System.Data;
using Articles.Application.Common.Data.Transaction;
using Articles.Application.Services;
using Articles.Domain.Common.Exceptions;
using Articles.Domain.Contracts.Repositories;
using Articles.Domain.Entities;
using NSubstitute;
using Xunit;

namespace Articles.UnitTests.Application.Services.Articles;

public sealed class ArticleServiceTests
{
    private readonly ISectionRepository _sectionRepository = Substitute.For<ISectionRepository>();
    private readonly IArticleRepository _articleRepository = Substitute.For<IArticleRepository>();
    private readonly ITransactionManager _transactionManager = Substitute.For<ITransactionManager>();
    private readonly ITagRepository _tagRepository = Substitute.For<ITagRepository>();

    private readonly ArticleService _service;

    public ArticleServiceTests()
    {
        _service = new ArticleService(
            _sectionRepository,
            _articleRepository,
            _transactionManager,
            _tagRepository
        );
    }

    [Fact]
    public async Task CreateAsync_CreatesArticle_WhenSectionExists()
    {
        // arrange
        var tagIds = new[]
        {
            Guid.NewGuid()
        };
        var sectionId = Guid.NewGuid();
        var articleId = Guid.NewGuid();
        var transaction = Substitute.For<ITransaction>();
        _transactionManager.BeginTransactionAsync(IsolationLevel.RepeatableRead).Returns(Task.FromResult(transaction));

        _sectionRepository.GetExistingSectionIdAsync(Arg.Any<IReadOnlyList<Guid>>(), Arg.Any<CancellationToken>())
            .Returns(sectionId);

        _articleRepository.CreateAsync(Arg.Any<Article>(), Arg.Any<CancellationToken>())
            .Returns(articleId);

        // act
        var result = await _service.CreateAsync("Test Article", tagIds);

        // assert
        Assert.Equal(articleId, result);
        await transaction.Received(1).CommitAsync();
    }

    [Fact]
    public async Task CreateAsync_CreatesSection_WhenNotExists()
    {
        // arrange
        var tagIds = new[]
        {
            Guid.NewGuid()
        };
        var transaction = Substitute.For<ITransaction>();
        _transactionManager.BeginTransactionAsync(IsolationLevel.RepeatableRead).Returns(Task.FromResult(transaction));

        _sectionRepository.GetExistingSectionIdAsync(Arg.Any<IReadOnlyList<Guid>>(), Arg.Any<CancellationToken>())
            .Returns((Guid?)null);

        var tags = new List<Tag>
        {
            new()
            {
                Id = tagIds[0],
                Name = "tag1"
            }
        };

        _tagRepository.GetListAsync(Arg.Any<IEnumerable<Guid>>(), Arg.Any<CancellationToken>())
            .Returns(tags);

        var createdSectionId = Guid.NewGuid();
        _sectionRepository.CreateAsync(Arg.Any<Section>(), Arg.Any<CancellationToken>())
            .Returns(createdSectionId);

        var articleId = Guid.NewGuid();
        _articleRepository.CreateAsync(Arg.Any<Article>(), Arg.Any<CancellationToken>())
            .Returns(articleId);

        // act
        var result = await _service.CreateAsync("Test Article", tagIds);

        // assert
        Assert.Equal(articleId, result);
        await _sectionRepository.Received(1).CreateAsync(Arg.Any<Section>(), Arg.Any<CancellationToken>());
        await transaction.Received(1).CommitAsync();
    }

    [Fact]
    public async Task CreateAsync_ThrowsValidationException_WhenTagCountExceedsMax()
    {
        // arrange
        var tags = Enumerable.Range(0, Section.MAX_LENGTH_NAME + 1).Select(_ => Guid.NewGuid()).ToArray();

        // act & assert
        await Assert.ThrowsAsync<ArgumentException>(() => _service.CreateAsync("Test", tags));
    }

    [Fact]
    public async Task GetByIdAsync_ReturnsArticle_WhenFound()
    {
        // arrange
        var articleId = Guid.NewGuid();

        var article = new Article("test", Guid.NewGuid())
        {
            Id = articleId
        };

        _articleRepository.GetOrDefaultByIdAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>())
            .Returns(article);

        // act
        var result = await _service.GetByIdAsync(articleId);

        // assert
        Assert.Equal(article, result);
    }

    [Fact]
    public async Task GetByIdAsync_ThrowsEntityNotFoundException_WhenNotFound()
    {
        // arrange
        var articleId = Guid.NewGuid();
        _articleRepository.GetOrDefaultByIdAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>())
            .Returns((Article?)null);

        // act & assert
        await Assert.ThrowsAsync<EntityNotFoundException>(() => _service.GetByIdAsync(articleId));
    }
}