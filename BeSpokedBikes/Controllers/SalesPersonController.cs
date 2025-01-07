﻿using System;
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

        public SalesPersonController(ISalesPersonService salesPersonService)
        {
            _salesPersonService = salesPersonService;
        }

        // GET: SalesPersons
        public async Task<IActionResult> Index()
        {
            var result = await _salesPersonService.GetAllSalesPersonsAsync();
            return View(result);
        }

        //GET: SalesPersons/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
                var salesPerson = await _salesPersonService.GetByIdAsync(id);
                return View(salesPerson);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Address,Phone,StartDate,TerminationDate,Manager")] SalesPerson salesPerson)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(500);
            }

            await _salesPersonService.UpdateAsync(salesPerson);
            return RedirectToAction(nameof(Index));
        }

    }
}
