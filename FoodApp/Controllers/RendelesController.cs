using FoodApp.Data;
using FoodApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodApp.Controllers
{
    public class RendelesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly Kocsi _kocsi;
        private readonly UserManager<IdentityUser> _userManager;

        public RendelesController(ApplicationDbContext context, Kocsi kocsi, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _kocsi = kocsi;
            _userManager = userManager;
        }
        public IActionResult RendelesVendeg()
        {
            return View();
        }
        public async Task<IActionResult> Rendeles()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var applicationDbContext = _context.VendegCim.Where(c => c.UserId == user.Id);
            return View(applicationDbContext.ToList());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RendelesVendeg([Bind("RendelesId,VezetekNev,KeresztNev,Varos,Iranyitoszam,Cim,Email,Telefonszam")] Rendeles rendeles)
        {
            if (ModelState.IsValid)
            {
                rendeles.RendelesIdo = DateTime.Now;
                var items = _kocsi.GetKocsiItems();
                _kocsi.KocsiItems = items;
                _context.Rendeles.Add(rendeles);
                _context.SaveChanges();
                foreach (var item in items)
                {
                    RendelesDetail rendelesDetail = new RendelesDetail
                    {
                        Rendeles = rendeles,
                        Darab = item.Darab,
                        Etlap = item.Etel,
                        EtteremCimId = item.EtteremCimId
                    };
                    _context.RendelesDetail.Add(rendelesDetail);
                    _context.SaveChanges();
                }
                _kocsi.ClearKocsi();  
            }
                return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Rendeles(string Cimid) 
        {
            var cim = _context.VendegCim.Where(c => c.VendegCimId == Int32.Parse(Cimid)).FirstOrDefault();
            Rendeles rendeles = new Rendeles
            {
                VezetekNev = cim.VezetekNev,
                KeresztNev = cim.KeresztNev,
                Varos = cim.Varos,
                Iranyitoszam = cim.Iranyitoszam,
                Cim = cim.Cim,
                Email = cim.Email,
                Telefonszam = cim.Telefonszam
            };
            rendeles.RendelesIdo = DateTime.Now;
            var items = _kocsi.GetKocsiItems();
            _kocsi.KocsiItems = items;
            _context.Rendeles.Add(rendeles);
            _context.SaveChanges();
            foreach (var item in items)
            {
                RendelesDetail rendelesDetail = new RendelesDetail
                {
                    Rendeles = rendeles,
                    Darab = item.Darab,
                    Etlap = item.Etel,
                    EtteremCimId = item.EtteremCimId
                };
                _context.RendelesDetail.Add(rendelesDetail);
                _context.SaveChanges();
            }
            _kocsi.ClearKocsi();
            return RedirectToAction("Rendeles", "Rendeles");
        }
    }
}
