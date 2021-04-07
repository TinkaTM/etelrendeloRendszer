using System;
using System.Collections.Generic;

namespace FoodApp.Models
{
    public class Rendeles
    {
        public int RendelesId { get; set; }
        public List<RendelesDetail> RendelesLine { get; set; }
        public string VezetekNev { get; set; }
        public string KeresztNev { get; set; }
        public string Varos { get; set; }
        public int Iranyitoszam { get; set; }
        public string Cim { get; set; }
        public string Email { get; set; }
        public string Telefonszam { get; set; }
        public DateTime RendelesIdo { get; set; }
        public string UserCookie { get; set; }
    }
}