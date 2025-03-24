using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using MovieStore.Api.Application.Common.Interfaces;
using MovieStore.Api.Infrastructure.Data;
using MovieStore.Api.Infrastructure.Data.Interceptors;
using MovieStore.Api.Infrastructure.Data.Repository;

namespace MovieStore.Api.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructureServices(this IHostApplicationBuilder builder)
    {
        builder.Services.AddSingleton(TimeProvider.System);
        builder.Services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
            options.UseInMemoryDatabase("MovieStoreDb");
        });
        builder.Services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        builder.Services.AddMassTransit(configure => { configure.UsingInMemory(); });
    }
}