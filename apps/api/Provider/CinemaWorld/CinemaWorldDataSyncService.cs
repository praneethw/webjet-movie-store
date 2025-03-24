using AutoMapper;
using MassTransit.Mediator;
using MovieStore.Api.Application.Command;
using MovieStore.Api.Application.Models;
using MovieStore.Api.Provider.CinemaWorld.Api;
using Polly.Timeout;

namespace MovieStore.Api.Provider.CinemaWorld;

public class CinemaWorldDataSyncService(
    ILogger<CinemaWorldDataSyncService> logger,
    IMapper mapper,
    IMediator mediator,
    ICinemaWorldApi cinemaWorldApi)
    : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        // Intentionally set to 10 for the purpose of the demo.
        using var timer = new PeriodicTimer(TimeSpan.FromSeconds(10));
        do
        {
            try
            {
                var moviesResponse = await cinemaWorldApi.GetMoviesAsync();
                foreach (var movie in moviesResponse.Movies)
                {
                    var movieResponse = await cinemaWorldApi.GetMovieById(movie.Id);

                    var synchroniseMovieCommand = new SynchroniseMovieCommand
                    {
                        SynchroniseMovieDetail = mapper.Map<SynchroniseMovieDetail>(movieResponse,
                            opt => opt.AfterMap((src, dest) => dest.ProviderName = Constants.ProviderName))
                    };

                    await mediator.Send(synchroniseMovieCommand, cancellationToken);
                }
            }
            catch (TimeoutRejectedException ex)
            {
                logger.LogError("Failed to get movies from Cinema World API.");
            }
        } while (await timer.WaitForNextTickAsync(cancellationToken));
    }
}