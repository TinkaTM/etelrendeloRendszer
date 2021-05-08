using FoodApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodApp.ViewModels
{
    public class RendelesEtteremViewModel
    {
        public Rendeles RendelesAdatok { get; set; }
        public List<RendelesDetail> RendelesEtelek { get; set; }
        public RendelesStatus Stat { get; set; }
        public string FutarNev { get; set; }
        public int RendelesTotal { get; set; }
        public int SegedValtozo { get; set; }
    }
}
