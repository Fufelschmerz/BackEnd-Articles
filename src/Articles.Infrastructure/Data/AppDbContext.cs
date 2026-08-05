using Articles.Application.Common.Exceptions;
using Articles.Domain.Common.Exceptions;
using Articles.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Articles.Infrastructure.Data;

public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<TagDbModel> Tags { get; set; }

    public DbSet<ArticleDbModel> Articles { get; set; }

    public DbSet<SectionDbModel> Sections { get; set; }

    public DbSet<SectionTagDbModel> SectionTags { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        try
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateException ex) when (ex.InnerException is PostgresException pgEx)
        {
            switch (pgEx.SqlState)
            {
                case PostgresErrorCodes.UniqueViolation:
                    throw new EntityDuplicateException(
                        "Нарушение уникальности данных. Запись с такими значениями уже существует.");
                case PostgresErrorCodes.SerializationFailure:
                    throw new ConcurrencyException(
                        "Конфликт параллельного доступа к данным. Пожалуйста, повторите операцию.");
                default:
                    throw;
            }
        }
    }
}