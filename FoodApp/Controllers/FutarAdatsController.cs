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

namespace FoodApp.Controllers
{
    public class FutarAdatsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public FutarAdatsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: FutarAdats
        public async Task<IActionResult> FutarCim()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var UserId = user.Id;

            FutarAdat futar = _context.FutarAdat.Where(cim => cim.IdentityUser.Id == UserId).FirstOrDefault();
            return View(futar);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> FutarCim([Bind("FutarId,Keresztnev,Vezeteknev,Jarmu,Telefonszam,Varos,Kezdes,Vegzes")] FutarAdat futarAdat)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (ModelState.IsValid)
            {
                futarAdat.IdentityUser = user;
                if (_context.FutarAdat.Where(cim => cim.IdentityUser.Id == user.Id).Any())
                {
                    futarAdat.FutarId = _context.FutarAdat.Where(cim => cim.IdentityUser.Id == user.Id).AsNoTracking().FirstOrDefault().FutarId;
                    _context.Update(futarAdat);
                }
                else
                {
                    _context.Add(futarAdat);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");


            }
            return RedirectToAction("Index", "Home");
        }
    }
}
