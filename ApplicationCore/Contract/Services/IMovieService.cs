using ApplicationCore.Helper;
using ApplicationCore.Models;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Contract.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieCardModel>> GetMovieCards();
        Task<Page<MovieResponse>> GetMoviesByPagination(int pageNumber = 1, int pageSize = 10);
        Task<MovieDetailsResponse> GetMovieDetails(int movieId);
        Task<int>   AddMovie(MovieRequest request);
        Task<PaginatedResultSet<Movie>> GetMoviesByGenrePagination(int genreId, int pageSize = 30, int pageNumber = 1);
    }
}
