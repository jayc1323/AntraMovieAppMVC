using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ApplicationCore.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(256)]
        public string Title { get; set; }
        [MaxLength(2084)]
        public string TmdbUrl { get; set; }
        public string OverView { get; set; }
        [MaxLength(512)]
        public string Tagline { get; set; }
        [MaxLength(64)]
        public string OriginalLanguage { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? RunTime { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Budget { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Revenue { get; set; }
        [MaxLength(2084)]
        public string BackdropUrl { get; set; }
        [MaxLength(2084)]
        public string PosterUrl { get; set; }
        [MaxLength(2084)]
        public string ImdbUrl { get; set; }
        [Column(TypeName = "decimal(3,2)")]
        public decimal? Rating { get; set; }

        public ICollection<MovieGenre> MovieGenres { get; set; }
        public ICollection<MovieCast> MovieCasts { get; set; }
        public ICollection<Trailer> Trailers { get; set; }
        public ICollection<Purchase> Purchases { get; set; }
        public ICollection<Favorite> Favorites { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<MovieCrew> MovieCrews { get; set; }
    }
}
