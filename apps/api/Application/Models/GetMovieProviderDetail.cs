namespace MovieStore.Api.Application.Query;

public class GetMovieProviderDetail
{
    public string ProviderName { get; set; }
    public string Price { get; set; }
    public DateTimeOffset Created { get; set; }
    public DateTimeOffset LastModified { get; set; }
}