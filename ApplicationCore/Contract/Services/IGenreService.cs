using ApplicationCore.Helper;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Contract.Services
{
    public interface IGenreService
    {
        int AddGenre(GenreRequest request);
        Page<GenreResponse> GetPage(int pageNumber, int pageSize=3);
    }
}
