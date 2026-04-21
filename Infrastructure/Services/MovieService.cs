using ApplicationCore.Contract.Repositories;
using ApplicationCore.Contract.Services;
using ApplicationCore.Entities;
using ApplicationCore.Helper;
using ApplicationCore.Models;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        public async Task<IEnumerable<MovieCardModel>> GetMovieCards()
        {
            return (await movieRepository.GetHighestGrossingMovies())
                .Select(m => new MovieCardModel
                {
                    Id = m.Id,
                    Title = m.Title,
                    PosterUrl = m.PosterUrl,
                    Price = 9.99m
                });
        }

        public async Task<int> AddMovie(MovieRequest request)
        {
            Movie movie = new Movie
            {
                Title = request.Title,
                TmdbUrl = request.TmdbUrl,
                OverView = request.OverView,
                Tagline = request.Tagline,
                OriginalLanguage = request.OriginalLanguage,
                ReleaseDate = request.ReleaseDate,
                RunTime = request.RunTime,
                Budget = request.Budget,
                Revenue = request.Revenue,
                BackdropUrl = request.BackdropUrl,
                PosterUrl = request.PosterUrl,
                ImdbUrl = request.ImdbUrl
            };
            return await movieRepository.Insert(movie);
        }

        public async Task<MovieDetailsResponse>  GetMovieDetails(int movieId)
        {
            Movie movie = await movieRepository.GetMovieById(movieId);
            if (movie == null) return null;

            var response = new MovieDetailsResponse
            {
                Id = movie.Id,
                Title = movie.Title,
                TmdbUrl = movie.TmdbUrl,
                OverView = movie.OverView,
                Tagline = movie.Tagline,
                OriginalLanguage = movie.OriginalLanguage,
                ReleaseDate = movie.ReleaseDate,
                RunTime = movie.RunTime,
                Budget = movie.Budget,
                Revenue = movie.Revenue,
                BackdropUrl = movie.BackdropUrl,
                PosterUrl = movie.PosterUrl,
                ImdbUrl = movie.ImdbUrl,
                Rating = movie.Rating,
                Price = 9.99m
            };

            if (movie.MovieGenres != null)
                foreach (var mg in movie.MovieGenres)
                    response.Genres.Add(mg.Genre.Name);

            if (movie.MovieCasts != null)
                foreach (var mc in movie.MovieCasts)
                    response.Casts.Add(new CastResponse
                    {
                        Id = mc.Cast.Id,
                        Name = mc.Cast.Name,
                        Gender = mc.Cast.Gender,
                        ProfilePath = mc.Cast.ProfilePath,
                        TmdbUrl = mc.Cast.TmdbUrl
                    });

            if (movie.Trailers != null)
                foreach (var t in movie.Trailers)
                    response.Trailers.Add(new TrailerResponse
                    {
                        Id = t.Id,
                        Name = t.Name,
                        TrailerUrl = t.TrailerUrl
                    });

            if (movie.MovieCrews != null)
                foreach (var mc in movie.MovieCrews)
                    response.Crews.Add(new CrewResponse
                    {
                        Id = mc.Crew.Id,
                        Name = mc.Crew.Name,
                        Department = mc.Department,
                        Job = mc.Job,
                        ProfilePath = mc.Crew.ProfilePath
                    });

            return response;
        }

        public async Task<Page<MovieResponse>> GetMoviesByPagination(int pageNumber = 1, int pageSize = 10)
        {
            Page<Movie> moviePage = await movieRepository.GetMoviesByPagination(pageNumber, pageSize);
            List<MovieResponse> responses = new List<MovieResponse>();
            foreach (Movie item in moviePage.Data)
            {
                responses.Add(new MovieResponse
                {
                    Id = item.Id,
                    Title = item.Title,
                    PosterUrl = item.PosterUrl,
                    ReleaseDate = item.ReleaseDate,
                    OriginalLanguage = item.OriginalLanguage
                });
            }
            return new Page<MovieResponse>
            {
                PageNumber = pageNumber,
                TotalRecords = moviePage.TotalRecords,
                Data = responses
            };
        }

        public async Task<PaginatedResultSet<Movie>> GetMoviesByGenrePagination(int genreId, int pageSize = 30, int pageNumber = 1)
        {
            var movies = await movieRepository.GetMoviesByGenre(genreId);
            var count = movies.Count();
            var pagedMovies = movies.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return new PaginatedResultSet<Movie>
            {
                PageIndex = pageNumber,
                PageSize = pageSize,
                TotalCount = count,
                TotalPages = (int)Math.Ceiling(count / (double)pageSize),
                Data = pagedMovies
            };
        }
    }
}
