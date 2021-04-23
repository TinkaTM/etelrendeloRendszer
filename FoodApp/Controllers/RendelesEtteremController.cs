using FoodApp.Data;
using FoodApp.Models;
using FoodApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodApp.Controllers
{
    public class RendelesEtteremController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public RendelesEtteremController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Rendelesek()
        {

            List<RendelesEtteremViewModel> vms = new List<RendelesEtteremViewModel>();
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var UserId = user.Id;
            var Etterem = _context.EtteremCim.Where(s => s.UserId == UserId).FirstOrDefault();
            if (Etterem == null) return View(vms);
            var Etteremid = Etterem.ID;
            var etelek = _context.RendelesDetail.Where(s => s.EtteremCimId == Etteremid).ToList();
            if(etelek.Count > 0)
            {
                Dictionary<int, List<RendelesDetail>> dict = new Dictionary<int, List<RendelesDetail>>();
                foreach (var etel in etelek)
                {
                    etel.Etlap = _context.Etlap.Find(etel.EtlapId);
                    if (!dict.ContainsKey(etel.RendelesId)) dict.Add(etel.RendelesId, new List<RendelesDetail>());
                    dict[etel.RendelesId].Add(etel);
                }
                foreach(var rendeles in dict)
                {
                    RendelesEtteremViewModel vm = new RendelesEtteremViewModel
                    {
                        RendelesAdatok = _context.Rendeles.Find(rendeles.Key),
                        RendelesEtelek = rendeles.Value,
                        Stat = _context.rendelesStatuse.Where(s => s.RendelesId == rendeles.Key && s.EtteremId == Etteremid ).FirstOrDefault()
                    };
                    int total = 0;
                    foreach(var etel in rendeles.Value)
                    {
                        int ar = etel.Etlap.Ar * etel.Darab;
                        total = total + ar;
                    }
                    vm.RendelesTotal = total;
                    vms.Add(vm);
                }
            }
           
            
            return View(vms);
        }
        [HttpPost]
        public async Task<IActionResult> RendelesElfogad(int statId, DateTime Compdate) 
        {
            var stat = await _context.rendelesStatuse.FindAsync(statId);
            DateTime curr = DateTime.Now;
            curr = curr.AddHours(Compdate.Hour);
            curr = curr.AddMinutes(Compdate.Minute);
            stat.CompletionTime = curr;
            stat.RenStatus = Status.Accepted;
            _context.Update(stat);
            _context.SaveChanges();
            return RedirectToAction("Rendelesek");
        }
        public async Task<IActionResult> RendelesElutasit(int statId) {
            var stat = await _context.rendelesStatuse.FindAsync(statId);
            stat.RenStatus = Status.Declined;
            _context.Update(stat);
            _context.SaveChanges();
            return RedirectToAction("Rendelesek");
        }
    }
}
