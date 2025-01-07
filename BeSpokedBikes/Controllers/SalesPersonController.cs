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
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var idInt = (int)id;
                var salesPerson = await _salesPersonService.GetByIdAsync(idInt);
                return View(salesPerson);
            }
            catch(KeyNotFoundException ex)
            {
                _logger.LogError(ex, ex.Message);
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500);
            }
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Address,Phone,StartDate,TerminationDate,Manager")] SalesPerson salesPerson)
        {
            if (id != salesPerson.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                var invalidDataEx = new InvalidDataException("Model State is invalid");
                _logger.LogError(invalidDataEx, invalidDataEx.Message);
                return StatusCode(500);
            }

            try
            {
                await _salesPersonService.UpdateAsync(salesPerson);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.Message);
                return StatusCode(500);
            }

            return RedirectToAction(nameof(Index));
            //return View(product);
        }

    }
}
