using FoodApp.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodApp.Controllers
{
    public class VendegController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public VendegController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.EtteremCim.ToListAsync());
        }
        public async Task<IActionResult> Etlap(int id, string alert)
        {
            ViewBag.AlertClass = alert;
            var userId = _context.EtteremCim.FindAsync(id).Result.UserId;
            var etlap = await _context.Etlap.Where(etlap => etlap.UserId == userId).ToListAsync();
            return View(etlap);
        }
    }
}
