using Microsoft.AspNetCore.Identity;
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
        public string UserId { get; set; }
        public virtual IdentityUser IdentityUser { get; set; }
        public Etlap()
        {

        }
    }
}
