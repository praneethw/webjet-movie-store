using MovieStore.Api.Domain.Common;

namespace MovieStore.Api.Domain.Entities;

public class MovieProvider : BaseAuditableEntity
{
    public Guid MovieId { get; set; }
    public string ProviderName { get; set; }
    public string Price { get; set; }
    public Movie Movie { get; set; }
}