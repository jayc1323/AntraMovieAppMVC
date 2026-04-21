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

        public async Task<IEnumerable<Cast>> GetCastByMovie(int movieId)
        {
            return await _dbContext.MovieCasts
                .Where(mc => mc.MovieId == movieId)
                .Include(mc => mc.Cast)
                .Select(mc => mc.Cast)
                .ToListAsync();
        }

        public async override Task<Cast> GetById(int id)
        {
            return await _dbContext.Casts
                .Include(c => c.MovieCasts).ThenInclude(mc => mc.Movie)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
