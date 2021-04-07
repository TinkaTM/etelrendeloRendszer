using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace FoodApp.Models
{
    public class Rendeles
    {
        public int RendelesId { get; set; }
        public List<RendelesDetail> RendelesLine { get; set; }

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
        [DisplayName("Telefonszám: ")]
        public string Telefonszam { get; set; }
        [DisplayName("Rendelés idő:")]
        public DateTime RendelesIdo { get; set; }
        public string UserCookie { get; set; }
    }
}