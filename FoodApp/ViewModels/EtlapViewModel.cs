using FoodApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodApp.ViewModels
{
    public class EtlapViewModel
    {
        public Dictionary<string, List<Etlap>> EtlapDict { get; set; }
        public string Etteremnev { get; set; }
    }
}
