namespace MovieStore.Api.Application.Query;

public record GetMovieByIdResponse
{
    public GetMovieDetail? Movie { get; set; }
}