using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FoodApp.Data;
using FoodApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace FoodApp.Controllers
{
    public class VendegCimsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public VendegCimsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: VendegCims
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var applicationDbContext = _context.VendegCim.Where(c => c.UserId == user.Id);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: VendegCims/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendegCim = await _context.VendegCim
                .FirstOrDefaultAsync(m => m.VendegCimId == id);
            if (vendegCim == null)
            {
                return NotFound();
            }

            return View(vendegCim);
        }

        // GET: VendegCims/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: VendegCims/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VendegCimId,VezetekNev,KeresztNev,Varos,Iranyitoszam,Cim,Email,Telefonszam")] VendegCim vendegCim)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                vendegCim.IdentityUser = user;
                _context.Add(vendegCim);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vendegCim);
        }

        // GET: VendegCims/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendegCim = await _context.VendegCim.FindAsync(id);
            if (vendegCim == null)
            {
                return NotFound();
            }
            return View(vendegCim);
        }

        // POST: VendegCims/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VendegCimId,VezetekNev,KeresztNev,Varos,Iranyitoszam,Cim,Email,Telefonszam")] VendegCim vendegCim)
        {
            if (id != vendegCim.VendegCimId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vendegCim);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendegCimExists(vendegCim.VendegCimId))
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
            return View(vendegCim);
        }

        // GET: VendegCims/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendegCim = await _context.VendegCim
                .FirstOrDefaultAsync(m => m.VendegCimId == id);
            if (vendegCim == null)
            {
                return NotFound();
            }

            return View(vendegCim);
        }

        // POST: VendegCims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vendegCim = await _context.VendegCim.FindAsync(id);
            _context.VendegCim.Remove(vendegCim);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendegCimExists(int id)
        {
            return _context.VendegCim.Any(e => e.VendegCimId == id);
        }
    }
}
