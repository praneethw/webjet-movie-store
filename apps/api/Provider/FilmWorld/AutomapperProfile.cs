using AutoMapper;
using MovieStore.Api.Application.Models;
using MovieStore.Api.Provider.FilmWorld.Api;

namespace MovieStore.Api.Provider.FilmWorld;

public class AutomapperProfile : Profile
{
    public AutomapperProfile()
    {
        CreateMap<MovieDetailType, SynchroniseMovieDetail>();
    }
}