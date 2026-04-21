using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Contract.Repositories
{
    public interface IPurchaseRepository : IRepository<Purchase>
    {
        Task<IEnumerable<Purchase>> GetPurchasesByUser(int userId);
        Task<bool> HasUserPurchasedMovie(int userId, int movieId);
    }
}
