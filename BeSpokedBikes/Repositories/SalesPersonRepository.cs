using BeSpokedBikes.Interfaces;
using BeSpokedBikes.Models;
using Microsoft.EntityFrameworkCore;

namespace BeSpokedBikes.Repositories
{
    public class SalesPersonRepository : ISalesPersonRepository
    {
        public readonly AppDbContext _appDbContext;

        public SalesPersonRepository(AppDbContext appDbContext) 
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<SalesPerson>> GetAllSalesPersonsAsync()
        {
            return await _appDbContext.SalesPersons.ToListAsync();
        }

        public async Task<SalesPerson> GetById(int id)
        {
            var salesPerson = await _appDbContext.SalesPersons.FindAsync(id);

            if (salesPerson == null)
            {
                throw new KeyNotFoundException();
            }
            return salesPerson;
        }

        public async Task UpdateAsync(SalesPerson salesPerson)
        {
            _appDbContext.SalesPersons.Update(salesPerson);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
