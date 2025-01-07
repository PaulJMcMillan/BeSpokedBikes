using BeSpokedBikes.Models;

namespace BeSpokedBikes.Interfaces
{
    public interface ISaleRepository
    {
        Task<List<Sale>> GetAllAsync();
    }
}
