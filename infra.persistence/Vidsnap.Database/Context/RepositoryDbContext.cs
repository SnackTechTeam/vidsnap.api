using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Vidsnap.Database.Entities;

namespace Vidsnap.Database.Context;

[ExcludeFromCodeCoverage]
public class RepositoryDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Video> Videos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RepositoryDbContext).Assembly);
    }
}