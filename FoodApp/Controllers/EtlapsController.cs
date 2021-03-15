using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FoodApp.Data;
using FoodApp.Models;

namespace FoodApp.Controllers
{
    public class EtlapsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EtlapsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Etlaps
        public async Task<IActionResult> Index()
        {
            return View(await _context.Etlap.ToListAsync());
        }

        // GET: Etlaps/SHowSearchForm
        public async Task<IActionResult> ShowSearchForm()
        {
            return View();
        }

        // POST: Etlaps/SHowSearchForm
        public async Task<IActionResult> ShowSearchResults(String SearchPhrase)
        {
            return View("Index",await _context.Etlap.Where(j=> j.Nev.Contains(SearchPhrase)).ToListAsync());
        }



        // GET: Etlaps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etlap = await _context.Etlap
                .FirstOrDefaultAsync(m => m.ID == id);
            if (etlap == null)
            {
                return NotFound();
            }

            return View(etlap);
        }

        // GET: Etlaps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Etlaps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Kategoria,Nev,Ar,Allergen,Leiras")] Etlap etlap)
        {
            if (ModelState.IsValid)
            {
                _context.Add(etlap);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(etlap);
        }

        // GET: Etlaps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etlap = await _context.Etlap.FindAsync(id);
            if (etlap == null)
            {
                return NotFound();
            }
            return View(etlap);
        }

        // POST: Etlaps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Kategoria,Nev,Ar,Allergen,Leiras")] Etlap etlap)
        {
            if (id != etlap.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(etlap);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EtlapExists(etlap.ID))
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
            return View(etlap);
        }

        // GET: Etlaps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etlap = await _context.Etlap
                .FirstOrDefaultAsync(m => m.ID == id);
            if (etlap == null)
            {
                return NotFound();
            }

            return View(etlap);
        }

        // POST: Etlaps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var etlap = await _context.Etlap.FindAsync(id);
            _context.Etlap.Remove(etlap);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EtlapExists(int id)
        {
            return _context.Etlap.Any(e => e.ID == id);
        }
    }
}
