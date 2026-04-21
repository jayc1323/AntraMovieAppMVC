using ApplicationCore.Models.Response;
using System.Collections.Generic;

namespace ApplicationCore.Contract.Services
{
    public interface ICastService
    {
        Task<IEnumerable<CastResponse>> GetCastByMovie(int movieId);
        Task<CastDetailsResponse> GetCastDetails(int castId);
    }
}
