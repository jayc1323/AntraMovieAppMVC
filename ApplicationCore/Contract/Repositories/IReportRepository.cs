using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Contract.Repositories
{
    public interface IReportRepository
    {
        IEnumerable<ReportEntry> GetPurchaseReport();
        IEnumerable<ReportEntry> GetTopPurchasedMovies(int count = 10);
    }

    public class ReportEntry
    {
        public string MovieTitle { get; set; }
        public int PurchaseCount { get; set; }
        public decimal TotalRevenue { get; set; }
    }
}
