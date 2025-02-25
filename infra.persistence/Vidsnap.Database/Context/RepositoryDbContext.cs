using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using vidsnap.database.Entities;

namespace vidsnap.database.Context;

[ExcludeFromCodeCoverage]
public class RepositoryDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Video> Videos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RepositoryDbContext).Assembly);
    }
}