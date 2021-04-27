using FoodApp.Data;
using FoodApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodApp.Controllers
{
    public class EtteremFutarKezelController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EtteremFutarKezelController(ApplicationDbContext context)
        {
            _context = context;
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
    }
}
