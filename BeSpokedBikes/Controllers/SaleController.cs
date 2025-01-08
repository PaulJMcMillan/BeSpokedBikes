using BeSpokedBikes.Interfaces;
using BeSpokedBikes.Models;
using BeSpokedBikes.Repositories;
using BeSpokedBikes.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BeSpokedBikes.Controllers
{
    public class SaleController : Controller
    {
        private readonly ISaleService _saleService;
        private readonly IProductService _productService;
        private readonly ISalesPersonService _salesPersonService;
        private readonly ICustomerService _customerService;
        private readonly ILogger<SaleController> _logger;

        public SaleController(ISaleService saleService, AppDbContext context, IProductService productService, ISalesPersonService salesPersonService,
                ICustomerService customerService, ILogger<SaleController> logger)
        {
            _saleService = saleService;
            _productService = productService;
            _salesPersonService = salesPersonService;
            _customerService = customerService;
            _logger = logger;
        }

        public async Task<IActionResult> Index(DateTime? startDate, DateTime? endDate)
        {
            try
            {
                var result = await _saleService.GetSalesByDateRangeAsync(startDate, endDate);

                var salesViewModel = new SalesViewModel
                {
                    StartDate = startDate,
                    EndDate = endDate,
                    Sales = result
                };

                return View(salesViewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500);
            }
        }

        // GET: Sales/Create
        public async Task<IActionResult> Create()
        {
            try
            {
                var products = await _productService.GetAllAsync();
                var salesPersons = await _salesPersonService.GetAllSalesPersonsAsync();
                var customers = await _customerService.GetAllAsync();

                var productSelectList = products.Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Name
                }).ToList();

                var salesPersonSelectList = salesPersons.Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.LastName + ", " + p.FirstName
                }).ToList();

                var customerSelectList = customers.Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.LastName + ", " + p.FirstName
                }).ToList();

                var saleCompositeViewModel = new SaleCompositeViewModel
                {
                    Products = productSelectList,
                    SalesPersons = salesPersonSelectList,
                    Customers = customerSelectList,
                    Sale = new Sale()
                };

                return View(saleCompositeViewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500);
            }
        }

        //POST: Sales/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductId,SalesPersonId,CustomerId,SalesDate")] Sale sale)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(500);
                }

                await _saleService.AddAsync(sale);
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
