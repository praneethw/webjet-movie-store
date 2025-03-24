using MovieStore.Api.Application.Models;

namespace MovieStore.Api.Application.Command;

public record SynchroniseMovieCommand
{
    public SynchroniseMovieDetail SynchroniseMovieDetail { get; set; }
}