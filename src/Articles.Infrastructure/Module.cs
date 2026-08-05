using Articles.Application.Common.Data.AdvisoryLock;
using Articles.Application.Common.Data.Transaction;
using Articles.Domain.Contracts.Repositories;
using Articles.Infrastructure.Data;
using Articles.Infrastructure.Data.AdvisoryLock;
using Articles.Infrastructure.Data.Repositories;
using Articles.Infrastructure.Data.Transaction;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Articles.Infrastructure;

public static class Module
{
    public static void ConfigureServices(IServiceCollection services,
        IConfiguration configuration)
    {
        AddDataBaseInfrastructure(services, configuration);
        AddRepositories(services);
    }

    private static void AddDataBaseInfrastructure(IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<AppDbContext>(options => options
            .UseNpgsql(connectionString)
            .UseSnakeCaseNamingConvention());

        services.AddScoped<IAdvisoryLockFactory, AdvisoryLockFactory>();
        services.AddScoped<ITransactionManager, TransactionManager>();
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IArticleRepository, ArticleRepository>();
        services.AddScoped<ITagRepository, TagRepository>();
        services.AddScoped<ISectionRepository, SectionRepository>();
    }
}