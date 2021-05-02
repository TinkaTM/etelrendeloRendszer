using FoodApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodApp.ViewModels
{
    public class FutarRendelesKezelViewModel
    {
        public FutarAdat Futar { get; set; }
        public List<RendelesDarab> Rendelesek { get; set; }
    }
    public class RendelesDarab
    {
        public Rendeles RendelesAdatok { get; set; }
        public List<RendelesDetail> RendelesEtelek { get; set; }
        public int RendelesTotal { get; set; }
        public int RendekesStatId { get; set; }
        public bool Futarnal { get; set; }
    }
}
