using Articles.Domain.Entities;
using Articles.Infrastructure.Data.Models;

namespace Articles.Infrastructure.Data.Mappings;

internal static class ArticleExtensions
{
    extension(ArticleDbModel model)
    {
        internal Article ToEntity()
        {
            var tags = model.Section?.SectionTags.Select(t => t.Tag!.ToEntity()).ToArray();

            if (tags is null)
            {
                throw new ArgumentNullException(nameof(tags));
            }

            var section = new Section(tags);
            return new Article(model.Name, section.Id)
            {
                Id = model.Id,
                CreatedAt = model.CreatedAt,
                ModifyAt = model.ModifyAt,
                Section = section
            };
        }

        internal Article ToListItemEntity()
        {
            return new Article(model.Name, model.SectionId)
            {
                Id = model.Id,
                CreatedAt = model.CreatedAt,
                ModifyAt = model.ModifyAt,
            };
        }
    }
}