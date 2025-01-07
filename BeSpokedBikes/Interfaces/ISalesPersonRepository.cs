using BeSpokedBikes.Models;

namespace BeSpokedBikes.Interfaces
{
    public interface ISalesPersonRepository
    {
        Task<List<SalesPerson>> GetAllSalesPersonsAsync();
        Task<SalesPerson> GetById(int id);
        Task UpdateAsync(SalesPerson salesPerson);
    }
}
