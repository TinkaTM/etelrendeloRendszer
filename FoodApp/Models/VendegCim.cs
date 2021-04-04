using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FoodApp.Models
{
    public class VendegCim
    {
        public int VendegCimId { get; set; }
        public string VezetekNev { get; set; }
        public string KeresztNev { get; set; }
        public string Varos { get; set; }
        public int Iranyitoszam { get; set; }
        public string Cim { get; set; }
        public string Email { get; set; }
        public string Telefonszam { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual IdentityUser IdentityUser { get; set; }
    }
}
