using MovieStore.Api.Provider.Configuration;
using MovieStore.Api.Provider.FilmWorld.Api;
using Polly;
using Polly.CircuitBreaker;
using Polly.Extensions.Http;
using Polly.Timeout;
using Refit;

namespace MovieStore.Api.Provider.FilmWorld;

public static class Binder
{
    public static void BindProvider(IHostApplicationBuilder builder)
    {
        var providerConfigurations =
            builder.Configuration.GetSection(ProviderOptions.Name).Get<ProviderConfiguration[]>();
        var providerConfiguration = providerConfigurations?.FirstOrDefault(p => p.Name == Constants.ProviderName);
        if (providerConfiguration == null)
            return;

        builder.Services
            .AddRefitClient<IFilmWorldApi>()
            .ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri(providerConfiguration.Url);
                c.DefaultRequestHeaders.Add("x-access-token", providerConfiguration.AccessToken);
                c.Timeout = TimeSpan.FromSeconds(500);
            })
            .AddPolicyHandler(HttpPolicyExtensions
                .HandleTransientHttpError()
                .Or<HttpRequestException>()
                .Or<TimeoutRejectedException>()
                .Or<BrokenCircuitException>()
                .WaitAndRetryAsync(5, _ => TimeSpan.FromSeconds(2))
                .WrapAsync(Policy.TimeoutAsync(1)));
        builder.Services.AddHostedService<FilmWorldDataSyncService>();
    }
}