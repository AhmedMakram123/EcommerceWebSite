using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebSite.Domain.DTOs
{
    public class CreateOrUpdateSubCategoryDTO
    {
      
        public string? Name { get; set; }
       
        public int CategoryId { get; set; }
    }
}
