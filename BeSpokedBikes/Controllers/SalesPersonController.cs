using BeSpokedBikes.Interfaces;
using BeSpokedBikes.Models;
using Microsoft.AspNetCore.Mvc;

namespace BeSpokedBikes.Controllers
{
    public class SalesPersonController : Controller
    {
        private readonly ISalesPersonService _salesPersonService;
        private readonly ILogger<SalesPersonController> _logger;

        public SalesPersonController(ISalesPersonService salesPersonService, ILogger<SalesPersonController> logger)
        {
            _salesPersonService = salesPersonService;
            _logger = logger;
        }

        // GET: SalesPersons
        public async Task<IActionResult> Index()
        {
            try
            {
                var result = await _salesPersonService.GetAllSalesPersonsAsync();
                return View(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500);
            }
            
        }

        //GET: SalesPersons/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var salesPerson = await _salesPersonService.GetByIdAsync(id);
                return View(salesPerson);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Address,Phone,StartDate,TerminationDate,Manager")] SalesPerson salesPerson)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(500);
                }

                await _salesPersonService.UpdateAsync(salesPerson);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500);
            }
        }
    }
}
