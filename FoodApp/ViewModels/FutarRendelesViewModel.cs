using FoodApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodApp.ViewModels
{
    public class FutarRendelesViewModel
    {
        public FutarAdat Futar { get; set; }
        public List<RendelesDB> Rendelesek { get; set; }
    }
    public class RendelesDB
    {
        public EtteremCim Etterem {get; set;}
        public Rendeles RendelesAdatok { get; set; }
        public RendelesStatus Stat { get; set; }
        public List<RendelesDetail> RendelesEtelek { get; set; }
        public int RendelesTotal { get; set; }

    }
}
