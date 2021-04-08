using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FoodApp.Models
{
    public class VendegCim
    {
        public int VendegCimId { get; set; }
        [DisplayName("Vezetéknév:")]
        [Required]
        public string VezetekNev { get; set; }

        [DisplayName("Keresztnév:")]
        [Required]
        public string KeresztNev { get; set; }

        [DisplayName("Város:")]
        [Required]
        public string Varos { get; set; }

        [DisplayName("Irányítószám:")]
        [Required]
        public int Iranyitoszam { get; set; }

        [DisplayName("Utca, házszám:")]
        [Required]
        public string Cim { get; set; }

        [DisplayName("E-mail cím:")]
        [Required]
        public string Email { get; set; }

        [DisplayName("Telefonszám:")]
        [Required]
        public string Telefonszam { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual IdentityUser IdentityUser { get; set; }
    }
}
