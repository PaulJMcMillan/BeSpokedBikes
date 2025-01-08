using BeSpokedBikes.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BeSpokedBikes.Controllers
{
    public class ReportController : Controller
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ShowReport(int year, string quarter)
        {
            var result = await _reportService.GetQuarterlyCommissionReportAsync(year, quarter);
            return View(result);
        }
    }
}
