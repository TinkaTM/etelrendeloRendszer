using FoodApp.Models;
using FoodApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodApp.Components
{
    public class KosarSzam:ViewComponent
    {
        private readonly Kocsi _kocsi;
        public KosarSzam(Kocsi kocsi)
        {
            _kocsi = kocsi;
        }
        public IViewComponentResult Invoke() 
        {
            var items = _kocsi.GetKocsiItems();
            _kocsi.KocsiItems = items;
            var KocsiWM = new KocsiViewModel
            {
                kocsi = _kocsi,
                kocsiTotal = _kocsi.GetTotal()
            };
            return View(KocsiWM);
        }
    }
}
