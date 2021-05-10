using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FoodApp.Data;
using FoodApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using FoodApp.ViewModels;

namespace FoodApp.Controllers
{
    public class EtlapsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public EtlapsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Etlaps
        [Authorize(Roles = "Étterem,Vendég")]
        public async Task<IActionResult> Index()
        {
            EtlapViewModel vm = new EtlapViewModel {
                EtlapDict = new Dictionary<string, List<Etlap>>()
            };
            var user = await _userManager.GetUserAsync(HttpContext.User);
            List<Etlap> etlaps = _context.Etlap.Where(e => e.UserId == user.Id).ToList();
            HashSet<string> cats = new HashSet<string>();
            foreach(var kaja in etlaps)
            {
                cats.Add(kaja.Kategoria);
            }
            foreach(var cat in cats)
            {
                if (!vm.EtlapDict.ContainsKey(cat))
                {
                    vm.EtlapDict.Add(cat, new List<Etlap>());
                    vm.EtlapDict[cat].AddRange(etlaps.Where(s => s.Kategoria.Equals(cat)).ToList());
                }
            }
            return View(vm);
        }


        // GET: Etlaps/SHowSearchForm
        public async Task<IActionResult> ShowSearchForm()
        {
            return View();
        }

        // POST: Etlaps/SHowSearchForm
        public async Task<IActionResult> ShowSearchResults(String SearchPhrase)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            return View("Index",await _context.Etlap.Where(j=> (j.Nev.Contains(SearchPhrase) || j.Kategoria.Contains(SearchPhrase)) && j.UserId == user.Id).ToListAsync());
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
        public async Task<IActionResult> Create([Bind("ID,Kategoria,Nev,Ar,Allergen,Leiras,Kedvezmeny")] Etlap etlap)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (ModelState.IsValid)
            {
                etlap.IdentityUser = user;
                int ujar = etlap.Ar;
                double merteke = 0;
                if (etlap.Kedvezmeny != null)
                {
                    var valami = Convert.ToDouble(etlap.Kedvezmeny);
                    merteke = etlap.Ar * (valami / 100);
                }
                etlap.Ar = ujar - Convert.ToInt32(merteke);
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
        public async Task<IActionResult> Edit(int id, [Bind("ID,Kategoria,Nev,Ar,Allergen,Leiras,Kedvezmeny")] Etlap etlap)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (id != etlap.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    etlap.IdentityUser = user;
                    int ujar = etlap.Ar;
                    double merteke = 0;
                    if (etlap.Kedvezmeny != null) 
                    {
                        var valami = Convert.ToDouble(etlap.Kedvezmeny);
                        merteke = etlap.Ar * (valami/100);
                    }
                    etlap.Ar = ujar - Convert.ToInt32(merteke);
                    _context.Add(etlap);
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
