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

public class GetMovieByIdConsumerTests
{
    private readonly IMediator _mediator;
    private readonly Mock<IGenericRepository<Movie>> _movieRepository;

    public GetMovieByIdConsumerTests()
    {
        _movieRepository = new Mock<IGenericRepository<Movie>>();

        var serviceCollection = new ServiceCollection();
        serviceCollection.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        serviceCollection.AddScoped<IGenericRepository<Movie>>(_ => _movieRepository.Object);
        serviceCollection.AddMediator(configure => { configure.AddConsumer<GetMovieByIdConsumer>(); });
        var serviceProvider = serviceCollection.BuildServiceProvider(true);

        _mediator = serviceProvider.GetRequiredService<IMediator>();
    }

    [Fact]
    public async Task Consumes_GetMovieByIdRequest_RespondsGetMovieByIdResponse()
    {
        // Arrange
        var id = Guid.NewGuid();
        _movieRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<string[]>()))
            .ReturnsAsync(
                new Movie
                {
                    Id = id,
                    Title = "Movie1"
                }
            );

        // Act
        var client = _mediator.CreateRequestClient<GetMovieByIdRequest>();
        var response = await client.GetResponse<GetMovieByIdResponse>(new GetMovieByIdRequest { Id = id });

        // Assert
        response.Message.Should().NotBeNull();
        response.Message.Movie.Should().NotBeNull();
        response.Message.Movie.Id.Should().Be(id);
    }
}