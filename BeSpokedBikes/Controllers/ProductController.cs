using BeSpokedBikes.Interfaces;
using BeSpokedBikes.Models;
using Microsoft.AspNetCore.Mvc;

namespace BeSpokedBikes.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var result = await _productService.GetAllAsync();
                return View(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var result = await _productService.GetByIdAsync(id);
                return View(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Manufacturer,Style,PurchasePrice,SalesPrice,QtyOnHand,CommissionPercentage")] Product product)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(500);
                }

                await _productService.UpdateAsync(product);
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
