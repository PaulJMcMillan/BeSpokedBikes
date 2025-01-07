using BeSpokedBikes.Models;

namespace BeSpokedBikes.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllAsync();
    }
}