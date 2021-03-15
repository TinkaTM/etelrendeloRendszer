using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodApp.Models
{
    public class Etlap
    {
        public int ID { get; set; }
        public string Kategoria { get; set; }
        public string Nev { get; set; }
        public int Ar { get; set; }
        public string Allergen { get; set; }
        public string Leiras { get; set; }

        public Etlap()
        {

        }
    }
}
