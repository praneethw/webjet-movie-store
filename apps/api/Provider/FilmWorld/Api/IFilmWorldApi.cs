using Refit;

namespace MovieStore.Api.Provider.FilmWorld.Api;

public interface IFilmWorldApi
{
    [Get("/movies")]
    Task<MoviesType> GetMoviesAsync();

    [Get("/movie/{id}")]
    Task<MovieDetailType> GetMovieById(string id);
}