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
    public class EtteremCim
    {
        public int ID { get; set; }

        [DisplayName("Étterem neve:")]
        public string EtteremNev { get; set; }

        [DisplayName("Irányítószám:")]
        public int Iranyitoszam { get; set; }

        [DisplayName("Város:")]
        public string Varos { get; set; }

        [DisplayName("Utca neve, szám:")]
        public string Cim { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        [DisplayName("Nyitás ideje:")]
        public DateTime Nyitas { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        [DisplayName("Zárás ideje:")]
        public DateTime Zaras { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual IdentityUser IdentityUser { get; set; }

        public EtteremCim()
        {
        }
    }
}
