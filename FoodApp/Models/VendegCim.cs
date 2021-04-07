using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FoodApp.Models
{
    public class VendegCim
    {
        public int VendegCimId { get; set; }
        [DisplayName("Vezetéknév:")]
        public string VezetekNev { get; set; }
        [DisplayName("Keresztnév:")]
        public string KeresztNev { get; set; }
        [DisplayName("Város:")]
        public string Varos { get; set; }
        [DisplayName("Irányítószám:")]
        public int Iranyitoszam { get; set; }
        [DisplayName("Utca, házszám:")]
        public string Cim { get; set; }
        [DisplayName("E-mail cím:")]
        public string Email { get; set; }
        [DisplayName("Telefonszám:")]
        public string Telefonszam { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual IdentityUser IdentityUser { get; set; }
    }
}
