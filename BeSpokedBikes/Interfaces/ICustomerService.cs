using BeSpokedBikes.Models;

namespace BeSpokedBikes.Interfaces
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetAllAsync();
    }
}