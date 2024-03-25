using EcommerceWebSite.Domain.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebSite.Domain.DTOs
{
    public class CreateOrUpdateSubCategoryDTO
    {
      
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int CategoryId { get; set; }
       
    }
}
