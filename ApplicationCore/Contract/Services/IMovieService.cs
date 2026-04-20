using ApplicationCore.Helper;
using ApplicationCore.Models;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Contract.Services
{
    public interface IMovieService
    {
        IEnumerable<MovieCardModel> GetMovieCards();
        Page<MovieResponse> GetMoviesByPagination(int pageNumber = 1, int pageSize = 10);
        MovieDetailsResponse GetMovieDetails(int movieId);
        int AddMovie(MovieRequest request);
    }
}
