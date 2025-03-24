using AutoMapper;
using MovieStore.Api.Application.Models;
using MovieStore.Api.Application.Query;
using MovieStore.Api.Domain.Entities;

namespace MovieStore.Api.Application;

public class AutomapperProfile : Profile
{
    public AutomapperProfile()
    {
        CreateMap<SynchroniseMovieDetail, Movie>();
        CreateMap<SynchroniseMovieDetail, MovieProvider>();
        CreateMap<Movie, GetMovieDetail>();
        CreateMap<MovieProvider, GetMovieProviderDetail>();
    }
}