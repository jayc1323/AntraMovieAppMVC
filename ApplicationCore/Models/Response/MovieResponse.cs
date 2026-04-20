using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Models.Response
{
    public class MovieResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PosterUrl { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string OriginalLanguage { get; set; }
    }

    public class MovieDetailsResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string TmdbUrl { get; set; }
        public string OverView { get; set; }
        public string Tagline { get; set; }
        public string OriginalLanguage { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? RunTime { get; set; }
        public decimal? Budget { get; set; }
        public decimal? Revenue { get; set; }
        public string BackdropUrl { get; set; }
        public string PosterUrl { get; set; }
        public string ImdbUrl { get; set; }
        public decimal? Rating { get; set; }
        public decimal Price { get; set; }
        public List<string> Genres { get; set; } = new List<string>();
        public List<CastResponse> Casts { get; set; } = new List<CastResponse>();
        public List<TrailerResponse> Trailers { get; set; } = new List<TrailerResponse>();
        public List<CrewResponse> Crews { get; set; } = new List<CrewResponse>();
    }

    public class TrailerResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TrailerUrl { get; set; }
    }

    public class CrewResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Job { get; set; }
        public string ProfilePath { get; set; }
    }
}
