using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebSite.Domain.Models
{
    public class Customer: ApplicationUser
    {
        public CartItem Cart { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
