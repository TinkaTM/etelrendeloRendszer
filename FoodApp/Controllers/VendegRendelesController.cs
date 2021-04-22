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
    public class VendegRendelesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public VendegRendelesController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            List<VendegRendelesViewModel> vms = new List<VendegRendelesViewModel>();
            bool isSignedIn = HttpContext.User != null && HttpContext.User.Identity.IsAuthenticated;
            if (isSignedIn)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                var UserId = user.Id;
                var Rendelesek = _context.Rendeles.Where(s => s.UserId == UserId).ToList();
                if(Rendelesek.Count > 0)
                {
                    foreach(var rendeles in Rendelesek)
                    {
                        List<RendelesStatus> Stats = new List<RendelesStatus>();
                        List<RendelesDetail> rd = new List<RendelesDetail>();
                        Dictionary<RendelesStatus, List<RendelesDetail>> rendelesadatok = new Dictionary<RendelesStatus, List<RendelesDetail>>();
                        Stats = _context.rendelesStatuse.Where(r => r.RendelesId == rendeles.RendelesId).ToList();
                        int total = 0;
                        foreach (var stat in Stats) 
                        {
                            rd = _context.RendelesDetail.Where(r => r.RendelesId == rendeles.RendelesId).ToList();
                            stat.Etterem = _context.EtteremCim.Find(stat.EtteremId);
                            foreach (var re in rd)
                            {
                                re.Etlap = _context.Etlap.Find(re.EtlapId);
                                total = total + re.Etlap.Ar * re.Darab;
                            }
                            rendelesadatok.Add(stat, rd);
                        }
                        VendegRendelesViewModel vm = new VendegRendelesViewModel
                        {
                            RendelesAdatok = rendeles,
                            RendelesEtelek = rendelesadatok,
                            RendelesTotal = total
                        };
                        
                        vms.Add(vm);
                    }
                }
                return View(vms);
            }
            else
            {
                return View();
            }
        }
    }
}
