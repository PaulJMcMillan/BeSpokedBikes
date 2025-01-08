using BeSpokedBikes.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BeSpokedBikes.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ICustomerService customerService, ILogger<CustomerController> logger)
        {
            _customerService = customerService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                return View(await _customerService.GetAllAsync());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500);
            }
            
        }
    }
}
