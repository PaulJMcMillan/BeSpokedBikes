using BeSpokedBikes.ViewModels;

namespace BeSpokedBikes.Interfaces
{
    public interface IReportRepository
    {
        Task<List<CommissionReportViewModel>> GetQuarterlyCommissionReportAsync(int year, string quarter);
    }
}
