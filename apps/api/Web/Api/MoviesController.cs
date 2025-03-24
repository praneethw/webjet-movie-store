using MassTransit.Mediator;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Api.Application.Query;

namespace MovieStore.Api.Web.Api;

[ApiController]
[Route("[controller]")]
public class MoviesController(
    IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var client = mediator.CreateRequestClient<GetMoviesRequest>();
        var response = await client.GetResponse<GetMoviesResponse>(new GetMoviesRequest());

        return Ok(response.Message.Movies);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var client = mediator.CreateRequestClient<GetMovieByIdRequest>();
        var response = await client.GetResponse<GetMovieByIdResponse>(new GetMovieByIdRequest { Id = id });

        if (response.Message.Movie == null)
            return NotFound();

        return Ok(response.Message.Movie);
    }
}