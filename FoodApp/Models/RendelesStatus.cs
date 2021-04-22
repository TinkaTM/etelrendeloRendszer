﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodApp.Models
{
    public enum Status 
    { 
        Pending,
        Accepted,
        Declined
    }
    public class RendelesStatus
    {
        public int RendelesStatusId { get; set; }
        public int RendelesId { get; set; }
        public int EtteremId { get; set; }
        public virtual Rendeles Rendeles { get; set; }
        public virtual EtteremCim Etterem { get; set; }
        public Status RenStatus { get; set; }
        [DataType(DataType.Time)]
        public DateTime CompletionTime { get; set; }
    }
}
