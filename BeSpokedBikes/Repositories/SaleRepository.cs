using BeSpokedBikes.Interfaces;
using BeSpokedBikes.Models;
using Microsoft.EntityFrameworkCore;

namespace BeSpokedBikes.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly AppDbContext _appDbContext;

        public SaleRepository(AppDbContext appDbContext) 
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Sale>> GetAllAsync()
        {
            return await _appDbContext.Sales.ToListAsync();
        }
    }
}
