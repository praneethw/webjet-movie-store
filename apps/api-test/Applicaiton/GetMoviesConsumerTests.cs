using FluentAssertions;
using MassTransit;
using MassTransit.Mediator;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using MovieStore.Api.Application.Common.Interfaces;
using MovieStore.Api.Application.Consumer;
using MovieStore.Api.Application.Query;
using MovieStore.Api.Domain.Entities;

namespace MovieStore.Api.Test.Applicaiton;

public class GetMoviesConsumerTests
{
    private readonly IMediator _mediator;
    private readonly Mock<IGenericRepository<Movie>> _movieRepository;

    public GetMoviesConsumerTests()
    {
        _movieRepository = new Mock<IGenericRepository<Movie>>();

        var serviceCollection = new ServiceCollection();
        serviceCollection.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        serviceCollection.AddScoped<IGenericRepository<Movie>>(_ => _movieRepository.Object);
        serviceCollection.AddMediator(configure => { configure.AddConsumer<GetMoviesConsumer>(); });
        var serviceProvider = serviceCollection.BuildServiceProvider(true);

        _mediator = serviceProvider.GetRequiredService<IMediator>();
    }

    [Fact]
    public async Task Consumes_GetMoviesRequest_RespondsGetMoviesResponse()
    {
        // Arrange
        _movieRepository.Setup(x => x.GetAllAsync(It.IsAny<string[]>()))
            .ReturnsAsync([
                new Movie
                {
                    Title = "Movie1"
                },
                new Movie
                {
                    Title = "Movie2"
                }
            ]);

        // Act
        var client = _mediator.CreateRequestClient<GetMoviesRequest>();
        var response = await client.GetResponse<GetMoviesResponse>(new GetMoviesRequest());

        // Assert
        response.Message.Should().NotBeNull();
        response.Message.Movies.Should().HaveCount(2);
    }
}