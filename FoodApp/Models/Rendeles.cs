using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodApp.Models
{
    public class Rendeles
    {
        public int RendelesId { get; set; }
        public List<RendelesDetail> RendelesLine { get; set; }

        [Required]
        [DisplayName("Vezetéknév:")]
        public string VezetekNev { get; set; }

        [Required]
        [DisplayName("Keresztnév:")]
        public string KeresztNev { get; set; }

        [Required]
        [DisplayName("Város:")]
        public string Varos { get; set; }
        [Required]
        [DisplayName("Irányítószám:")]
        public int Iranyitoszam { get; set; }
        [Required]
        [DisplayName("Utca, házszám:")]
        public string Cim { get; set; }
        [Required]
        [DisplayName("E-mail cím:")]
        public string Email { get; set; }
        [Required]
        [DisplayName("Telefonszám: ")]
        public string Telefonszam { get; set; }
        [DisplayName("Rendelés idő:")]
        public DateTime RendelesIdo { get; set; }
        public string UserCookie { get; set; }
        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual IdentityUser? IdentityUser { get; set; }
    }
}