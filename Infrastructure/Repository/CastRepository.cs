using ApplicationCore.Contract.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repository
{
    public class CastRepository : BaseRepository<Cast>, ICastRepository
    {
        private readonly MovieDbContext _dbContext;

        public CastRepository(MovieDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Cast> GetCastByMovie(int movieId)
        {
            return _dbContext.MovieCasts
                .Where(mc => mc.MovieId == movieId)
                .Include(mc => mc.Cast)
                .Select(mc => mc.Cast)
                .ToList();
        }

        public override Cast GetById(int id)
        {
            return _dbContext.Casts
                .Include(c => c.MovieCasts).ThenInclude(mc => mc.Movie)
                .FirstOrDefault(c => c.Id == id);
        }
    }
}
