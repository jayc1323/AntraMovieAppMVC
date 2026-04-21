using ApplicationCore.Entities;
using ApplicationCore.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Contract.Repositories
{
    public interface IMovieRepository : IRepository<Movie>
    {
        Task<Page<Movie>> GetMoviesByPagination(int pageNumber = 1, int pageSize = 10);
        Task<IEnumerable<Movie>> GetMoviesByGenre(int genreId);
        Task<IEnumerable<Movie>> GetTopRatedMovies(int count = 10);
        Task<IEnumerable<Movie>> GetHighestGrossingMovies();
        Task<Movie> GetMovieById(int id);
    }
}
