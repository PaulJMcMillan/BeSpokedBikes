using BeSpokedBikes.Interfaces;
using BeSpokedBikes.Models;

namespace BeSpokedBikes.Services
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<List<Product>> GetAllAsync()
        {
            return _productRepository.GetAllAsync();
        }

        public Task<Product> GetByIdAsync(int id)
        {
            return _productRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Product Product)
        {
            await _productRepository.UpdateAsync(Product);
        }
    }
}
