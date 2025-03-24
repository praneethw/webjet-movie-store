using Refit;

namespace MovieStore.Api.Provider.CinemaWorld.Api;

public interface ICinemaWorldApi
{
    [Get("/movies")]
    Task<MoviesType> GetMoviesAsync();

    [Get("/movie/{id}")]
    Task<MovieDetailType> GetMovieById(string id);
}