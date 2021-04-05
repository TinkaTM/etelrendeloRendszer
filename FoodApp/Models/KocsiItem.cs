using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodApp.Models
{
    public class KocsiItem
    {
        public int KocsiItemId { get; set; }
        public Etlap Etel { get; set; }
        public int Darab { get; set; }
        public String KocsiId { get; set; }
        public int EtteremCimId { get; set; }
        public virtual EtteremCim EtteremCim { get; set; }
        public KocsiItem()
        {

        }
    }
}
