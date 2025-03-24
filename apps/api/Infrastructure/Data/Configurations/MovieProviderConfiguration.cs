using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieStore.Api.Domain.Entities;

namespace MovieStore.Api.Infrastructure.Data.Configurations;

public class MovieProviderConfiguration : IEntityTypeConfiguration<MovieProvider>
{
    public void Configure(EntityTypeBuilder<MovieProvider> builder)
    {
    }
}