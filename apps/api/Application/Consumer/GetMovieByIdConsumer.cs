using AutoMapper;
using MassTransit;
using MovieStore.Api.Application.Common.Interfaces;
using MovieStore.Api.Application.Query;
using MovieStore.Api.Domain.Entities;

namespace MovieStore.Api.Application.Consumer;

public class GetMovieByIdConsumer(
    IMapper mapper,
    IGenericRepository<Movie> movieRepository) : IConsumer<GetMovieByIdRequest>
{
    public async Task Consume(ConsumeContext<GetMovieByIdRequest> context)
    {
        var movie = await movieRepository.GetByIdAsync(context.Message.Id, nameof(Movie.Providers));
        await context.RespondAsync(new GetMovieByIdResponse
        {
            Movie = movie == null ? null : mapper.Map<GetMovieDetail>(movie)
        });
    }
}