using BeSpokedBikes.Interfaces;
using BeSpokedBikes.Models;
using BeSpokedBikes.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BeSpokedBikes.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly AppDbContext _appDbContext;

        public SaleRepository(AppDbContext appDbContext) 
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(Sale sale)
        {
            await _appDbContext.Sales.AddAsync(sale);
            await _appDbContext.SaveChangesAsync();

        }

        public async Task<List<SalesListViewModel>> GetSalesByDateRangeAsync(DateTime? startDate, DateTime? endDate)
        {
            startDate = startDate ?? new DateTime(2000, 1,1);
            endDate = endDate ?? new DateTime(2100, 12, 31);
            FormattableString execString = $"EXEC GetSales @StartDate = {startDate},@EndDate = {endDate}";
            var sales = await _appDbContext.SalesList
                .FromSqlInterpolated(execString)
                .ToListAsync();

            return sales;
        }
    }
}
