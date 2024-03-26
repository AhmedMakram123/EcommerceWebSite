using EcommerceWebSite.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EcommerceWebSite.Domain.DTOs
{
    public class GetAllSubCategoryDTO
    {
        public int Id { get; set; }
     //   public string? Name { get; set; }
        public string? enName { get; set; }
        public string? arName { get; set; }
        public int CategoryId { get; set; }
        public virtual ICollection<Product> Products { get; set; }

    }
}
