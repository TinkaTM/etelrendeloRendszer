using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FoodApp.Models
{

    public class Etlap
    {
        public int ID { get; set; }

        [DisplayName("Étel kategóriája: ")]
        public string Kategoria { get; set; }
        [DisplayName("Étel neve: ")]
        public string Nev { get; set; }
        [DisplayName("Ár: ")]
        public int Ar { get; set; }
        [DisplayName("Allergének: ")]
        public string Allergen { get; set; }
        [DisplayName("Étel leírása: ")]
        public string Leiras { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual IdentityUser IdentityUser { get; set; }
        public Etlap()
        {

        }
    }
}
