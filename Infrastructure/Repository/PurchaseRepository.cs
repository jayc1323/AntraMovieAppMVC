using ApplicationCore.Contract.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repository
{
    public class PurchaseRepository : BaseRepository<Purchase>, IPurchaseRepository
    {
        public PurchaseRepository(MovieDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Purchase> GetPurchasesByUser(int userId)
        {
            return GetAll().Where(p => p.UserId == userId).ToList();
        }

        public bool HasUserPurchasedMovie(int userId, int movieId)
        {
            return GetAll().Any(p => p.UserId == userId && p.MovieId == movieId);
        }
    }
}
