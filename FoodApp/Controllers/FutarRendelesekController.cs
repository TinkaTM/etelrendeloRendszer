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
    public class FutarRendelesekController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public FutarRendelesekController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> FutarRendelesekV()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var UserId = user.Id;
            var futar = _context.FutarAdat.Where(f => f.UserId == UserId).FirstOrDefault();
            FutarRendelesViewModel vm = new FutarRendelesViewModel
            {
                Rendelesek = new List<RendelesDB>()
            };
            vm.Futar = futar;
            if (futar != null)
            {
                
                var FutarID = futar.FutarId;
                List<RendelesStatus> Stats = _context.rendelesStatuse.Where(s => s.FutarId == FutarID).ToList();
                foreach(var rendeles in Stats)
                {
                    var rendelesAdat = _context.Rendeles.Find(rendeles.RendelesId);
                    var Etteremcim = _context.EtteremCim.Find(rendeles.EtteremId);
                    var RendelesDetail = _context.RendelesDetail.Where(rd => rd.RendelesId == rendeles.RendelesId).ToList();
                    int total = 0;
                    foreach(var rd in RendelesDetail)
                    {
                        rd.Etlap = _context.Etlap.Find(rd.EtlapId);
                        int ar = rd.Etlap.Ar * rd.Darab;
                        total = total + ar;
                    }
                    
                    RendelesDB vmdb = new RendelesDB
                    {
                        RendelesAdatok = rendelesAdat,
                        Etterem = Etteremcim,
                        RendelesEtelek = RendelesDetail,
                        Stat = rendeles,
                        RendelesTotal = total
                    };
                    vm.Rendelesek.Add(vmdb);
                }
                vm.Rendelesek.Sort((cs1, cs2) => cs1.RendelesAdatok.RendelesIdo.CompareTo(cs2.RendelesAdatok.RendelesIdo));
                return View(vm);
            }
            else
            {
                //futaradats kiotöltés
                return View();
            }
            
        }
        public IActionResult FutarRendelesElfogad() 
        {
            return View();
        }
    }
}
