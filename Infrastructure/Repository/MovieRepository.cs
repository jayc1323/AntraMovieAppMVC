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

        public async Task<IEnumerable<Movie>> GetMoviesByGenre(int genreId)
        {
            return await _dbContext.MovieGenres
                .Where(mg => mg.GenreId == genreId)
                .Include(mg => mg.Movie)
                .Select(mg => mg.Movie)
                .ToListAsync();
        }

        public async Task<Page<Movie>> GetMoviesByPagination(int pageNumber = 1, int pageSize = 10)
        {
            Page<Movie> page = new Page<Movie>();
            page.PageNumber = pageNumber;
            page.TotalRecords = (await GetAll()).Count();
            page.Data = (await GetAll()).Skip((pageNumber - 1) * pageSize).Take(pageSize);
            return page;
        }

        public async Task<IEnumerable<Movie>> GetTopRatedMovies(int count = 10)
        {
            return await _dbContext.Movies
                .OrderByDescending(m => m.Rating)
                .Take(count)
                .ToListAsync();
        }

        public async Task<IEnumerable<Movie>> GetHighestGrossingMovies()
        {
            return await _dbContext.Movies
                .OrderByDescending(m => m.Revenue)
                .Take(10)
                .ToListAsync();
        }

        public async Task<Movie> GetMovieById(int id)
        {
            return await _dbContext.Movies
                .Include(m => m.MovieGenres).ThenInclude(mg => mg.Genre)
                .Include(m => m.MovieCasts).ThenInclude(mc => mc.Cast)
                .Include(m => m.Trailers)
                .Include(m => m.MovieCrews).ThenInclude(mc => mc.Crew)
                .FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
