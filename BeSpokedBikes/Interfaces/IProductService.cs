using BeSpokedBikes.Models;

namespace BeSpokedBikes.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task UpdateAsync(Product product);
    }
}
