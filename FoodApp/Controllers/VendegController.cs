using FoodApp.Data;
using FoodApp.Models;
using FoodApp.ViewModels;
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
            EtlapViewModel vm = new EtlapViewModel
            {
                EtlapDict = new Dictionary<string, List<Etlap>>()
            };
            var user = await _userManager.GetUserAsync(HttpContext.User);
            List<Etlap> etlaps = _context.Etlap.Where(e => e.UserId == userId).ToList();
            HashSet<string> cats = new HashSet<string>();
            foreach (var kaja in etlaps)
            {
                cats.Add(kaja.Kategoria);
            }
            foreach (var cat in cats)
            {
                if (!vm.EtlapDict.ContainsKey(cat))
                {
                    vm.EtlapDict.Add(cat, new List<Etlap>());
                    vm.EtlapDict[cat].AddRange(etlaps.Where(s => s.Kategoria.Equals(cat)).ToList());
                }
            }
            return View(vm);
        }
    }
}
