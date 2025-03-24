namespace MovieStore.Api.Provider.Configuration;

public class ProviderOptions
{
    public const string Name = "Providers";
}

public class ProviderConfiguration
{
    public string Name { get; set; }
    public string Url { get; set; }
    public string AccessToken { get; set; }
}