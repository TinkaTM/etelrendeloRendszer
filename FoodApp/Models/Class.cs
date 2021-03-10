using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodApp.Models
{
    public class Class : IdentityUser
    {
        public String Name { get; set; }
        public String Address { get; set; }
        public String City { get; set; }
        public String PostalCode { get; set; }

    }
}
