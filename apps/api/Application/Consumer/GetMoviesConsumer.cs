using AutoMapper;
using MassTransit;
using MovieStore.Api.Application.Common.Interfaces;
using MovieStore.Api.Application.Query;
using MovieStore.Api.Domain.Entities;

namespace MovieStore.Api.Application.Consumer;

public class GetMoviesConsumer(
    IMapper mapper,
    IGenericRepository<Movie> movieRepository) : IConsumer<GetMoviesRequest>
{
    public async Task Consume(ConsumeContext<GetMoviesRequest> context)
    {
        await context.RespondAsync(new GetMoviesResponse
        {
            Movies = mapper.Map<List<GetMovieDetail>>(await movieRepository.GetAllAsync(nameof(Movie.Providers)))
        });
    }
}