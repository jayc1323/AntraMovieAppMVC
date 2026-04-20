using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Models.Response
{
    public class CastResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string TmdbUrl { get; set; }
        public string ProfilePath { get; set; }
    }

    public class CastDetailsResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string TmdbUrl { get; set; }
        public string ProfilePath { get; set; }
        public List<MovieResponse> Movies { get; set; } = new List<MovieResponse>();
    }
}
