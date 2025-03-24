using AutoMapper;
using MassTransit;
using MovieStore.Api.Application.Command;
using MovieStore.Api.Application.Common.Interfaces;
using MovieStore.Api.Domain.Entities;
using MovieStore.Api.Infrastructure.Extensions;

namespace MovieStore.Api.Application.Consumer;

public class SynchroniseMovieConsumer(
    IMapper mapper,
    IGenericRepository<Movie> movieRepository) : IConsumer<SynchroniseMovieCommand>
{
    public async Task Consume(ConsumeContext<SynchroniseMovieCommand> context)
    {
        var createMovieDetail = context.Message.SynchroniseMovieDetail;
        var movieHash = createMovieDetail.Title.ComputeSha256Hash();

        var movie = await movieRepository
            .FindOneOrDefaultAsync(x => x.Hash == movieHash, nameof(Movie.Providers));

        if (movie == null)
        {
            movie = mapper.Map<Movie>(createMovieDetail,
                opt => opt.AfterMap((src, dest) =>
                {
                    dest.Hash = movieHash;
                    dest.Providers.Add(mapper.Map<MovieProvider>(createMovieDetail));
                }));
            await movieRepository.AddAsync(movie);
        }
        else
        {
            var provider = movie.Providers.FirstOrDefault(x => x.ProviderName == createMovieDetail.ProviderName);
            if (provider == null)
                movie.Providers.Add(mapper.Map<MovieProvider>(createMovieDetail));
            else
                provider.Price = createMovieDetail.Price;

            await movieRepository.UpdateAsync(movie);
        }
    }
}