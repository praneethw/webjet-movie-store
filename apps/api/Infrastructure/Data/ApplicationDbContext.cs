using System.Reflection;
using Microsoft.EntityFrameworkCore;
using MovieStore.Api.Domain.Entities;

namespace MovieStore.Api.Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : DbContext(options)
{
    public DbSet<Movie> Movies => Set<Movie>();
    public DbSet<MovieProvider> MovieProviders => Set<MovieProvider>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}