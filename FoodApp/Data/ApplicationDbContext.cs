using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using FoodApp.Models;

namespace FoodApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<FoodApp.Models.Food> Food { get; set; }
        public DbSet<FoodApp.Models.Etlap> Etlap { get; set; }
        public DbSet<FoodApp.Models.EtteremCim> EtteremCim { get; set; }
        public DbSet<FoodApp.Models.KocsiItem> KocsiItem { get; set; }
        public DbSet<FoodApp.Models.VendegCim> VendegCim { get; set; }
        public DbSet<FoodApp.Models.RendelesDetail> RendelesDetail { get; set; }
        public DbSet<FoodApp.Models.Rendeles> Rendeles { get; set; }
        public DbSet<FoodApp.Models.FutarAdat> FutarAdat { get; set; }
    }
}
