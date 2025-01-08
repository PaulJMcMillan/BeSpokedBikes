using BeSpokedBikes.ViewModels;

namespace BeSpokedBikes.Interfaces
{
    public interface IReportService
    {
        Task<List<CommissionReportViewModel>> GetQuarterlyCommissionReportAsync(int year, string quarter);
    }
}
