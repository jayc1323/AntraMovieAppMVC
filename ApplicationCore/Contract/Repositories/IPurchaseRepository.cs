using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Contract.Repositories
{
    public interface IPurchaseRepository : IRepository<Purchase>
    {
        IEnumerable<Purchase> GetPurchasesByUser(int userId);
        bool HasUserPurchasedMovie(int userId, int movieId);
    }
}
