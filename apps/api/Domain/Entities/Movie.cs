﻿using MovieStore.Api.Domain.Common;

namespace MovieStore.Api.Domain.Entities;

public class Movie : BaseAuditableEntity
{
    public string Title { get; set; }
    public string Hash { get; set; }
    public string? Year { get; set; }
    public string? Rated { get; set; }
    public string? Released { get; set; }
    public string? Runtime { get; set; }
    public string? Genre { get; set; }
    public string? Director { get; set; }
    public string? Writer { get; set; }
    public string? Actors { get; set; }
    public string? Plot { get; set; }
    public string? Language { get; set; }
    public string? Country { get; set; }
    public string? Awards { get; set; }
    public string? Poster { get; set; }
    public string? Metascore { get; set; }
    public string? Rating { get; set; }
    public string? Votes { get; set; }
    public string? Type { get; set; }
    public IList<MovieProvider> Providers { get; set; } = new List<MovieProvider>();
}