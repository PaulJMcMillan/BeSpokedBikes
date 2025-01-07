using BeSpokedBikes.Models;

namespace BeSpokedBikes.Interfaces
{
    public interface ISaleService
    {
        Task<List<Sale>> GetAllAsync();
    }
}
