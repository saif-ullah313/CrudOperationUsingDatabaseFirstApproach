using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrudOperationUsingDatabaseFirstApproach.Data;
using CrudOperationUsingDatabaseFirstApproach.Models;

namespace CrudOperationUsingDatabaseFirstApproach.Controllers
{
    public class CountryDatasController : Controller
    {
        private readonly CountryDbContext _context;

        public CountryDatasController(CountryDbContext context)
        {
            _context = context;
        }

        // GET: CountryDatas
        public async Task<IActionResult> Index()
        {
            return View(await _context.CountryData.ToListAsync());
        }

        // GET: CountryDatas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var countryData = await _context.CountryData
                .FirstOrDefaultAsync(m => m.id == id);
            if (countryData == null)
            {
                return NotFound();
            }

            return View(countryData);
        }

        // GET: CountryDatas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CountryDatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Country_Name,Country_Capital,Country_Currency,Country_Continent")] CountryData CountryData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(CountryData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(CountryData);
        }

        // GET: CountryDatas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbl_Country = await _context.CountryData.FindAsync(id);
            if (tbl_Country == null)
            {
                return NotFound();
            }
            return View(tbl_Country);
        }

        // POST: CountryDatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Country_Name,Country_Capital,Country_Currency,Country_Continent")] CountryData countryData)
        {
            if (id != countryData.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(countryData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CountryDataExists(countryData.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(countryData);
        }

        // GET: CountryDatas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var countryData = await _context.CountryData
                .FirstOrDefaultAsync(m => m.id == id);
            if (countryData == null)
            {
                return NotFound();
            }

            return View(countryData);
        }

        // POST: CountryDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var countryData = await _context.CountryData.FindAsync(id);
            if (countryData != null)
            {
                _context.CountryData.Remove(countryData);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CountryDataExists(int id)
        {
            return _context.CountryData.Any(e => e.id == id);
        }
    }
}
