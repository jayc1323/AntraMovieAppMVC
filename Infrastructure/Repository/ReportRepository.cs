using ApplicationCore.Contract.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repository
{
    public class ReportRepository : IReportRepository
    {
        private readonly MovieDbContext dbContext;

        public ReportRepository(MovieDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<ReportEntry> GetPurchaseReport()
        {
            return dbContext.Purchases
                .GroupBy(p => p.MovieId)
                .Select(g => new ReportEntry
                {
                    MovieTitle = dbContext.Movies.Where(m => m.Id == g.Key).Select(m => m.Title).FirstOrDefault(),
                    PurchaseCount = g.Count(),
                    TotalRevenue = g.Sum(p => p.TotalPrice)
                }).ToList();
        }

        public IEnumerable<ReportEntry> GetTopPurchasedMovies(int count = 10)
        {
            return GetPurchaseReport().OrderByDescending(r => r.PurchaseCount).Take(count).ToList();
        }
    }
}
