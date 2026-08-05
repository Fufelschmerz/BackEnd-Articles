using Articles.Domain.Entities;
using Articles.WebApi.Controllers.Articles.Dto;
using Articles.WebApi.Controllers.Tags.Mappings;

namespace Articles.WebApi.Controllers.Articles.Mappings;

internal static class ArticleModelExtensions
{
    extension(Article article)
    {
        internal ArticleDto ToDto()
        {
            var tags = article.Section?.Tags.Select(t => t.ToDto());

            if (tags is null)
            {
                throw new ArgumentNullException(nameof(tags));
            }

            var dto = new ArticleDto(article.Id, article.Name, article.CreatedAt, article.ModifyAt, tags);

            return dto;
        }

        internal ArticleListItemDto ToListItemDto()
        {
            return new ArticleListItemDto(article.Id, article.Name, article.CreatedAt, article.ModifyAt);
        }
    }
}