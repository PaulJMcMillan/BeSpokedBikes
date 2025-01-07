using BeSpokedBikes.Models;
using BeSpokedBikes.ViewModels;

namespace BeSpokedBikes.Interfaces
{
    public interface ISaleRepository
    {
        Task AddAsync(Sale sale);
        Task<List<SalesListViewModel>> GetSalesByDateRangeAsync(DateTime? startDate, DateTime? endDate);
    }
}
