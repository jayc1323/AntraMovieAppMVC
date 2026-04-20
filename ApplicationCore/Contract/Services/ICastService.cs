using ApplicationCore.Models.Response;
using System.Collections.Generic;

namespace ApplicationCore.Contract.Services
{
    public interface ICastService
    {
        IEnumerable<CastResponse> GetCastByMovie(int movieId);
        CastDetailsResponse GetCastDetails(int castId);
    }
}
