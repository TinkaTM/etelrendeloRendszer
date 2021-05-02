using FoodApp.Data;
using FoodApp.ViewModels;
using FoodApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace FoodApp.Controllers
{
    public class EtteremFutarKezelController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public EtteremFutarKezelController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult FutarValaszt()
        {
            var Futarok = _context.FutarAdat.ToList();
            
            List<FutarViewModel> vms = new List<FutarViewModel>();
            foreach (var futar in Futarok)
            {
                FutarViewModel vm = new FutarViewModel
                    {
                        Futar = futar
                    };
                TimeSpan start = futar.Kezdes.TimeOfDay;
                TimeSpan end = futar.Vegzes.TimeOfDay;
                TimeSpan now = DateTime.Now.TimeOfDay;
                if ((now > start) && (now < end)) 
                {
                    vm.Elerheto = true;
                }
                else { vm.Elerheto = false; }
                vms.Add(vm);
            }
                
            return View(vms);
        }
        public async Task<IActionResult> FutarRendelesKezel(int Futarid)
        {
            var futar = _context.FutarAdat.Find(Futarid);
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var UserId = user.Id;
            var Etterem = _context.EtteremCim.Where(ec => ec.UserId == UserId).FirstOrDefault();
            if (Etterem == null) return View();
            var etteremid = Etterem.ID;
            var etelek = _context.RendelesDetail.Where(s => s.EtteremCimId == etteremid).ToList();
            FutarRendelesKezelViewModel vms = new FutarRendelesKezelViewModel();
            vms.Rendelesek = new List<RendelesDarab>();
            vms.Futar = futar;
            if (etelek.Count > 0)
            {
                //Dictionary<int, List<RendelesDetail>> dict = new Dictionary<int, List<RendelesDetail>>();
                //foreach (var etel in etelek)
                //{
                //    etel.Etlap = _context.Etlap.Find(etel.EtlapId);
                //    if (!dict.ContainsKey(etel.RendelesId)) dict.Add(etel.RendelesId, new List<RendelesDetail>());
                //    dict[etel.RendelesId].Add(etel);
                //}
                //for (int i = 0; i < 10; i++)
                //{
                //    foreach (var rendelesek in dict)
                //    {
                //        RendelesDarab rd = new RendelesDarab
                //        {
                //            RendelesAdatok = _context.Rendeles.Find(rendelesek.Key),
                //            RendelesEtelek = rendelesek.Value,
                //            Futarnal = false
                //        };
                //        vms.Rendelesek.Add(rd);
                //    }
                //}
                HashSet<int> RendelesIds = new HashSet<int>();
                foreach (var etel in etelek) 
                {
                    etel.Etlap = _context.Etlap.Find(etel.EtlapId);
                    RendelesIds.Add(etel.RendelesId);
                }
                Dictionary<RendelesStatus, List<RendelesDetail>> dict = new Dictionary<RendelesStatus, List<RendelesDetail>>();
                foreach (var id in RendelesIds)
                {
                    RendelesStatus stat = _context.rendelesStatuse.Where(s => s.RendelesId == id).FirstOrDefault();
                    dict.Add(stat, new List<RendelesDetail>(etelek.FindAll(s => s.RendelesId == id)));
                }
                foreach(var rendeles in dict)
                {
                    int total = 0;
                    foreach (var etel in rendeles.Value)
                    {
                        int ar = etel.Etlap.Ar * etel.Darab;
                        total = total + ar;
                    }
                    if (rendeles.Key.FutarId == futar.FutarId) 
                    {
                        RendelesDarab rd = new RendelesDarab
                        {
                            RendelesAdatok = _context.Rendeles.Find(rendeles.Key.RendelesId),
                            RendelesEtelek = rendeles.Value,
                            Futarnal = true,
                            RendelesTotal = total,
                            RendekesStatId = _context.rendelesStatuse.Where(s => s.EtteremId == etteremid && s.RendelesId == rendeles.Key.RendelesId).FirstOrDefault().RendelesStatusId
                        };
                        vms.Rendelesek.Add(rd);
                    }
                    else if (rendeles.Key.RenStatus == Status.FutarraVar)
                    {
                        RendelesDarab rd = new RendelesDarab
                        {
                            RendelesAdatok = _context.Rendeles.Find(rendeles.Key.RendelesId),
                            RendelesEtelek = rendeles.Value,
                            Futarnal = false,
                            RendelesTotal = total,
                            RendekesStatId = _context.rendelesStatuse.Where(s => s.EtteremId == etteremid && s.RendelesId == rendeles.Key.RendelesId).FirstOrDefault().RendelesStatusId
                        };
                        vms.Rendelesek.Add(rd);
                    }
                }
            }
            return View(vms);
        }
        [HttpPost]
        public IActionResult FutarRendelesFrissit(int[] Ids,int Futarid)
        {
            foreach(var Rendelesid in Ids)
            {
               var Rendelesstat = _context.rendelesStatuse.Find(Rendelesid);
                Rendelesstat.RenStatus = Status.FutarPending;
                Rendelesstat.FutarId = Futarid;
                _context.Update(Rendelesstat);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(FutarValaszt));
        }
    }
}
