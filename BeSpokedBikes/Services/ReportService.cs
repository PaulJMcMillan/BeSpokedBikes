using BeSpokedBikes.Interfaces;
using BeSpokedBikes.ViewModels;

namespace BeSpokedBikes.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;

        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }
        public async Task<List<CommissionReportViewModel>> GetQuarterlyCommissionReportAsync(int year, string quarter)
        {
            return await _reportRepository.GetQuarterlyCommissionReportAsync(year, quarter);
        }
    }
}
