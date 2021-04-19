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
    public class FutarAdat
    {
        [Key]
        public int FutarId { get; set; }
        [Required]
        [DisplayName("Keresztnév:")]
        public string Keresztnev { get; set; }
        [Required]
        [DisplayName("Vezetéknév:")]
        public string Vezeteknev { get; set; }
        [Required]
        [DisplayName("Jármű:")]
        public string Jarmu { get; set; }
        [Required]
        [DisplayName("Telefonszám:")]
        public string Telefonszam { get; set; }
        [Required]
        [DisplayName("Város:")]
        public string Varos { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        [Required]
        [DisplayName("Munkaidő kezdete:")]
        public DateTime Kezdes { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        [Required]
        [DisplayName("Munkaidő vége:")]
        public DateTime Vegzes { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual IdentityUser IdentityUser { get; set; }
    }
}
