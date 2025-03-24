using System.Linq.Expressions;
using MassTransit;
using MassTransit.Mediator;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using MovieStore.Api.Application.Command;
using MovieStore.Api.Application.Common.Interfaces;
using MovieStore.Api.Application.Consumer;
using MovieStore.Api.Application.Models;
using MovieStore.Api.Domain.Entities;
using MovieStore.Api.Provider.FilmWorld;

namespace MovieStore.Api.Test.Applicaiton;

public class SynchroniseMovieConsumerTests
{
    private readonly IMediator _mediator;
    private readonly Mock<IGenericRepository<Movie>> _movieRepository;

    public SynchroniseMovieConsumerTests()
    {
        _movieRepository = new Mock<IGenericRepository<Movie>>();

        var serviceCollection = new ServiceCollection();
        serviceCollection.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        serviceCollection.AddScoped<IGenericRepository<Movie>>(_ => _movieRepository.Object);
        serviceCollection.AddMediator(configure => { configure.AddConsumer<SynchroniseMovieConsumer>(); });
        var serviceProvider = serviceCollection.BuildServiceProvider(true);

        _mediator = serviceProvider.GetRequiredService<IMediator>();
    }

    [Fact]
    public async Task Consumes_SynchroniseMovieCommand_CreatesMovie()
    {
        // Arrange
        var createMovieCommand = new SynchroniseMovieCommand
        {
            SynchroniseMovieDetail = new SynchroniseMovieDetail
            {
                Title = "Test Movie"
            }
        };

        // Act
        await _mediator.Send(createMovieCommand);

        // Assert
        _movieRepository.Verify(
            x => x.AddAsync(It.Is<Movie>(movie => movie.Title == createMovieCommand.SynchroniseMovieDetail.Title)),
            Times.Once);
    }

    [Fact]
    public async Task Consumes_SynchroniseMovieCommand_UpdatesMovieWithProvider()
    {
        // Arrange
        var createMovieCommand = new SynchroniseMovieCommand
        {
            SynchroniseMovieDetail = new SynchroniseMovieDetail
            {
                Title = "Test Movie",
                ProviderName = Constants.ProviderName
            }
        };
        _movieRepository.Setup(x =>
                x.FindOneOrDefaultAsync(It.IsAny<Expression<Func<Movie, bool>>>(), It.IsAny<string>()))
            .ReturnsAsync(new Movie
            {
                Title = createMovieCommand.SynchroniseMovieDetail.Title
            });

        // Act
        await _mediator.Send(createMovieCommand);

        // Assert
        _movieRepository.Verify(
            x => x.UpdateAsync(It.Is<Movie>(movie =>
                movie.Providers.First().ProviderName == createMovieCommand.SynchroniseMovieDetail.ProviderName)),
            Times.Once);
    }

    [Fact]
    public async Task Consumes_SynchroniseMovieCommand_UpdatesProviderPriceWhenProviderAlreadyExists()
    {
        // Arrange
        var createMovieCommand = new SynchroniseMovieCommand
        {
            SynchroniseMovieDetail = new SynchroniseMovieDetail
            {
                Title = "Test Movie",
                Price = "100",
                ProviderName = Constants.ProviderName
            }
        };
        _movieRepository.Setup(x =>
                x.FindOneOrDefaultAsync(It.IsAny<Expression<Func<Movie, bool>>>(), It.IsAny<string>()))
            .ReturnsAsync(new Movie
            {
                Title = createMovieCommand.SynchroniseMovieDetail.Title,
                Providers = new List<MovieProvider>
                {
                    new()
                    {
                        ProviderName = createMovieCommand.SynchroniseMovieDetail.ProviderName,
                        Price = "50"
                    }
                }
            });

        // Act
        await _mediator.Send(createMovieCommand);

        // Assert
        _movieRepository.Verify(
            x => x.UpdateAsync(It.Is<Movie>(movie =>
                movie.Providers.First().Price == createMovieCommand.SynchroniseMovieDetail.Price)),
            Times.Once);
    }
}