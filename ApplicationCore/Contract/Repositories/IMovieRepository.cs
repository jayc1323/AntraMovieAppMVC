using ApplicationCore.Entities;
using ApplicationCore.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Contract.Repositories
{
    public interface IMovieRepository : IRepository<Movie>
    {
        Page<Movie> GetMoviesByPagination(int pageNumber = 1, int pageSize = 10);
        IEnumerable<Movie> GetMoviesByGenre(int genreId);
        IEnumerable<Movie> GetTopRatedMovies(int count = 10);
        IEnumerable<Movie> GetHighestGrossingMovies();
        Movie GetMovieById(int id);
    }
}
