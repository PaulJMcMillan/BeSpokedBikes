using BeSpokedBikes.Interfaces;
using BeSpokedBikes.Models;

namespace BeSpokedBikes.Services
{
    public class SalesPersonService : ISalesPersonService
    {
        private readonly ISalesPersonRepository _salesPersonRepository;

        public SalesPersonService(ISalesPersonRepository salesPersonRepository)
        {
            _salesPersonRepository = salesPersonRepository;
        }

        public Task<List<SalesPerson>> GetAllSalesPersonsAsync()
        {
            return _salesPersonRepository.GetAllSalesPersonsAsync();
        }

        public Task<SalesPerson> GetByIdAsync(int id)
        {
            return _salesPersonRepository.GetById(id);
        }

        public async Task UpdateAsync(SalesPerson salesPerson)
        {
            await _salesPersonRepository.UpdateAsync(salesPerson);
        }
    }
}
