using MassTransit;
using MovieStore.Api.Application.Consumer;

namespace MovieStore.Api.Application;

public static class DependencyInjection
{
    public static void AddApplicationServices(this IHostApplicationBuilder builder)
    {
        builder.Services
            .AddMediator(configure =>
            {
                configure.AddConsumer<SynchroniseMovieConsumer>();
                configure.AddConsumer<GetMoviesConsumer>();
                configure.AddConsumer<GetMovieByIdConsumer>();
            });
    }
}