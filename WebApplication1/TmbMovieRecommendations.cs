using System;
using System.Collections.Generic;

public class TmdbMovieRecommendations
{
    public List<TmdbMovie> Results { get; set; }
}

public class TmdbMovie
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Overview { get; set; }
    public string ReleaseDate { get; set; }
    
}
