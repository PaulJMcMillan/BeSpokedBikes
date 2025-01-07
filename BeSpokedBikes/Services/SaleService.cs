using BeSpokedBikes.Interfaces;
using BeSpokedBikes.Models;

namespace BeSpokedBikes.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;

        public SaleService(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public async Task<List<Sale>> GetAllAsync()
        {
            return await _saleRepository.GetAllAsync();
        }
    }
}
