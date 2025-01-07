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

namespace BeSpokedBikes.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _productService.GetAllAsync();
            return View(result);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var result = await _productService.GetByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Manufacturer,Style,PurchasePrice,SalesPrice,QtyOnHand,CommissionPercentage")] Product product)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(500);
            }

            await _productService.UpdateAsync(product);
            return RedirectToAction(nameof(Index));
        }
    }
}
