using BeSpokedBikes.Interfaces;
using BeSpokedBikes.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BeSpokedBikes.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly AppDbContext _appDbContext;

        public ReportRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<List<CommissionReportViewModel>> GetQuarterlyCommissionReportAsync(int year, string quarter)
        {
            FormattableString execString = $"EXEC [GetSalesPersonQuarterlyCommissionReport] @Year = {year},@Quarter = {quarter}";
            return await _appDbContext.CommissionReport.FromSqlInterpolated(execString).ToListAsync();
        }
    }
}
