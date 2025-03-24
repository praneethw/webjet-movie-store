using AutoMapper;
using MovieStore.Api.Application.Models;
using MovieStore.Api.Provider.CinemaWorld.Api;

namespace MovieStore.Api.Provider.CinemaWorld;

public class AutomapperProfile : Profile
{
    public AutomapperProfile()
    {
        CreateMap<MovieDetailType, SynchroniseMovieDetail>();
    }
}