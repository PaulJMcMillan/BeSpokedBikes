using BeSpokedBikes.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BeSpokedBikes.Controllers
{
    public class ReportController : Controller
    {
        private readonly IReportService _reportService;
        private readonly ILogger<ReportController> _logger;

        public ReportController(IReportService reportService, ILogger<ReportController> logger)
        {
            _reportService = reportService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500);
            }
        }

        public async Task<IActionResult> ShowReport(int year, string quarter)
        {
            try
            {
                var result = await _reportService.GetQuarterlyCommissionReportAsync(year, quarter);
                return View(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500);
            }
        }
    }
}
