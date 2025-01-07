using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BeSpokedBikes.Models;
using BeSpokedBikes.Repositories;
using BeSpokedBikes.Interfaces;
using BeSpokedBikes.ViewModels;
using BeSpokedBikes.Services;

namespace BeSpokedBikes.Controllers
{
    public class SaleController : Controller
    {
        private readonly ISaleService _saleService;
        private readonly IProductService _productService;
        private readonly ISalesPersonService _salesPersonService;
        private readonly ICustomerService _customerService;

        public SaleController(ISaleService saleService, AppDbContext context, IProductService productService, ISalesPersonService salesPersonService,
                ICustomerService customerService)
        {
            _saleService = saleService;
            _productService = productService;
            _salesPersonService = salesPersonService;
            _customerService = customerService;
        }

        public async Task<IActionResult> Index(DateTime? startDate, DateTime? endDate)
        {
            var result = await _saleService.GetSalesByDateRangeAsync(startDate, endDate);

            var salesViewModel = new SalesViewModel
            {
                StartDate = startDate,
                EndDate = endDate,
                Sales = result
            };

            var products = await _productService.GetAllAsync();
            var salesPersons = await _salesPersonService.GetAllSalesPersonsAsync();
            var customers = await _customerService.GetAllAsync();

            var saleCompositeViewModel = new SaleCompositeViewModel
            {
                Sale = new Sale(),
                SalesViewModel = salesViewModel,
                Products = products,
                SalesPersons = salesPersons,
                Customers = customers
            };

            return View(saleCompositeViewModel);
        }

        // GET: Sales/Create
        public IActionResult Create()
        {
            return View();
        }

        //POST: Sales/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductId,SalesPersonId,CustomerId,SalesDate")] Sale sale)
        {
            if (ModelState.IsValid)
            {
               await _saleService.AddAsync(sale);
                return RedirectToAction(nameof(Index));
            }

            return View(sale);
        }
    }
}
