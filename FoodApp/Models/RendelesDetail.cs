using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodApp.Models
{
    public class RendelesDetail
    {
        public int RendelesDetailId { get; set; }
        public int RendelesId { get; set; }
        public int EtlapId { get; set; }
        public int Darab { get; set; }
        public virtual Etlap Etlap { get; set; }
        public virtual Rendeles Rendeles { get; set; }
        public int EtteremCimId { get; set; }
        public virtual EtteremCim EtteremCim { get; set; }
    }
}
