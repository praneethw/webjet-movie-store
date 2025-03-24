namespace MovieStore.Api.Application.Query;

public record GetMoviesResponse
{
    public List<GetMovieDetail>? Movies { get; set; }
}