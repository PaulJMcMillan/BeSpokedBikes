using BeSpokedBikes.Interfaces;
using BeSpokedBikes.Models;
using BeSpokedBikes.ViewModels;

namespace BeSpokedBikes.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;

        public SaleService(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public async Task AddAsync(Sale sale)
        {
            await _saleRepository.AddAsync(sale);
        }

        public async Task<List<SalesListViewModel>> GetSalesByDateRangeAsync(DateTime? startDate, DateTime? endDate)
        {
            return await _saleRepository.GetSalesByDateRangeAsync(startDate, endDate);
        }
    }
}
