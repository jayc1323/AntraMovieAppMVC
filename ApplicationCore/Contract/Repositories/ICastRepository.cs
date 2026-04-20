using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Contract.Repositories
{
    public interface ICastRepository : IRepository<Cast>
    {
        IEnumerable<Cast> GetCastByMovie(int movieId);
    }
}
