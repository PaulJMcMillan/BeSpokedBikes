using BeSpokedBikes.Interfaces;
using BeSpokedBikes.Models;
using Microsoft.EntityFrameworkCore;

namespace BeSpokedBikes.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public readonly AppDbContext _appDbContext;

        public CustomerRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return await _appDbContext.Customers.OrderBy(c=>c.LastName).ThenBy(c=>c.FirstName).ToListAsync();
        }
    }
}
