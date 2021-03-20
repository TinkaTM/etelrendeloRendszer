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
    public class EtteremCimsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public EtteremCimsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> CimKezel()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var UserId = user.Id;

            EtteremCim etteremCim = _context.EtteremCim.Where(cim => cim.IdentityUser.Id == UserId).FirstOrDefault();
            return View(etteremCim);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CimKezel([Bind("ID,EtteremNev,Iranyitoszam,Varos,Cim,Nyitas,Zaras")] EtteremCim etteremCim)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (ModelState.IsValid)
            {
                etteremCim.IdentityUser = user;
                if (_context.EtteremCim.Where(cim => cim.IdentityUser.Id == user.Id).Any()) 
                {
                    etteremCim.ID = _context.EtteremCim.Where(cim => cim.IdentityUser.Id == user.Id).AsNoTracking().FirstOrDefault().ID;
                    _context.Update(etteremCim);
                }
                else 
                {
                    _context.Add(etteremCim);
                }
                
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Etlaps");


            }
            return View();
        }
    }
}
