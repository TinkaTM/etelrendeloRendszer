using FoodApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodApp.ViewModels
{
    public class VendegRendelesViewModel
    {
        public Rendeles RendelesAdatok { get; set; }
        public Dictionary<RendelesStatus,List<RendelesDetail>> RendelesEtelek { get; set; }
        public int RendelesTotal { get; set; }
        public int SegedValtozo { get; set; }
    }
}
