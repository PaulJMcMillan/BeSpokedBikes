using BeSpokedBikes.Models;

namespace BeSpokedBikes.Interfaces
{
    public interface ISalesPersonService
    {
        Task<List<SalesPerson>> GetAllSalesPersonsAsync();
        Task<SalesPerson> GetByIdAsync(int id);
        Task UpdateAsync(SalesPerson salesPerson);
    }
}
