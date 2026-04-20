using ApplicationCore.Contract.Repositories;
using ApplicationCore.Entities;
using ApplicationCore.Helper;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repository
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        private readonly MovieDbContext _dbContext;

        public MovieRepository(MovieDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Movie> GetMoviesByGenre(int genreId)
        {
            return _dbContext.MovieGenres
                .Where(mg => mg.GenreId == genreId)
                .Include(mg => mg.Movie)
                .Select(mg => mg.Movie)
                .ToList();
        }

        public Page<Movie> GetMoviesByPagination(int pageNumber = 1, int pageSize = 10)
        {
            Page<Movie> page = new Page<Movie>();
            page.PageNumber = pageNumber;
            page.TotalRecords = GetAll().Count();
            page.Data = GetAll().Skip((pageNumber - 1) * pageSize).Take(pageSize);
            return page;
        }

        public IEnumerable<Movie> GetTopRatedMovies(int count = 10)
        {
            return _dbContext.Movies
                .OrderByDescending(m => m.Rating)
                .Take(count)
                .ToList();
        }

        public IEnumerable<Movie> GetHighestGrossingMovies()
        {
            return _dbContext.Movies
                .OrderByDescending(m => m.Revenue)
                .Take(10)
                .ToList();
        }

        public Movie GetMovieById(int id)
        {
            return _dbContext.Movies
                .Include(m => m.MovieGenres).ThenInclude(mg => mg.Genre)
                .Include(m => m.MovieCasts).ThenInclude(mc => mc.Cast)
                .Include(m => m.Trailers)
                .Include(m => m.MovieCrews).ThenInclude(mc => mc.Crew)
                .FirstOrDefault(m => m.Id == id);
        }
    }
}
