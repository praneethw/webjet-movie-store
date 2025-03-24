namespace MovieStore.Api.Application.Query;

public record GetMovieByIdRequest
{
    public Guid Id { get; set; }
}