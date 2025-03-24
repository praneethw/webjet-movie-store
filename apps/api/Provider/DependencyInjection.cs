using CinemaWorldBinder = MovieStore.Api.Provider.CinemaWorld.Binder;
using FilmWorldBinder = MovieStore.Api.Provider.FilmWorld.Binder;

namespace MovieStore.Api.Provider;

public static class DependencyInjection
{
    public static void AddProviderServices(this IHostApplicationBuilder builder)
    {
        CinemaWorldBinder.BindProvider(builder);
        FilmWorldBinder.BindProvider(builder);
    }
}