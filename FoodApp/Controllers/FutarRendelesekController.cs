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
                List<RendelesStatus> Stats = _context.rendelesStatuse.Where(s => s.FutarId == FutarID && (s.RenStatus == Status.FutarraVar || s.RenStatus == Status.Futarnal)).ToList();
                foreach(var rendeles in Stats)
                {
                    var rendelesAdat = _context.Rendeles.Find(rendeles.RendelesId);
                    var Etteremcim = _context.EtteremCim.Find(rendeles.EtteremId);
                    var RendelesDetail = _context.RendelesDetail.Where(rd => rd.RendelesId == rendeles.RendelesId && rd.EtteremCimId == rendeles.EtteremId).ToList();
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
                return RedirectToAction("FutarCim", "FutarAdats");
            }
            
        }
        public async Task<IActionResult> FutarRendelesElfogad(int statId) 
        {
            var stat = await _context.rendelesStatuse.FindAsync(statId);
            stat.RenStatus = Status.Futarnal;
            stat.CompletionTime = CalcCompTime(stat.FutarId);
            _context.Update(stat);
            _context.SaveChanges();
            return RedirectToAction("FutarRendelesekV");
        }
        public async Task<IActionResult> FutarRendelesElutasit(int statId)
        {
            var stat = await _context.rendelesStatuse.FindAsync(statId);
            stat.RenStatus = Status.FutarDeclined;
            _context.Update(stat);
            _context.SaveChanges();
            return RedirectToAction("FutarRendelesekV");
        }
        public async Task<IActionResult> FutarRendelesTeljesitve(int statId)
        {
            var stat = await _context.rendelesStatuse.FindAsync(statId);
            stat.RenStatus = Status.Completed;
            _context.Update(stat);
            _context.SaveChanges();
            return RedirectToAction("FutarRendelesekV");
        }
        public DateTime CalcCompTime(int? futarid) 
        {
            DateTime curr = DateTime.Now;
            string futarjarmu = _context.FutarAdat.Find(futarid).Jarmu;
            int rendelesek = _context.rendelesStatuse.Where(s => s.FutarId == futarid && s.RenStatus == Status.Futarnal).Count();
            if (futarjarmu.Contains("Személygépjármű"))
            {
                curr = curr.AddMinutes(20 + (rendelesek * 5));
            }
            if (futarjarmu.Contains("Robogó"))
            {
               curr = curr.AddMinutes(25 + (rendelesek * 8));
            }
            if (futarjarmu.Contains("Bicikli"))
            {
                curr = curr.AddMinutes(25 + (rendelesek * 10));
            }
            return curr;
        }
        public async Task<IActionResult> FutarRendelesekComp()
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
                List<RendelesStatus> Stats = _context.rendelesStatuse.Where(s => s.FutarId == FutarID && s.RenStatus == Status.Completed).ToList();
                foreach (var rendeles in Stats)
                {
                    var rendelesAdat = _context.Rendeles.Find(rendeles.RendelesId);
                    var Etteremcim = _context.EtteremCim.Find(rendeles.EtteremId);
                    var RendelesDetail = _context.RendelesDetail.Where(rd => rd.RendelesId == rendeles.RendelesId && rd.EtteremCimId == rendeles.EtteremId).ToList();
                    int total = 0;
                    foreach (var rd in RendelesDetail)
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
                return RedirectToAction("FutarCim", "FutarAdats");
            }

        }
    }
}
