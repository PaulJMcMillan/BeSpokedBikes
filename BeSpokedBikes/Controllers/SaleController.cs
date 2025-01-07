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

        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _saleService.GetAllAsync());
        }

        //// GET: Sales/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var sale = await _context.Sales
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (sale == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(sale);
        //}

        // GET: Sales/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,ProductId,SalesPersonId,CustomerId,SalesDate")] Sale sale)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(sale);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(sale);
        //}

        // GET: Sales/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var sale = await _context.Sales.FindAsync(id);
        //    if (sale == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(sale);
        //}

        // POST: Sales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,ProductId,SalesPersonId,CustomerId,SalesDate")] Sale sale)
        //{
        //    if (id != sale.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(sale);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!SaleExists(sale.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(sale);
        //}

        // GET: Sales/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var sale = await _context.Sales
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (sale == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(sale);
        //}

        //// POST: Sales/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var sale = await _context.Sales.FindAsync(id);
        //    if (sale != null)
        //    {
        //        _context.Sales.Remove(sale);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool SaleExists(int id)
        //{
        //    return _context.Sales.Any(e => e.Id == id);
        //}
    }
}
