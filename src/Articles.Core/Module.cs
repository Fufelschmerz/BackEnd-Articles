using Articles.Core.Services.Articles;
using Articles.Core.Services.Articles.Interfaces;
using Articles.Core.Services.Sections;
using Articles.Core.Services.Sections.Interfaces;
using Articles.Core.Services.Tags;
using Articles.Core.Services.Tags.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Articles.Core;

public static class Module
{
    public static void RegisterIn(IServiceCollection services)
    {
        services.AddScoped<ITagService, TagService>();
        services.AddScoped<IArticleService, ArticleService>();
        services.AddScoped<ISectionService, SectionService>();
    }
}