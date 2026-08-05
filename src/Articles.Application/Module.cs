using Articles.Application.Services;
using Articles.Application.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Articles.Application;

public static class Module
{
    public static void ConfigureServices(IServiceCollection services,
        IConfiguration configuration)
    {
        AddServices(services);
    }

    private static void AddServices(IServiceCollection services)
    {
        services.AddScoped<IArticleService, ArticleService>();
        services.AddScoped<ISectionService, SectionService>();
        services.AddScoped<ITagService, TagService>();
    }
}