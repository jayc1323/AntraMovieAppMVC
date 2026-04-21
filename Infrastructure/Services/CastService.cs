using ApplicationCore.Contract.Repositories;
using ApplicationCore.Contract.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Services
{
    public class CastService : ICastService
    {
        private readonly ICastRepository castRepository;

        public CastService(ICastRepository castRepository)
        {
            this.castRepository = castRepository;
        }

        public async Task<IEnumerable<CastResponse>> GetCastByMovie(int movieId)
        {
            return (await castRepository.GetCastByMovie(movieId)).Select(c => new CastResponse
            {
                Id = c.Id,
                Name = c.Name,
                Gender = c.Gender,
                TmdbUrl = c.TmdbUrl,
                ProfilePath = c.ProfilePath
            }).ToList();
        }

        public async Task<CastDetailsResponse> GetCastDetails(int castId)
        {
            Cast cast = await castRepository.GetById(castId);
            if (cast == null) return null;

            var response = new CastDetailsResponse
            {
                Id = cast.Id,
                Name = cast.Name,
                Gender = cast.Gender,
                TmdbUrl = cast.TmdbUrl,
                ProfilePath = cast.ProfilePath
            };

            if (cast.MovieCasts != null)
                foreach (var mc in cast.MovieCasts)
                    response.Movies.Add(new MovieResponse
                    {
                        Id = mc.Movie.Id,
                        Title = mc.Movie.Title,
                        PosterUrl = mc.Movie.PosterUrl,
                        ReleaseDate = mc.Movie.ReleaseDate,
                        OriginalLanguage = mc.Movie.OriginalLanguage
                    });

            return response;
        }
    }
}
