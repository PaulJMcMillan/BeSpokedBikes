using BeSpokedBikes.Interfaces;
using BeSpokedBikes.Models;
using Microsoft.EntityFrameworkCore;

namespace BeSpokedBikes.Repositories
{
    public class ProductRepository:IProductRepository
    {
        public readonly AppDbContext _appDbContext;

        public ProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _appDbContext.Products.OrderBy(p=>p.Name).ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var result = await _appDbContext.Products.FindAsync(id);

            if (result == null)
            {
                throw new KeyNotFoundException();
            }
            return result;
        }

        public async Task UpdateAsync(Product product)
        {
            _appDbContext.Products.Update(product);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
