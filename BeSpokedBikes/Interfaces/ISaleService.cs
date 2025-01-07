using BeSpokedBikes.Models;
using BeSpokedBikes.ViewModels;

namespace BeSpokedBikes.Interfaces
{
    public interface ISaleService
    {
        Task AddAsync(Sale sale);
        Task<List<SalesListViewModel>> GetSalesByDateRangeAsync(DateTime? startDate, DateTime? endDate);
    }
}
